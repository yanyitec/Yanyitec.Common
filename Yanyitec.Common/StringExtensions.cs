using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Yanyitec
{
    public static class StringExtensions
    {
        static Regex CommentRegex = new Regex("\\s*//[^\\n]\\n",RegexOptions.Compiled);
        public static JToken ToJson(this string self) {
            var json = CommentRegex.Replace(self, string.Empty);
            return JToken.Parse(json);
        }
    }
}
