using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Runtime
{
    [ProtoContract]
    public class RuntimeRole
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string SubsystemId { get; set; }
        [ProtoMember(3)]
        public string OrganizationId { get; set; }
        [ProtoMember(4)]
        public string DepartmentId { get; set; }
        [ProtoMember(5)]
        public RuntimeRole InheritFrom { get; set; }
        

    }
}
