using System;
using System.Collections.Generic;
using System.Text;
using Yanyitec.Auth;

namespace Yanyitec.Biz
{
    public class AccessToken :IAccessToken
    {
        public IAuthUser User { get; set; }
        public IAuthPermission Permission { get; set; }
    }
}
