using System;

namespace Yanyitec
{
    public interface IEntity
    {
        Guid Id { get; }

        void SetAssignedId(Guid id);
        
        
    }
}