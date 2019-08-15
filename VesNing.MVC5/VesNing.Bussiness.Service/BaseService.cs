using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VesNing.Bussiness.Interface;

namespace VesNing.Bussiness.Service
{
   public class BaseService: IBaseService
    {
        #region 字段定义
        protected DbContext dbContext;
        #endregion

        #region 构造函数
        public BaseService(DbContext dbContext)
        {
              this.dbContext = dbContext;
            //进行日志打印
            this.dbContext.Database.Log += (msg) => Console.WriteLine(msg);
          
        }
        #endregion

        #region 查询
        [Obsolete("尽量不要使用此方法")]
        public IQueryable<T> Set<T>() where T : class
        {
            return this.dbContext.Set<T>();
        }

        public T Find<T>(int id) where T : class
        {
           return  this.dbContext.Set<T>().Find(id);
        }
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
           return this.dbContext.Set<T>().Where<T>(funcWhere);
        }

        public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class
        {
            var list = this.Set<T>();
            if (funcWhere != null)
            {
                list = list.Where<T>(funcWhere);
            }
            if (isAsc)
            {
                list = list.OrderBy(funcOrderby);
            }
            else
            {
                list = list.OrderByDescending(funcOrderby);
            }
            PageResult<T> result = new PageResult<T>()
            {
                DataList = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = this.dbContext.Set<T>().Count(funcWhere)
            };
            return result;
        }

        #endregion

        #region 增加
        public T Insert<T>(T t) where T : class
        {
            this.dbContext.Set<T>().Add(t);
            this.Commit();
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            this.dbContext.Set<T>().AddRange(tList);
            this.Commit();
            return tList;
        }
        #endregion

        #region 删除
        public void Delete<T>(int Id) where T : class
        {
            T obj = this.Find<T>(Id);
            if (obj != null)
            {
                this.dbContext.Set<T>().Remove(obj);
            }
            this.Commit();
        }

        public void Delete<T>(T t) where T : class
        {
            this.dbContext.Set<T>().Attach(t);//进行状态跟踪
            this.dbContext.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                this.dbContext.Set<T>().Attach(t);//进行状态跟踪
            }
            this.dbContext.Set<T>().RemoveRange(tList);
            this.Commit();
        }
        #endregion

        #region 更新
        public void Update<T>(T t) where T : class
        {
            //将数据附加到上下文，支持实体修改和新实体，重置为UnChanged
            this.dbContext.Set<T>().Attach(t);
            this.dbContext.Entry<T>(t).State = EntityState.Modified;//全字段更新
            this.Commit();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            foreach (T t in tList)
            {
                this.dbContext.Set<T>().Attach(t);
                this.dbContext.Entry<T>(t).State = EntityState.Modified;//全字段更新
            }
            this.Commit();
        }
        #endregion

        #region 数据库执行
        public void Excute<T>(string sql, SqlParameter[] parameters) where T : class
        {
            Database db = this.dbContext.Database;
            DbContextTransaction transaction= db.BeginTransaction();
            try
            {
                db.ExecuteSqlCommand(sql,parameters);
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] parameters) where T : class
        {
           return  this.dbContext.Database.SqlQuery<T>(sql,parameters).AsQueryable();
        }
        #endregion

        #region 其他
        /// <summary>
        /// 提交
        /// </summary>
        public void Commit()
        {
            dbContext.SaveChanges();
        }
        /// <summary>
        /// 可以使用using语法糖
        /// </summary>
        public void Dispose()
        {
            if (dbContext != null)
            {
                this.dbContext.Dispose();
            }
        }
        #endregion
    }
}
