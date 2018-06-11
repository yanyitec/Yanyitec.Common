using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Yanyitec.ORM
{
    public interface IDatabase :IDisposable
    {
        string ConnectionString { get; }

        IDataReader ExecuteReader(string sql);

        IDbTransaction Transaction { get; }

        IDbTransaction BeginTran();


    }
}
