using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Runtime
{
    public interface IRuntimeUser :IUser
    {
        string Token { get;  }
        string ClientIp { get;  }
        IRuntimePermissions Permissions { get; }
        /// <summary>
        /// 代理人
        /// </summary>
        IUser Factor { get; }

        IDictionary<string, string> Data { get; }
    }
}
