using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Accessor
{
    public class Visitor
    {
        public IObjectAccessor ObjectAccessor { get; set; }

        public IPropertyAccessor MemberAccessor { get; set; }

        public Visitor Parent { get; set; }

        public object Value { get; set; }

        string _Path;
        public string Path {
            get {
                if (_Path==null) {
                    if (this.Parent == null)
                    {
                        _Path = this.MemberAccessor.Name;
                    }
                    else {
                        _Path = this.Parent.Path + "." + this.MemberAccessor.Name;
                    }
                }
                return _Path;
            }
        }
    }
}
