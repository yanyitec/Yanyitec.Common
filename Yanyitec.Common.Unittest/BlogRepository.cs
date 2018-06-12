using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Yanyitec.Repo;
using Yanyitec.Unittest.Entities;

namespace Yanyitec.Unittest
{
    public class BlogRepository :Repository<string,Blog>
    {
        public BlogRepository() : base(new BlogDbContext()) {
        }
    }
}
