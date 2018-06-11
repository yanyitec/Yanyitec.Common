using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Repo
{
    public interface IRepository : IDisposable
    {
        ITransaction BeginTran();
        bool IsInTransaction { get; }
    }
}
