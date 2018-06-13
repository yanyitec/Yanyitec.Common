using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Reflection
{
    public class VisitorParser
    {
        public char LastToken { get; set; }
        public int LastTokenAt { get; set; }

        public char IsInString { get; set; }

        public Visitor CurrentVisitor { get; set; }

        public IClass CurrentClass { get; set; }

        public Action<Visitor> ValueVisited { get; set; }

        public string Expression { get; set; }

        public Stack<IClass> ClassStack { get; set; }

        public Visitor Parse(string expr,IClass currentClass)
        {
            
            
            this.CurrentClass = currentClass;
            this.CurrentVisitor = new Visitor(null,null);
            this.ClassStack.Push(currentClass);
            var reader = new VisitorReader();
            reader.Meets =new Dictionary<char, Action<int, char, string>>() {
                {',',Comma }
                ,{':',Colon }
                ,{'{',BraceBegin}
                ,{ '}',BraceEnd }
                ,{ '\0', Comma}
            };
            reader.Read(this.Expression = expr);
            if (this.ClassStack.Count != 0) {
                throw new VisitorExpressionException(expr,"Unended expression.");
            }
            return this.CurrentVisitor;
        }
        /// <summary>
        /// ,
        /// </summary>
        /// <param name="at"></param>
        /// <param name="token"></param>
        /// <param name="expr"></param>
        void Comma(int at, char token, string expr)
        {
            if (IsInString != 0) return;
            if (this.LastToken == '}' )
            {
                this.LastTokenAt = at;
                this.LastToken = token;
                return;
            }
            var membername = expr.Substring(this.LastTokenAt + 1, at - this.LastTokenAt).Trim();
            this.LastTokenAt = at;
            this.LastToken = token;
            var member = this.CurrentClass[membername];
            if (member == null) return;
            var currentVisitor = new Visitor(member, this.CurrentVisitor);
            List<Visitor> visitors = this.CurrentVisitor.Subsidaries as List<Visitor>;
            if (visitors == null) {
                this.CurrentVisitor.Subsidaries = visitors = new List<Visitor>();
            }
            visitors.Add(currentVisitor);
        }
        /// <summary>
        /// :
        /// </summary>
        /// <param name="at"></param>
        /// <param name="token"></param>
        /// <param name="expr"></param>
        void Colon(int at, char token, string expr)
        {
            if (IsInString != 0) return;
            var membername = expr.Substring(this.LastTokenAt + 1, at - this.LastTokenAt);
            this.LastTokenAt = at;
            this.LastToken = token;

            var member = this.CurrentClass[membername];
            if (member == null) return;
            var currentVisitor = new Visitor(member, this.CurrentVisitor);
            List<Visitor> visitors = this.CurrentVisitor.Subsidaries as List<Visitor>;
            if (visitors == null)
            {
                this.CurrentVisitor.Subsidaries = visitors = new List<Visitor>();
            }
            visitors.Add(currentVisitor);
            this.ClassStack.Push(this.CurrentClass);
            this.CurrentVisitor = currentVisitor;
            this.CurrentClass = member.Class.ClassFactory.Aquire(member.EntitativeType);
        }
        void BraceBegin(int at, char token, string expr)
        {
            if (IsInString != 0) return;
            if (LastToken != ',' && LastToken != ':' && LastToken != '\0')
            {
                throw new InvalidProgramException();
            }
            this.LastTokenAt = at;
            this.LastToken = token;
        }

        void BraceEnd(int at, char token, string expr)
        {
            if (IsInString != 0) return;
            if (IsInString != 0) return;
            var membername = expr.Substring(this.LastTokenAt + 1, at - this.LastTokenAt);
            this.LastTokenAt = at;
            this.LastToken = token;

            var member = this.CurrentClass[membername];
            if (member == null) return;
            var currentVisitor = new Visitor(member, this.CurrentVisitor);

            List<Visitor> visitors = this.CurrentVisitor.Subsidaries as List<Visitor>;
            if (visitors == null)
            {
                this.CurrentVisitor.Subsidaries = visitors = new List<Visitor>();
            }
            visitors.Add(currentVisitor);

            this.CurrentVisitor = this.CurrentVisitor.ParentVisitor;
            if (this.CurrentVisitor == null) {
                throw new VisitorExpressionException(this.Expression,"unexpected }");
            }
            this.CurrentClass = this.ClassStack.Pop();
            
        }


        //brace 
    }
}
