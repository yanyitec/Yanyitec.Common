using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Reflection
{
    public class VisitorExpressionException :Exception
    {
        public VisitorExpressionException(string expr,string msg=null):base(msg) {
            this.Expression = expr;
        }
        public string Expression { get; private set; }
    }
}
