using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Runtime
{

    public interface IRuntimeRole
    {

        Guid Id { get; set; }

        string SubsystemId { get; set; }

        string OrganizationId { get; set; }

        string DepartmentId { get; set; }

        IRuntimeRole InheritFrom { get; set; }
        

    }
}
