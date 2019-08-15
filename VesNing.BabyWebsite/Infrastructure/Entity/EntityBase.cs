using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entity
{
    public abstract class EntityBase<TKey>
    {
        protected EntityBase(TKey id)
        {
            this.Id = id;
        }
        public TKey Id
        {
            get;
            set;
        }
    }
    public class EntityBase:EntityBase<Guid>
    {
        public EntityBase(Guid id):base(id)
        {

        }
    }
}
