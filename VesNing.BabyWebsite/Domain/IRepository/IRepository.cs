using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    /// <summary>
    /// 常用方法接口
    /// </summary>
  public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="obj">存储的实体</param>
        /// <returns>影响的行数</returns>
        long SaveEntity(T obj);
        /// <summary>
        /// 根据主键ID获取实体数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntity(string id);
        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="obj">实体</param>
        /// <returns></returns>
        bool UpdateEntity(T obj);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Delete(T obj);

        #region 异步
       
        #endregion
    }
}