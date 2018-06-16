using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Yanyitec.Auth
{
    public interface IAuthPermission
    {
        Guid Id { get; }
        string ActionId { get; }
        AppliedScopes AppliedScope { get; }
        string AllowedFields { get; }
        IDictionary<string, string> Data { get; }
    }
}