using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.ORM
{
    public class FieldAttribute:Attribute
    {
        public FieldAttribute(string fieldname) {
            this.FieldName = fieldname;
        }
        public string FieldName { get; private set; }
    }
}
