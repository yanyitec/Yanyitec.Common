using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;


namespace Yanyitec.Repo
{
    public class Repository<TID,TEntity>: Repository, IRepository<TID,TEntity>
        where TEntity:class
    {
        public DbSet<TEntity> DbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TEntity>().HasKey(p=>(p as IEntity<TID>).Id);
            base.OnModelCreating(modelBuilder);
        }




        public virtual async Task<TEntity> CreateAsync(TEntity entity, string accessableFields = null, string storagePartition = null)
        {
            await this.DbSet.AddAsync(entity);
            var count = await this.SaveChangesAsync();
            return count ==1?entity:default(TEntity);
        }

        public async Task<Pageable<TEntity>> ListAsync(Pageable<TEntity> pageable, string accessableFields = null, string storagePartition = null)
        {
            var expr = pageable.Expression;
            IQueryable<TEntity> query = this.DbSet;
            if (expr != null)
            {
                query = query.Where(expr);
            }

            long count = 0;
            if (pageable.PageSize != 0)
            {
                if (expr != null)
                {
                    //query = this.DbSet.Where(expr);
                }
                else
                {
                    //query = this.DbSet;
                }
                count = await query.LongCountAsync();
                pageable.RecordCount = count;
                if (count == 0) return pageable;
                
            }
            //query = DbSet;
            if (pageable.Asc != null)
            {
                query = query.OrderBy(pageable.Asc);
            }
            else if (pageable.Desc != null)
            {
                query = query.OrderByDescending(pageable.Desc);
            }

            if (pageable.PageSize > 0)
            {
                int pageSize = (int)pageable.PageSize;
                var pageCount = count / pageSize;
                if (count % pageSize > 0) pageCount++;
                pageable.PageCount = pageCount;
                var pageIndex = pageable.PageIndex;
                if (pageIndex == 0) pageable.PageIndex = 1;
                if (pageIndex > pageCount) pageIndex = pageable.PageIndex = pageCount;
                int skip = (int)((pageIndex - 1) * pageSize);
                query = query.Skip(skip).Take(pageSize);
            }
            
            

            pageable.Items = await query.ToListAsync();
            return pageable;

        }

        public async Task<TEntity> ModifyAsync(TEntity entity, string accessableFields = null, string storagePartition = null)
        {
            //this.DbSet.Attach(entity);
            var trace = this.DbSet.Update(entity);
            //trace.State = EntityState.Modified;
            var count = await this.SaveChangesAsync();
            return count==1?entity:default(TEntity);
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, string storagePartition = null)
        {
            //this.DbSet.Attach(entity);
            var trace = this.DbSet.Remove(entity);
            var count = await this.SaveChangesAsync();
            return count==1?entity:default(TEntity);
        }

        public async Task<TEntity> DeleteByIdAsync (TID id, string storagePartition = null)
        {
            var entity = await this.GetByIdAsync(id,storagePartition);
            if (entity == null) return default(TEntity);
            return await this.DeleteAsync(entity);
        }

        

        public virtual async Task<TEntity> GetByIdAsync(TID id, string accessableFields = null, string storagePartition = null) {
            return await this.DbSet.FirstOrDefaultAsync(entity=>(entity as IEntity<TID>).Id.Equals(id));
        }
    }
}
