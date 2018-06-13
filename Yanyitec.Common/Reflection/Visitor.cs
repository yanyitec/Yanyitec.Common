using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Reflection
{
    /// <summary>
    /// a,b,c{b,d,k{v,s}},e,f
    /// </summary>
    public class Visitor 
    {
        public Visitor(IProperty property, Visitor pvisitor) {
            this.Property = property;
            this.ParentVisitor = pvisitor;
            this.Subsidaries = new List<Visitor>();
        }

        

        public IProperty Property { get; private set; }

        public Visitor ParentVisitor { get;private set; }

        public IReadOnlyList<Visitor> Subsidaries { get; set; }

        string _Path;
        public string Path {
            get {
                if (_Path==null) {
                    if (this.ParentVisitor == null)
                    {
                        if (this.Property == null) return null;
                        _Path = this.Property.Name;
                    }
                    else {
                        _Path = this.ParentVisitor.Path + "." + this.Property.Name;
                    }
                }
                return _Path;
            }
        }

        public static Visitor Parse(string expr,IClass cls) {
            var parser = new VisitorParser();
            return parser.Parse(expr,cls);
        }
    }
}
