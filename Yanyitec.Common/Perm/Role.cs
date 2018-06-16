using System;
using System.Collections.Generic;
using System.Text;
using Yanyitec.Repo;

namespace Yanyitec.Perm
{
    public class Role : Record
    {
        public RoleTypes RoleType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid? DepartmentId { get; set; }

        public Guid? JobId { get; set; }

        public Guid? PositionId { get; set; }

        public Guid? SystemId { get; set; }
    }
}
