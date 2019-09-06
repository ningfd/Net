using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace VesNing.EdutureCore.MiniORM
{
    /// <summary>
    /// 实体类与数据库的字段映射关系
    /// </summary>
    public class EntityMappingInfo<T>
    {
        #region 字段定义
        private Type entityType;
        private List<EntityFiledMappingInfo<T>> _EntityFiledList = new List<EntityFiledMappingInfo<T>>();
        private string tableName;
        #endregion

        #region 属性定义
        public Type EntityType
        {
            get
            {
                return this.entityType;
            }
        }

        public string TableName
        {
            get
            {
                return this.tableName;
            }

        }
        public List<EntityFiledMappingInfo<T>> EntityFildMappingList
        {
            get
            {
                return this._EntityFiledList;
            }
        }

        #endregion

        #region 构造函数
        public EntityMappingInfo()
        {
            this.entityType = typeof(T);
        }
        #endregion

        public EntityMappingInfo<T> ToTable(string tableName)
        {
            this.tableName = tableName;
            return this;
        }
        public EntityMappingInfo<T> Property(Action<EntityFiledMappingInfo<T>> entityFiledAction)
        {
            EntityFiledMappingInfo<T> entityFild = new EntityFiledMappingInfo<T>();
            entityFiledAction(entityFild);
            this._EntityFiledList.Add(entityFild);
            return this;
        }
        public override string? ToString()
        {
            string result = string.Empty;
            result = $"Enity:{this.entityType},TableName:{this.tableName}\r\n";
            foreach (EntityFiledMappingInfo<T> item in this._EntityFiledList)
            {
                result += $"File:{item.EntityFiledName},ColumnName:{item.ColumnName}\r\n";
            }
            return result;
        }
    }
    public class EntityFiledMappingInfo<T>
    {
        private string _entityFiledName;
        private string _columnName;

        public string EntityFiledName
        {
            get { return this._entityFiledName; }
        }
        public string ColumnName
        {
            get { return this._columnName; }
        }

        public EntityFiledMappingInfo<T> GetEntityProperty(Expression<Func<T, int>> entityFiled)
        {
            return GetEntityProperty(entityFiled.ToString());
        }
        public EntityFiledMappingInfo<T> GetEntityProperty(Expression<Func<T, string>> entityFiled)
        {
            return GetEntityProperty(entityFiled.ToString());
        }
        public EntityFiledMappingInfo<T> GetEntityProperty(Expression<Func<T, DateTime>> entityFiled)
        {
            return GetEntityProperty(entityFiled.ToString());
        }
        public EntityFiledMappingInfo<T> GetEntityProperty(Expression<Func<T, decimal>> entityFiled)
        {
            return GetEntityProperty(entityFiled.ToString());
        }
        private EntityFiledMappingInfo<T> GetEntityProperty(string expressionString)
        {
            if (!expressionString.Contains('.'))
            {
                return this;
            }
            this._entityFiledName = expressionString.Split(".")[1];
            return this;
        }
        public void ToCloumn(string coloumnName)
        {
            if (this._entityFiledName.Length==0)
            {
                return;
            }
            this._columnName = coloumnName;
        }
    }

}
