using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Unittest.Entities
{
    public class Blog :Entity<string>
    {
        public Blog() { }
        public Blog(string id) {
            this.SetAssignedId(id);
        }

        public Blog(Guid id)
        {
            this.SetAssignedId(id.ToString());
        }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }
}
