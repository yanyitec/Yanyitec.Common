using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Yanyitec.Runtime
{
    public interface IRuntimePermission
    {
        Guid Id { get; }
        string ActionId { get; }
        AppliedScopes AppliedScope { get; }
        string AllowedFields { get; }
        IDictionary<string, string> Data { get; }
    }
}