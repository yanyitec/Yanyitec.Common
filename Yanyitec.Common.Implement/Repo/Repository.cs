using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yanyitec.Repo
{
    public class Repository :  IRepository
    {
        public Repository(DbContext dbContext) : base() {
            this.DbContext = dbContext;
            //DbContext.SaveChangesAsync();
        }
        public DbContext DbContext { get; private set; }
        

        protected async Task<int> SaveChangesAsync() {
            return await this.DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.DbContext.Dispose();
        }
    }
}
