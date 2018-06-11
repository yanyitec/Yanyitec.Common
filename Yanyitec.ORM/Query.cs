using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Yanyitec.ORM
{
    public class Query<T> : Criteria<T>
        where T:class
    {
        public Query(Entity<T> entity){
            this.Entity = entity;
        }
        public Entity<T> Entity { get; private set; }

        public Query<T> Where(Expression<Func<T, bool>> initCriteria = null) {
            this.Parameter = initCriteria.Parameters[0];
            this._Expression = initCriteria.Body;

            return this;
            
        }

    }
}
