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
            for (var at = 0; at < expr.Length; at++) {
                var ch = expr[at];
                Action<int, char, string> notice = null;
                if (Meets.TryGetValue(ch, out notice)) {
                    notice(at,ch,expr);
                }
            }
        }
    }
}
