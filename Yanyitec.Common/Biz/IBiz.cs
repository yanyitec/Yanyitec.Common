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
        Task<T> CreateAsync(IAccessToken accessToken, T entity);

        Task<T> ModifyAsync(IAccessToken accessToken, T entity);

        Task<T> DeleteAsync(IAccessToken accessToken,Guid entityId);

        Task<Pageable<T>> ListAsync(IAccessToken accessToken, Pageable<T> pageable);
    }
}
