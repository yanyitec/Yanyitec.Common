using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Auth
{
    public interface IAuthUser :IUser
    {
        string Token { get;  }
        string ClientIp { get;  }
        IAuthPermissions Permissions { get; }
        /// <summary>
        /// 代理人
        /// </summary>
        IUser Factor { get; }

        IDictionary<string, string> Data { get; }
    }
}
