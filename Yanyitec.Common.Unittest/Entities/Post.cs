using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Unittest.Entities
{
    public class Post : Entity<string>
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
