using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Reflection
{
    public class Visitor
    {

        public IProperty Property { get; set; }

        public Visitor Parent { get; set; }

        public IDictionary<string,Visitor> Subsidaries { get; set; }

        string _Path;
        public string Path {
            get {
                if (_Path==null) {
                    if (this.Parent == null)
                    {
                        if (this.Property == null) return null;
                        _Path = this.Property.Name;
                    }
                    else {
                        _Path = this.Parent.Path + "." + this.Property.Name;
                    }
                }
                return _Path;
            }
        }
    }
}
