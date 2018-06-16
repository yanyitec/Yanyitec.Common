using System;
using System.Collections.Generic;
using System.Text;
using Yanyitec.Repo;

namespace Yanyitec.Perm
{
    public class Permission :Record
    {
        public string SvcId { get; set; }
        public string ActionId { get; set; }
        public Guid RoleId { get; set; }

        public string DataInfo { get; set; }
    }
}
