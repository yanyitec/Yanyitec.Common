using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yanyitec.Flow.Storage;
using Yanyitec.Flow.Defination;
using Yanyitec.Auth;

namespace Yanyitec.Flow
{
    public abstract class Activity
    {
        public Activity(ActivityEntity entity,Workflow workflow=null) {
            this.Workflow = workflow;
            this.Id = entity.Id;
            this.Alias = entity.Alias;
            this.Entity = entity;
            this.Variables = entity.Variables == null ? JObject.Parse(entity.Inputs) : JObject.Parse(entity.Variables);
            this.Outputs = entity.Outputs == null ? new JObject() : JObject.Parse(entity.Outputs);
        }

        public ActivityEntity Entity { get; private set; }
        
        public Guid Id { get; private set; } 

        public string Alias { get; private set; }

        public Workflow Workflow { get;internal set; }

        public Node Node { get; private set; }
        public JObject Variables { get;internal set; }

        public JObject Outputs { get; private set; }

        
        public Guid? OwnerId { get; protected set; }

        public IReadOnlyList<Guid> PrevActivityIds { get;private set; }

        public IReadOnlyList<Guid> NextActivityIds { get;private set; }

        public Activity ContainerActivity { get;private set; }

        public ActivityStates Status { get; internal set; }

        public abstract Task<ActivityStates> ExecuteAsync(IAuthUser dealer);

        protected internal virtual ActivityEntity UpdateEntity(IAuthUser dealer) {
            this.Entity.Variables = this.Variables.ToString();
            this.Entity.Outputs = this.Outputs.ToString();
            this.Entity.Status = this.Status;
            this.Entity.DealedBy = dealer.UserId;
            this.Entity.DealerInfo = dealer.UserInfo;
            this.Entity.DealTime = DateTime.Now;
            return this.Entity;

        }

        internal protected virtual IList<Node> MakeNextNodes() {
            return this.Workflow.Diagram.FindNextNodes(this.Node.Id);
        }
    }
}
