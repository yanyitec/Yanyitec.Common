using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Flow
{
    public enum ActivityStates
    {
        Defined=0,
        Dealing,
        Finished,
        Ignore=3,
        Aborted =-2,
        Error =-1
    }
}
