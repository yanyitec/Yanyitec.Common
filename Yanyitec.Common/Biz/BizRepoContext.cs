using System;
using System.Collections.Generic;
using System.Text;
using Yanyitec.Repo;
using Yanyitec.Runtime;

namespace Yanyitec.Biz
{
    public class BizRepoContext :RepoContext
    {
        public BizRepoContext(IAccessToken accessToken) {
            this.AccessToken = accessToken;
        }

        public IAccessToken AccessToken { get; private set; }
        public IRuntimeUser User { get { return this.AccessToken == null ? null : this.AccessToken.User; } }
        public IRuntimePermission Permission { get { return this.AccessToken == null ? null : this.AccessToken.Permission; } }

        public override string AllowedFields {
            get {
                return this.Permission == null ? null : this.Permission.AllowedFields;
            }
            set {
                throw new InvalidOperationException("BizRepoContext.set_AllowedFields is invalid Operation");
            }
        }
    }
}
