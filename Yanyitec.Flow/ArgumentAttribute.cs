using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Flow
{
    [AttributeUsage( AttributeTargets.Field | AttributeTargets.Property)]
    public class ArgumentAttribute:Attribute
    {
        public ArgumentAttribute(string path=null) {
            this.JPath = path;
        }

        public string JPath { get; private set; }
    }
}
