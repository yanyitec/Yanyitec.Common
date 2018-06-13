using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Reflection
{
    public class VisitorReader
    {
        public VisitorReader() { }

        public Dictionary<char, Action<int,char,string>> Meets { get; set; }
        public void Read(string expr) {
            Action<int, char, string> notice = null;
            for (var at = 0; at < expr.Length; at++) {
                var ch = expr[at];
                if (Meets.TryGetValue(ch, out notice)) {
                    notice(at,ch,expr);
                }
            }
            
            if (Meets.TryGetValue('\0', out notice))
            {
                notice(expr.Length, '\0', expr);
            }
        }
    }
}
