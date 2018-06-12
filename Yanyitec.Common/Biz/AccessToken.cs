using System;
using System.Collections.Generic;
using System.Text;
using Yanyitec.Runtime;

namespace Yanyitec.Biz
{
    public class AccessToken :IAccessToken
    {
        public IRuntimeUser User { get; set; }
        public IRuntimePermission Permission { get; set; }
    }
}
