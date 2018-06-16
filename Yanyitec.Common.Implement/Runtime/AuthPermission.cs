using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Auth
{
    [ProtoContract]
    public class AuthPermission : IAuthPermission
    {
        //public AuthPermission(Permission perm) {
        //    this.Id = perm.Id;
        //    this.ActionId = perm.ActionId;
        //    this.Data = JObject.Parse(perm.DataInfo);
        //    this.ValidateFields = JsonConvert.DeserializeObject<string[]>(perm.ValidateFieldsInfo);
        //}
        [ProtoMember(1)]
        public Guid Id { get; set; }
        [ProtoMember(2)]
        public string ActionId { get;  set; }
        [ProtoMember(3)]
        public AppliedScopes AppliedScope { get; set; }
        [ProtoMember(4)]
        public string AllowedFields { get; set; }
        [ProtoMember(5)]
        public IDictionary<string,string> Data { get; set; }
        
    }
}
