using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace VesNing.EdutureCore.MiniORM
{
    /// <summary>
    /// ORM的操作类
    /// 实体类可以是多个的
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbEntity<T> : IEnumerable<T>
    {
        #region 字段定义
        private string connectionString;
        private static string tableName = string.Empty;
        private static IDictionary<PropertyInfo, string> 
            filedColumnDict = new Dictionary<PropertyInfo, string>();
        #endregion

        #region 构造函数
        public DbEntity(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion

        #region 初始化字段
        /// <summary>
        ///   //进行实体类的字段同数据库的列明进行绑定
        /// </summary>
        public static void InitDbFildInfo<TEntity>(EntityMappingInfo<TEntity> mapInfo) where TEntity : class
        {
            Type type = typeof(TEntity);
            tableName = mapInfo.TableName;
            //表名
            if (tableName.Length == 0)
            {
                tableName = type.Name;
            }
            //数据列
            foreach (EntityFiledMappingInfo<TEntity> item in mapInfo?.EntityFildMappingList)
            {
                PropertyInfo propertyInfo = type.GetProperty(item.EntityFiledName);

                if (propertyInfo == null)
                {
                    continue;
                }
                if (!filedColumnDict.Keys.Contains(propertyInfo))
                {
                    filedColumnDict.Add(propertyInfo, item.ColumnName);
                  
                }
            }
            type.GetProperties().
                Where(info => !filedColumnDict.Keys.Contains(info)).
                ToList<PropertyInfo>().
                ForEach(u =>
                {
                    if (!filedColumnDict.Keys.Contains(u))
                    {
                        filedColumnDict.Add(u, u.Name);
                    }
                });
        }
        #endregion

        #region Insert
        public void Insert(T t)
        {
            string sql = "insert into {0}({1}) values({2})";
            List<string> clmBuilder = new List<string>();
            List<object> values = new List<object>();
            foreach (PropertyInfo info in filedColumnDict.Keys)
            {
                clmBuilder.Add(string.Format(" {0} ", filedColumnDict[info]));
                if (info.PropertyType == typeof(string) || info.PropertyType == typeof(DateTime))
                {

                    values.Add("'" + info.GetValue(t) + "'");
                }
                else
                {
                    values.Add(info.GetValue(t));
                }
            }
            sql = string.Format(sql, tableName, string.Join(",", clmBuilder), string.Join(",", values));
            Console.WriteLine(sql);
        }
        #endregion

        #region 可枚举
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
