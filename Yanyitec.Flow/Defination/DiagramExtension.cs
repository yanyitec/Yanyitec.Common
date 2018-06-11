using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Yanyitec.Flow.Defination
{
    public static class DiagramExtension
    {
        public static Node GetNodeById(this Diagram diagram, Guid nodeid) {
            return diagram.Nodes.FirstOrDefault(p=>p.Id == nodeid);
        }

        public static IList<Node> FindNextNodes(this Diagram diagram, Guid currentNodeId) {
            var assocs = diagram.Associations.Where(p=>p.From == currentNodeId);
            var list = new List<Node>();
            foreach (var assoc in assocs) {
                var node = diagram.Nodes.FirstOrDefault(p=>p.Id == assoc.To);
                list.Add(node);
            }
            return list;
        }
    }
}
