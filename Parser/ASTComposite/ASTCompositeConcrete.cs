﻿/*
MIT License

Copyright(c) [2016] [Grigoris Dimitroulakos]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Parser.ASTVisitor;
using Parser.ASTEvents;
using Parser.ASTFactories;
using Parser.ASTIterator;
using Parser.ASTVisitor;
using RangeIntervals;


//todo:1 Classes CRange,CRegexpbasicChar,CRegexpbasicSet must be enriched with extra information
//todo:2 Package the Information of the above classes into distinct classes
//



namespace Parser {


    /// <summary>
    /// This file contains automatically generated code
    /// </summary>
    ///

    public enum NodeType {
        /// <summary>
        /// This enumeration carries the different types of AST Nodes. The numbers indicate the index in the
        /// m_contextMappings table of tuples where each specific context starts
        /// </summary>
        // NON-TERMINAL NODES
        /* 24 */
        NT_LEXERDESCRIPTION = 0, NT_REGEXPSTATEMENT=1,NT_REGEXPALTERNATION =4,NT_REGEXPCONCATENATION =5,NT_REGEXPCLOSURE =6, NT_CLOSURERANGE=8,
        NT_REGEXPBASIC_PAREN=10,NT_REGEXPBASIC_SET, NT_REGEXPBASIC_SETNEGATION, NT_REGEXPBASIC_ANYEXCEPTEOL,
        NT_REGEXPBASIC_CHAR,NT_REGEXPBASIC_ENDOFLINE,
        NT_REGEXPBASIC_STARTOFLINE,NT_REGEXPBASIC_ASSERTIONS,NT_REGEXPBASIC_STRING=18,
        NT_ASSERTION_FWDPOS =19, NT_ASSERTION_FWDNEG =20, NT_ASSERTION_BWDPOS =21, NT_ASSERTION_BWDNEG =22,
       NT_RANGE =23,NT_ACTIONCODE=25, 

        // LEAF NODES
        /* 5 */
        NT_CHAR = 26,NT_CONTROL_CHARACTER=27, NT_INTEGER=28, NT_ID=29, NT_STRING=30, 

        
        // NODE CATEGORIES
       CAT_REGEXP_OPERATORS,CAT_REGEXP_BASIC,CAT_ASSERTIONS,CAT_LEAFS,CAT_NA
    }
    /// <summary>
    /// Enumerable which contains all the context types we have
    /// </summary>
    public enum ContextType {

        /* 0 */ CT_LEXERDESCRIPTION_BODY = 0,
        /* 1 */ CT_REGEXPSTATEMENT_TOKENNAME = 1,
        /* 2 */ CT_REGEXPSTATEMENT_REGEXP =2,
        /* 3 */ CT_REGEXPSTATEMENT_ACTIONCODE =3,
        /* 4 */CT_REGEXPALTERNATION_TERMS = 4,
        /* 5 */CT_REGEXPCONCATENATION_TERMS = 5,
        /* 6 */CT_REGEXPCLOSURE_REGEXP = 6,
        /* 7 */CT_REGEXPCLOSURE_QUANTIFIER = 7,
        /* 8 */CT_CLOSURERANGE_MIN = 8,
        /* 9 */CT_CLOSURERANGE_MAX = 9,
        /* 10 */CT_RGEXPBASIC_PAREN = 10,
        /* 11 */ CT_REGEXPBASIC_SET =11,
        /* 12 */CT_REGEXPBASIC_SETNEGATION=12,
        /* 13 */CT_REGEXPBASIC_ANYEXCEPTEOL = 13,
        /* 14 */ CT_REGEXPBASIC_CHAR = 14,
        /* 15 */ CT_REGEXPBASIC_ENDOFLINE =15,
        /* 16 */CT_REGEXPBASIC_STARTOFLINE = 16,
        /* 17 */CT_REGEXPBASIC_ASSERTIONS =17,
        /* 18 */ CT_REGEXPBASIC_STRING = 18,
        /* 19 */CT_ASSERTION_FWDPOS = 19,
        /* 20 */ CT_ASSERTION_FWDNEG = 20,
        /* 21 */ CT_ASSERTION_BWDPOS = 21,
        /* 22 */ CT_ASSERTION_BWDNEG = 22,
        /* 23 */ CT_RANGE_MIN = 23,
        /* 24 */ CT_RANGE_MAX = 24,
        /* 25 */ CT_ACTIONCODE = 25,
        CT_NA
    }
    /// <summary>
    /// Enumerable which contains the different types that a node 
    /// possibly has
    /// </summary>
    public enum TypeSpecifier {
        TP_VOID, TP_FLOAT
    }

    /// <summary>
    /// Class which contains methods that have to do with the LexerDescription node
    /// Inside this class we can find the function call of this class, the AcceptVisitor,
    /// the AcceptIterator and the AcceptIteratorEvents methods
    /// </summary>
    public class CLexerDescription : CASTComposite {
        public CLexerDescription(string text) :base(NodeType.NT_LEXERDESCRIPTION,null,text, NodeType.CAT_NA) {
        }
        /// <summary>
        /// returns the children of this node
        /// </summary>
        /// <typeparam name="Return"></typeparam>
        /// <param name="visitor">the node we want to test</param>
        /// <returns>The node's children,else returns null(if there is no valid node given)</returns>
        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor) {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitLexerDescription(this);
            else return visitor.VisitChildren(this);
        }
        /// <summary>
        /// Creates an iterator for the LexerDescription node
        /// </summary>
        /// <param name="iteratorFactory"></param>
        /// <returns></returns>
        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory) {
             IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null) {
                return iteratorFactory.CreateLexerDescriptionIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null) {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null) {
                return iteratorFactory.CreateLexerDescriptionIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }
    public class CRegexpStatement : CASTComposite
    {
        public string M_StatementID { get; internal set; }

        private TextSpan m_statementTextSpan;

        public TextSpan M_StatementTextSpan => m_statementTextSpan;

        public uint M_Line => m_statementTextSpan.M_StartLine;

        private bool m_containsClosure;

        public bool M_ContainsClosure {
            get => m_containsClosure;
            set => m_containsClosure = value;
        }

        public CRegexpStatement(CASTComposite parent, TextSpan textSpan,string text) : base(NodeType.NT_REGEXPSTATEMENT, parent,text,
            NodeType.CAT_NA) {
            m_statementTextSpan = textSpan;
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRegexpStatement(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRegexpStatementIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRegexpStatementIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class CRegexpAlternation : CASTComposite
    {
        public CRegexpAlternation(CASTComposite parent,string text) : base(NodeType.NT_REGEXPALTERNATION, parent,text, NodeType.CAT_NA)
        {
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRegexpAlternation(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRegexpAlternationIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRegexpAlternationIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class CRegexpConcatenation : CASTComposite
    {
        public CRegexpConcatenation(CASTComposite parent,string text) : base(NodeType.NT_REGEXPCONCATENATION, parent,text, NodeType.CAT_NA)
        {
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRegexpConcatenation(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRegexpConcatenationIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRegexpConcatenationIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class CActionCode : CASTComposite {
        public CActionCode(CASTComposite parent,string text) : base(NodeType.NT_ACTIONCODE, parent,text, NodeType.CAT_NA) {}

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor) {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitActionCode(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(
            CASTAbstractConcreteIteratorFactory iteratorFactory) {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null) {
                return iteratorFactory.CreateActionCodeIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(
            CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null) {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null) {
                return iteratorFactory.CreateActionCodeIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class CRegexpClosure : CASTComposite
    {
        public enum ClosureType{
            CLT_NA, CLT_ONEORZERO, CLT_ONEORMULTIPLE, CLT_ONEORMULTIPLE_NONGREEDY,
            CLT_NONEORMULTIPLE, CLT_NONEORMULTIPLE_NONGREEDY, CLT_FINITECLOSURE
        }
                
        private ClosureType m_closureType;
        

        public ClosureType M_ClosureType{
            get{
                return m_closureType;
            }
            protected set { m_closureType = value; }
        }
             

        public CRegexpClosure(CASTComposite parent, string text) : base(NodeType.NT_REGEXPCLOSURE, parent,text, NodeType.CAT_NA)
        {
        }             

        public void SetClosureType(ClosureType t)
        {
            M_ClosureType = t;
        }

        public override string M_Label {
            get { return m_label + M_ClosureType.ToString(); }
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRegexpClosure(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRegexpClosureIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRegexpClosureIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class CClosureRange : CASTComposite {
        internal struct ClosureRange {
            internal int lowerBound;
            internal int upperBound;
        }

        private ClosureRange m_closureMultiplicity;

        public int M_ClosureMultiplicityLB {
            get { return m_closureMultiplicity.lowerBound; }
            protected set {
                m_closureMultiplicity.lowerBound = value;
            }
        }

        /// <summary>
        /// It is the multiplicity upper bound. This value is relevant only 
        /// for the case where closure type is CLT_FINITECLOSURE
        /// </summary>
        public int M_ClosureMultiplicityUB {
            get { return m_closureMultiplicity.upperBound; }
            protected set {
                m_closureMultiplicity.upperBound = value;
            }
        }

        public void SetClosureMultiplicity(int m, bool UB = false) {
            if (!UB) {
                M_ClosureMultiplicityLB = m;
            }
            else {
                M_ClosureMultiplicityUB = m;
            }
        }

        public override string M_Label {
            get { return m_label + " " + M_ClosureMultiplicityLB + "-" + (M_ClosureMultiplicityUB == Int32.MaxValue ? "INF" : M_ClosureMultiplicityUB.ToString()); }
        }

        public CClosureRange(CASTComposite parent, string text) : base(NodeType.NT_CLOSURERANGE, parent,text, NodeType.CAT_NA) { }
        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor) {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitClosureRange(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory) {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null) {
                return iteratorFactory.CreateClosureRangeIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null) {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null) {
                return iteratorFactory.CreateClosureRangeIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class CRegexpbasicParen : CASTComposite {
        public CRegexpbasicParen(CASTComposite parent, string text) : base(NodeType.NT_REGEXPBASIC_PAREN, parent,text, NodeType.CAT_NA) {}
        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor) {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRegexpbasicParen(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory) {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null) {
                return iteratorFactory.CreateRegexpbasicParenIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null) {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null) {
                return iteratorFactory.CreateRegexpbasicParenIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class CRegexpbasicSet : CASTComposite{
        private CCharRangeSet m_set;

        public CCharRangeSet MSet => m_set;

        private bool m_isSetNegation = false;

        public bool M_IsSetNegation {
            get { return m_isSetNegation; }
        }

        public CRegexpbasicSet(CASTComposite parent,bool negation, string text) : 
            base(negation ? NodeType.NT_REGEXPBASIC_SETNEGATION : NodeType.NT_REGEXPBASIC_SET, parent,text,
                NodeType.CAT_NA) {
            m_isSetNegation = negation;
            m_set = new CCharRangeSet(negation);

        }

        public void SetSetType(bool asIs = true) {
            m_isSetNegation = asIs;
        }

        public void InsertChar(char c) {
            m_set.AddRange(new CCharRange(Convert.ToInt32(c),Convert.ToInt32(c)));
        }

        public void InsertRange(CCharRange range) {
            m_set.AddRange(range);
        }
        
        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRegexpbasicSet(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRegexpbasicSetIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRegexpbasicSetIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }
    public class CRegexpbasicAnyexcepteol : CASTLeaf<CASTElement>
    {
        public CRegexpbasicAnyexcepteol(CASTComposite parent, string text) : base(".",NodeType.NT_REGEXPBASIC_ANYEXCEPTEOL,parent,text)
        {
        }

        protected override void AddChild(CASTElement child, int context, int pos = -1) {
            throw new NotImplementedException();
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRegexpbasicAnyexcepteol(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();
        }
    }
    public class CRegexpbasicChar : CASTLeaf<CASTElement>
    {
       public enum CharType {
            CRT_LITCRC,CRT_ΕΧΜΑΡΚ,CRT_LESS,CRT_EQ,CRT_EOL,CRT_SOL, CRT_SCODEANC, CRT_LP, CRT_RP, CRT_LB,
            CRT_ANYEXEOL, CRT_DIESIS, CRT_ESC, CRT_QMARK, CRT_ONEORMUL, CRT_NONEORMUL, CRT_ALTER
        }
        private CharType m_charType;

        private CCharRangeSet m_charRangeSet;

        public CCharRangeSet M_CharRangeSet => m_charRangeSet;

        public CharType M_CharType
        {
            get
            {
                return m_charType;
            }
            protected set { m_charType = value; }
        }



        public CRegexpbasicChar(string charLiteral, CASTComposite parent, string text) : base(charLiteral, NodeType.NT_REGEXPBASIC_CHAR, parent,text)
        {
            m_charRangeSet = new CCharRangeSet(charLiteral[0]);
        }

        protected override void AddChild(CASTElement child, int context, int pos = -1) {
            throw new NotImplementedException();
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRegexpbasicChar(this);
            else return visitor.VisitTerminal(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();

        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();

        }
    }
    public class CRegexpbasicEndofline : CASTLeaf<CASTElement>
    {
        public CRegexpbasicEndofline(CASTComposite parent, string text) : base("$",NodeType.NT_REGEXPBASIC_ENDOFLINE, parent,text)
        {
            m_value = this;
            if (m_semanticValueConverter == null) {
                m_semanticValueConverter = TokenSemanticValueDefaultConverter.Create(this);
            }
        }

        protected override void AddChild(CASTElement child, int context, int pos = -1) {
            throw new NotImplementedException();
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRegexpbasicEndofline(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();
        }
    }
    public class CRegexpbasicStartofline : CASTLeaf<CASTElement>
    {
        public CRegexpbasicStartofline(CASTComposite parent, string text) : base("^",NodeType.NT_REGEXPBASIC_STARTOFLINE,parent,text)
        {
        }

        protected override void AddChild(CASTElement child, int context, int pos = -1) {
            throw new NotImplementedException();
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRegexpbasicStartofline(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();
        }
    }
    public class CRegexpbasicAssertions : CASTComposite
    {
        public CRegexpbasicAssertions(CASTComposite parent, string text) : base(NodeType.NT_REGEXPBASIC_ASSERTIONS, parent,text, NodeType.CAT_NA)
        {
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRegexpbasicAssertions(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRegexpbasicAssertionsIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateRegexpbasicAssertionsIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }

    public class CRegexpID : CASTLeaf<string>
    {
        public string M_RegExpID { get; set; }
        public CRegexpID(string stringLiteral, CASTComposite parent, string text) : base(stringLiteral, NodeType.NT_ID, parent,text) {
            M_RegExpID = stringLiteral;
        }

        protected override void AddChild(CASTElement child, int context, int pos = -1)
        {
            throw new NotImplementedException();
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRegexpID(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();
        }
    }

    public class CRegexpbasicString : CASTLeaf<string>
    {
        public CRegexpbasicString(string stringLiteral,CASTComposite parent, string text) : base(stringLiteral,NodeType.NT_REGEXPBASIC_STRING,parent,text) {
        }

        protected override void AddChild(CASTElement child, int context, int pos = -1) {
            throw new NotImplementedException();
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRegexpbasicString(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();
        }
    }
    public class CAssertionFwdpos : CASTComposite
    {
        public CAssertionFwdpos(CASTComposite parent, string text) : base(NodeType.NT_ASSERTION_FWDPOS, parent,text, NodeType.CAT_NA)
        {
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitAssertionFwdpos(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateAssertionFwdposIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateAssertionFwdposIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }
    public class CAssertionFwdneg : CASTComposite
    {
        public CAssertionFwdneg(CASTComposite parent, string text) : base(NodeType.NT_ASSERTION_FWDNEG, parent,text, NodeType.CAT_NA)
        {
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitAssertionFwdneg(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateAssertionFwdnegIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateAssertionFwdnegIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }
    public class CAssertionBwdpos : CASTComposite
    {
        public CAssertionBwdpos(CASTComposite parent, string text) : base(NodeType.NT_ASSERTION_BWDPOS, parent,text, NodeType.CAT_NA)
        {
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitAssertionBwdpos(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateAssertionBwdposIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateAssertionBwdposIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }
    public class CAssertionBwdneg : CASTComposite
    {
        public CAssertionBwdneg(CASTComposite parent, string text) : base(NodeType.NT_ASSERTION_BWDNEG, parent,text, NodeType.CAT_NA)
        {
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitAssertionBwdneg(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateAssertionBwdnegIterator(this);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlatten(this);
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            IASTAbstractConcreteIteratorFactory typedFactory = iteratorFactory as IASTAbstractConcreteIteratorFactory;
            if (typedFactory != null)
            {
                return iteratorFactory.CreateAssertionBwdnegIteratorEvents(this, events, info);
            }
            return iteratorFactory.CreateIteratorASTElementDescentantsFlattenEvents(this, events, info);
        }
    }
 
    public class CRange : CASTComposite
    {
        private CCharRange m_range;

        // These fields act as a contructor builder for the 
        // CCharRange class object
        private char m_lower;
        private char m_upper;

        public char MLower {
            get { return m_lower; }
            set { m_lower = value; }
        }

        public char MUpper {
            get { return m_upper; }
            set { m_upper = value; }
        }

        public CCharRange MRange => m_range;

        public CRange(CASTComposite parent, string text) : base(NodeType.NT_RANGE, parent,text, NodeType.CAT_NA)
        {
        }

        public void Update() {
            m_range = new CCharRange(m_lower,m_upper);
        }

        public override void AddChild(CASTElement child, ContextType context = ContextType.CT_NA, int pos = -1){
            switch (context){
                case ContextType.CT_RANGE_MIN:
                    MLower = (child as CRegexpbasicChar).M_TokenLiteral[0];
                    break;
                case ContextType.CT_RANGE_MAX:
                    MUpper = (child as CRegexpbasicChar).M_TokenLiteral[0];
                    break;
            }
            base.AddChild(child, context, pos);
        }

        public override Return AcceptVisitor<Return>(CASTAbstractVisitor<Return> visitor)
        {
            IASTAbstractConcreteVisitor<Return> typedVisitor = visitor as IASTAbstractConcreteVisitor<Return>;
            if (typedVisitor != null) return typedVisitor.VisitRange(this);
            else return visitor.VisitChildren(this);
        }

        public override CAbstractIterator<CASTElement> AcceptIterator(CASTAbstractConcreteIteratorFactory iteratorFactory)
        {
            throw new NotImplementedException();
        }

        public override CAbstractIterator<CASTElement> AcceptEventIterator(CASTAbstractConcreteIteratorFactory iteratorFactory,
            CASTGenericIteratorEvents events, object info = null)
        {
            throw new NotImplementedException();
        }
    }


}




