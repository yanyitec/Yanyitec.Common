using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Flow.Storage
{
    public class ActivityEntity : Yanyitec.Repo.Record
    {
        public Guid NodeId { get; set; }
        public Guid WorkflowId { get; set; }

        public string Alias { get; set; }

        public ActivityStates Status { get; set; }

        public string Inputs { get; set; }

        public string Variables { get; set; }

        public string Outputs { get; set; }

        public string PrevActivityIds { get; set; }

        public DateTime FinishTime { get; set; }
        public Guid FinishorId { get; set; }

        public Guid FinishedBy { get; set; }

        public string FinishorInfo { get; set; }

        public DateTime DealTime { get; set; }
        public Guid DealerId { get; set; }

        public Guid DealedBy { get; set; }

        public string DealerInfo { get; set; }

        
        public Guid? OwnerId { get; set; }

        public Guid? OwnedBy { get; set; }

        public string OwnerInfo { get; set; }


    }
}
