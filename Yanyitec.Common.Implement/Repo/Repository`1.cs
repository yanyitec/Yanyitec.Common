using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;


namespace Yanyitec.Repo
{
    public class Repository<T>: Repository<Guid,T>, IRepository<Guid,T>
        where T:class
    {
        public override async Task<T> GetByIdAsync(Guid id, string accessableFields = null, string storagePartition = null)
        {
            return await this.DbSet.FirstOrDefaultAsync(p=>(p as IEntity<Guid>).Id== id);
        }

        public override Task<T> CreateAsync(T entity, string accessableFields = null, string storagePartition = null)
        {
            if ((entity as IEntity).Id == Guid.Empty) (entity as IEntity).SetAssignedId(Guid.NewGuid());
            return base.CreateAsync(entity, accessableFields, storagePartition);
        }
    }
}
