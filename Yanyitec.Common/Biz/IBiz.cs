using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yanyitec.Runtime;

namespace Yanyitec.Biz
{
    public interface IBiz<T>
        where T:class
    {
        Task<T> CreateAsync(IRuntimeUser user, IRuntimePermission permission,T entity,string[] validateFields=null,string storagePartition=null);

        Task<T> ModifyAsync(T entity, IRuntimeUser user, IRuntimePermission permission, string[] validateFields = null, string storagePartition = null);

        Task<T> DeleteAsync(Guid entityId, IRuntimeUser user, IRuntimePermission permission, string[] validateFields = null, string storagePartition = null);

        Task<Pageable<T>> ListAsync(Pageable<T> pageable, IRuntimeUser user, IRuntimePermission permission, string[] validateFields = null, string storagePartition = null);
    }
}
