﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;
using GraphLibrary.Generics;
using Parser.SubsetConstruction;
using Parser.UOPCore;


namespace Parser.ASTVisitor.ConcreteVisitors
{
    class ThompsonVisitor : CASTAbstractConcreteVisitor<FA>{
        private FA m_NFA=null;

        public FA M_Nfa{
            get{ return m_NFA; }
        }

        public ThompsonVisitor() : base()
        {
            
        }

        public override FA VisitRegexpbasicParen(CASTElement currentNode){
            CASTComposite curNode = currentNode as CASTComposite;

            m_NFA = Visit(curNode.GetChild(ContextType.CT_RGEXPBASIC_PAREN, 0));

            return m_NFA;
        }

        public override FA AggregateResult(FA intermediateResult){
            return intermediateResult;
        }

        public override FA VisitRegexpStatement(CASTElement currentNode)
        {
            FA fa =  base.VisitRegexpStatement(currentNode);
            fa.RegisterGraphPrinter(new ThompsonGraphVizPrinter(fa));
            fa.Generate(@"../Debug/merge.dot", true);
            return null;
        }

        public override FA VisitRegexpAlternation(CASTElement currentNode)
        {
            CRegexpAlternation altNode = currentNode as CRegexpAlternation;
            //1. Create FA 
            CThompsonAlternationTemplate alttempSyn = new CThompsonAlternationTemplate();
            FA leftFa = Visit(altNode.GetChild(ContextType.CT_REGEXPALTERNATION_TERMS, 0));
            FA rightFa = Visit(altNode.GetChild(ContextType.CT_REGEXPALTERNATION_TERMS, 1));
            //2.Synthesize the two FAs to a new one
            m_NFA= alttempSyn.Sythesize(leftFa, rightFa);
            
            //return the final-synthesized FA
            return m_NFA;
        }

        public override FA VisitRegexpConcatenation(CASTElement currentNode)
        {
            CRegexpConcatenation altNode = currentNode as CRegexpConcatenation;
            //1. Create FA 
            CThompsonConcatenationTemplate alttempSyn = new CThompsonConcatenationTemplate();
            FA leftFa = Visit(altNode.GetChild(ContextType.CT_REGEXPCONCATENATION_TERMS, 0));
            FA rightFa = Visit(altNode.GetChild(ContextType.CT_REGEXPCONCATENATION_TERMS, 1));
            //2.Synthesize the two FAs to a new one
            m_NFA = alttempSyn.Synthesize(leftFa, rightFa);


           /* CSubsetConstructionAlgorithm qset = CSubsetConstructionAlgorithm.Init(m_NFA, m_NFA);
            
            HashSet<CGraphNode> dset = CDeltaAlgorithm
                .Init(m_NFA, "a", new HashSet<CGraphNode>(){m_NFA.M_Initial}).Start();
            HashSet<CGraphNode> eset= CEclosureAlgorithm.Init(m_NFA, m_NFA, dset).Start();
            //return the final-synthesized FA*/
            
            return m_NFA;
        }

        public override FA VisitRegexpClosure(CASTElement currentNode) {

            CRegexpClosure closNode = currentNode as CRegexpClosure;
            //1.Create FA
            CThompsonClosureTemplate newFA = new CThompsonClosureTemplate();
            //2.Check the type of the closure
            if (closNode.M_ClosureType == CRegexpClosure.ClosureType.CLT_NONEORMULTIPLE) {
                FA customFA = Visit(closNode.GetChild(ContextType.CT_REGEXPCLOSURE_REGEXP,0));
                m_NFA = newFA.SynthesizeNoneOrMul(customFA);
            }

            else if(closNode.M_ClosureType==CRegexpClosure.ClosureType.CLT_ONEORMULTIPLE){
                FA customFA = Visit(closNode.GetChild(ContextType.CT_REGEXPCLOSURE_REGEXP, 0));
                m_NFA = newFA.SynthesisOneOrMul(customFA);
            }
            else if (closNode.M_ClosureType == CRegexpClosure.ClosureType.CLT_ONEORZERO){
                FA customFA = Visit(closNode.GetChild(ContextType.CT_REGEXPCLOSURE_REGEXP, 0));
                m_NFA = newFA.SynthesizeOneOrNone(customFA);
            }
            else{
                Console.WriteLine("No proper input");
            }
            //4.Pass FA to the predecessor
            return m_NFA;
        }

        public override FA VisitRegexpbasicChar(CASTElement currentNode)
        {
            CRegexpbasicChar charNode = currentNode as CRegexpbasicChar;

            //1.Create FA
            m_NFA = new FA();
            
            //2.Create nodes initial-final
            CGraphNode init = m_NFA.CreateGraphNode();
            CGraphNode final = m_NFA.CreateGraphNode();
            m_NFA.M_Initial = init;
            m_NFA.SetFinalState(final);
            m_NFA.M_Alphabet.AddSet(charNode.M_CharRangeSet);
            
            //3.Draw the edge including the character
            CGraphEdge newEdge = m_NFA.AddGraphEdge(init, final,GraphType.GT_DIRECTED);
            newEdge[FA.m_TRANSITIONSKEY] = charNode.M_CharRangeSet;
            //newEdge.SetLabel(charNode.M_TokenLiteral);
            //4.Pass FA to the predecessor
            return m_NFA;
        }

        public override FA VisitRegexpbasicSet(CASTElement currentNode){
            CRegexpbasicSet setNode = currentNode as CRegexpbasicSet;
            
            //Create FA
            m_NFA = new FA();

            CGraphNode init = m_NFA.CreateGraphNode();
            CGraphNode final = m_NFA.CreateGraphNode();
            m_NFA.M_Initial = init;
            m_NFA.SetFinalState(final);
            m_NFA.M_Alphabet.AddSet(setNode.MSet);

            CGraphEdge newEdge = m_NFA.AddGraphEdge(init, final, GraphType.GT_DIRECTED);

            newEdge[FA.m_TRANSITIONSKEY] = setNode.MSet;
            //4.Pass FA to the predecessor
            return m_NFA;

        }

        public override FA VisitRange(CASTElement currentNode){
            CRange rangeNode = currentNode as CRange;

            //1.Create FA
            m_NFA = new FA();

            //2.Create nodes initial-final
            CGraphNode init = m_NFA.CreateGraphNode();
            CGraphNode final = m_NFA.CreateGraphNode();
            m_NFA.M_Initial = init;
            m_NFA.SetFinalState(final);
            m_NFA.M_Alphabet.AddRange(rangeNode.MRange);

            //3.Draw the edge including the character
            CGraphEdge newEdge = m_NFA.AddGraphEdge(init, final, GraphType.GT_DIRECTED);
            newEdge[FA.m_TRANSITIONSKEY] = rangeNode.MRange;
            newEdge.SetLabel(rangeNode.MRange.ToString());
            //4.Pass FA to the predecessor
            return m_NFA;
        }
    }
}