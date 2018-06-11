using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yanyitec.Repo;

namespace Yanyitec.Flow.Storage
{
    public interface IActivityRepository : IRepository<ActivityEntity>
    {
        Task<IList<ActivityEntity>> ListByIdsAsync(IEnumerable<Guid> ids,string accessFields=null,string storagePartition = null);
        Task<IList<ActivityEntity>> ListDealingByFlowIdAndDealerIdAsync(Guid flowId,Guid dealerId, string accessFields = null, string storagePartition = null);
    }
}
