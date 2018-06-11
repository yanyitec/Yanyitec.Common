using System;
using System.Collections.Generic;
using System.Text;
using Yanyitec.Flow.Storage;
using Yanyitec.Runtime;

namespace Yanyitec.Flow
{
    public interface IActivityFactory
    {
        Activity Create(ActivityEntity entity,Workflow flow,IUser dealer);
        
    }
}
