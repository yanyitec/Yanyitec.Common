using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Auth
{
    public interface IAuthPermissions :  IReadOnlyDictionary<string, IAuthPermission>,IEnumerable<IAuthPermission>
    {
        new IAuthPermission this[string key] { get; }
    }
}
