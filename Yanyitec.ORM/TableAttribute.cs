using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.ORM
{
    public class TableAttribute : Attribute
    {
        public TableAttribute(string tableName) {
            this.TableName = tableName;
        }

        public string TableName { get; private set; }
    }
}
