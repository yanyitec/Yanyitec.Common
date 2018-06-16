using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yanyitec.Flow.Storage;
using Yanyitec.Auth;
using Yanyitec.Flow.Defination;

namespace Yanyitec.Flow
{
    public class Workflow :Activity
    {
        public Workflow(ActivityEntity entity):base(entity) {
            this.Workflow = this;
        }
        public Guid OriginalDiagramId { get; set; }
        public Diagram Diagram { get; set; } 

        public IReadOnlyList<Guid> CurrentActivityIds { get; set; }

        public IActivityFactory ActivityFactory { get; set; }

        public IActivityRepository ActivityRepository { get; set; }

        public IDiagramRepository DiagramRepository { get; set; }

        public override async Task<ActivityStates> ExecuteAsync(IAuthUser dealer)
        {
            var todos = await this.InitTodoListAsync(dealer);
            while (todos.Count > 0) {
                var activity = todos.Dequeue();
                var result = await this.ExecuteActivityAsync(activity,todos,dealer);
                if (result != ActivityStates.Dealing && result != ActivityStates.Finished) {
                    this.Status = result;
                }
                if (activity.Node.Id == this.Diagram.EndNodeId) {
                    this.Status = ActivityStates.Finished;
                    //handle finished
                    return this.Status;
                }
                
            }

            return this.Status = ActivityStates.Dealing;
        }

        async Task<Queue<Activity>> InitTodoListAsync(IAuthUser dealer) {
            var dealingActivityEntities = await this.ActivityRepository.ListDealingByFlowIdAndDealerIdAsync(this.Id,dealer.UserId);
            var todos = new Queue<Activity>();
            foreach (var entity in dealingActivityEntities)
            {
                var activity = this.ActivityFactory.Create(entity,this,dealer);
                todos.Enqueue(activity);
            }

            return todos;
        }
        async Task<ActivityStates> ExecuteActivityAsync(Activity activity, Queue<Activity> todos, IAuthUser dealer) {
            var result = await activity.ExecuteAsync(dealer);
            activity.Status = result;
            var entity = activity.UpdateEntity(dealer);
            
            await this.ActivityRepository.ModifyAsync(entity);

            var variables = this.Variables.MergeObject(activity.Outputs) as JObject;

            if (result == ActivityStates.Finished) {
                entity.FinishTime = DateTime.Now;
                entity.FinishorId = dealer.UserId;
                var rtUser = dealer as IAuthUser;
                if (rtUser != null) {
                    entity.FinishedBy = rtUser.Factor.UserId;
                } else {
                    entity.FinishedBy = dealer.UserId;
                }
                entity.FinishorInfo = dealer.UserInfo;

                var nextNodes = activity.MakeNextNodes();
                var nextActivityEntities = new List<ActivityEntity>();
                foreach (var node in nextNodes) {
                    var nextEntity = new ActivityEntity();
                    nextEntity.SetAssignedId(Guid.NewGuid());
                    nextEntity.Alias = activity.ContainerActivity.Alias + "/" + node.Alias;
                    nextEntity.CreateTime = nextEntity.ModifyTime = nextEntity.DealTime = DateTime.Now;
                    nextEntity.CreatorId = nextEntity.ModifierId = nextEntity.DealerId = dealer.UserId;
                    nextEntity.CreatedBy = nextEntity.ModifiedBy = nextEntity.DealedBy = dealer.Factor.UserId;
                    if (node.Imports == "*")
                    {
                        nextEntity.Inputs = variables.ToString();
                    }
                    else if(node.Imports!=null && node.Imports!=string.Empty){
                        var importSchema = JObject.Parse(node.Imports);
                        var inputs = variables.ConvertTo(importSchema);
                        nextEntity.Inputs = inputs.ToString();
                    }

                    await this.ActivityRepository.CreateAsync(nextEntity);
                    nextActivityEntities.Add(nextEntity);
                }             
                foreach (var nextActivityEntity in nextActivityEntities) {
                    var nextActivity = this.ActivityFactory.Create(nextActivityEntity, this,dealer);
                    todos.Enqueue(nextActivity);
                }
            }
            this.Variables = variables;
            return result;
        }
    }
}
