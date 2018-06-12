using System;
using System.Collections.Generic;
using System.Text;
using Yanyitec.Runtime;

namespace Yanyitec.Biz
{
    public interface IAccessToken
    {
        IRuntimeUser User { get; }
        IRuntimePermission Permission { get; }
    }
}
