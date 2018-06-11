using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Yanyitec.Repo
{
    public interface IRepository<T>: IRepository
        where T:class
    {
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="storagePartition"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(Guid id,string accessableFields=null ,string storagePartition = null);
        /// <summary>
        /// 新添实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="storagePartition"></param>
        /// <returns></returns>
        Task<T> CreateAsync(T entity, string accessableFields = null, string storagePartition= null);
        /// <summary>
        /// 修改实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="storagePartition"></param>
        /// <returns></returns>
        Task<T> ModifyAsync(T entity, string accessableFields = null, string storagePartition = null);
        /// <summary>
        /// 根据条件，获取列表
        /// 也可用于分页
        /// </summary>
        /// <param name="pageable"></param>
        /// <param name="storagePartition"></param>
        /// <returns></returns>

        Task<Pageable<T>> ListAsync(Pageable<T> pageable, string accessableFields = null, string storagePartition = null);
        /// <summary>
        /// 根据Id删除实体数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storagePartition"></param>
        /// <returns></returns>
        Task<T> DeleteByIdAsync(Guid id, string storagePartition = null);
        /// <summary>
        /// 删除实体数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="storagePartition"></param>
        /// <returns></returns>
        Task<T> DeleteAsync(T entity, string storagePartition = null);

    }
}
