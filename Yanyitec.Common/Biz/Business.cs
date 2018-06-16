using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yanyitec.Repo;
using Yanyitec.Auth;

namespace Yanyitec.Biz
{
    public class Business<T> : IBiz<T>
        where T : class
    {
        public IRepository<T> Repository { get; set; }

        public virtual void Validate(T entity,string allowedFields) {
        }
        public virtual async Task<T> CreateAsync(IAccessToken accessToken, T entity)
        {
            this.Validate(entity,accessToken==null?null:(accessToken.Permission==null?null:accessToken.Permission.AllowedFields));
            
            return await this.Repository.CreateAsync(entity,new BizRepoContext(accessToken));
        }

        public virtual async Task<T> DeleteAsync(IAccessToken accessToken,Guid entityId)
        {
            return await this.Repository.DeleteByIdAsync(entityId, new BizRepoContext(accessToken));
        }

        public virtual async Task<Pageable<T>> ListAsync(IAccessToken accessToken, Pageable<T> pageable)
        {
            return await this.Repository.ListAsync(pageable,new BizRepoContext(accessToken));
        }

        public virtual async Task<T> ModifyAsync(IAccessToken accessToken,  T entity)
        {
            this.Validate(entity, accessToken == null ? null : (accessToken.Permission == null ? null : accessToken.Permission.AllowedFields));

            return await this.Repository.ModifyAsync(entity, new BizRepoContext(accessToken));
        }
    }
}
