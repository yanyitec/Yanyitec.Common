using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Flow.Defination
{
    public class Diagram : Element
    {
        public IList<Node> Nodes { get; set; }

        public IList<Association> Associations { get; set; }

        public Guid StartNodeId { get; set; }
        public Guid EndNodeId { get; set; }
    }
}
