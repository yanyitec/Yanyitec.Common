//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Yanyitec.Reflection
//{
//    public class VisitorParser
//    {
//        public char LastToken { get; set; }
//        public int LastTokenAt { get; set; }

//        public char IsInString { get; set; }

//        public Visitor CurrentVisitor { get; set; }

//        public Action<Visitor> ValueVisited{get;set;}

//        public void Parse(string expr) {
//            var reader = new VisitorReader();
            
//        }
//        /// <summary>
//        /// ,
//        /// </summary>
//        /// <param name="at"></param>
//        /// <param name="token"></param>
//        /// <param name="expr"></param>
//        void Comma(int at, char token, string expr) {
//            if (IsInString != 0) return;
//            if (this.LastToken == '}' || this.LastToken == ']') {
//                this.LastTokenAt = at;
//                this.LastToken = token;
//                return;
//            }
//            var membername = expr.Substring(this.LastTokenAt + 1, at - this.LastTokenAt).Trim();
//            this.LastTokenAt = at;
//            this.LastToken = token;
//            var member = CurrentVisitor.Class[membername];
//            if (member==null) return;
//            var currentVisitor = new Visitor() {
//                Class = this.CurrentVisitor.Class,
//                MemberAccessor = member,
//                Parent = this.CurrentVisitor,
//                Value = this.CurrentVisitor.Value == null ? null : member.GetValue(this.CurrentVisitor.Value, false)
//            };
//            this.ValueVisited(currentVisitor);
//        }
//        /// <summary>
//        /// :
//        /// </summary>
//        /// <param name="at"></param>
//        /// <param name="token"></param>
//        /// <param name="expr"></param>
//        void Colon(int at, char token, string expr) {
//            if (IsInString != 0) return;
//            var membername = expr.Substring(this.LastTokenAt + 1, at - this.LastTokenAt);
//            this.LastTokenAt = at;
//            this.LastToken = token;

//            var member = CurrentVisitor.Class[membername];
//            if (member == null) return;
//            var currentVisitor = new Visitor()
//            {
//                Class = this.CurrentVisitor.Class,
//                MemberAccessor = member,
//                Parent = this.CurrentVisitor,
//                Value = this.CurrentVisitor.Value==null?null: member.GetValue(this.CurrentVisitor.Value, false)
//            };
//            this.CurrentVisitor = currentVisitor;
//            this.ValueVisited(currentVisitor);
//        }
//        void BraceBegin(int at, char token, string expr) {
//            if (IsInString != 0) return;
//            if (LastToken != ',' && LastToken != ':' && LastToken!='[' && LastToken!='\0') {
//                throw new InvalidProgramException();
//            }
//            this.LastTokenAt = at;
//            this.LastToken = token;
//        }

//        void BraceEnd(int at, char token, string expr)
//        {
//            if (IsInString != 0) return;
//            if (IsInString != 0) return;
//            var membername = expr.Substring(this.LastTokenAt + 1, at - this.LastTokenAt);
//            this.LastTokenAt = at;
//            this.LastToken = token;

//            var member = CurrentVisitor.Class[membername];
//            if (member == null) return;
//            var currentVisitor = new Visitor()
//            {
//                Class = this.CurrentVisitor.Class,
//                MemberAccessor = member,
//                Parent = this.CurrentVisitor,
//                Value = this.CurrentVisitor.Value == null ? null : member.GetValue(this.CurrentVisitor.Value, false)
//            };
            
//            this.ValueVisited(currentVisitor);

//            this.CurrentVisitor = this.CurrentVisitor.Parent;
//        }

        
//        //brace 
//    }
//}
