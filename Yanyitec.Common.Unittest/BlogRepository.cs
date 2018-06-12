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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db/blog.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().ToTable("Blog");//.HasKey(p=>p.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
