using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Runtime
{
    public interface IRuntimePermissions :  IReadOnlyDictionary<string, IRuntimePermission>,IEnumerable<IRuntimePermission>
    {
        new IRuntimePermission this[string key] { get; }
    }
}
