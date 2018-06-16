using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Auth
{

    public interface IAuthRole
    {

        Guid Id { get; set; }

        string SubsystemId { get; set; }

        string OrganizationId { get; set; }

        string DepartmentId { get; set; }

        IAuthRole InheritFrom { get; set; }
        

    }
}
