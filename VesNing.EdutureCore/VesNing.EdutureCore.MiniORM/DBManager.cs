using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
/// <summary>
/// 数据库的CRUD
/// </summary>
namespace VesNing.EdutureCore.MiniORM
{
    /// <summary>
    /// 数据库的操作
    /// </summary>
    public class DBManager
    {
        #region 字段定义
        /// <summary>
        /// 数据库链接字符串
        /// </summary>
        private string connectionString = string.Empty;
        #endregion

        #region 属性定义
        #endregion

        #region 构造函数
        public DBManager(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion

        public virtual void OnModelBuilder<T>(EntityMappingInfo<T> mapInfo)where T:class
        {
            DbEntity<T>.InitDbFildInfo<T>(mapInfo);
        }

        #region 获取实体类
        public DbEntity<T> Entity<T>() where T:class
        {
            return new DbEntity<T>(this.connectionString);
        }

        #endregion
    }
}
