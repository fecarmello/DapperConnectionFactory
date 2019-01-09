using System;
using System.Data;

namespace MySqlDapper.Data
{
    public interface IConnectionManager : IDisposable
    {
        IDbConnection GetConnection();

        IDbTransaction GetTransaction();

        void OpenConnection();

        bool IsInTransaction();

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}