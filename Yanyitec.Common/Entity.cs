using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec
{
    public class Entity : IEntity
    {
        public Guid Id { get; protected set; }

        public void SetAssignedId(Guid id) { this.Id = id; }
        
        
        
    }
}
