using System;
using System.Collections.Generic;
using System.Text;
using Yanyitec.Auth;

namespace Yanyitec.Biz
{
    public interface IAccessToken
    {
        IAuthUser User { get; }
        IAuthPermission Permission { get; }
    }
}
