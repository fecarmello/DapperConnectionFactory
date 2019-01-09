using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MySqlDapper.Data.Repository
{
    using MySqlDapper.Data.Interface;
    using System.Threading.Tasks;

    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        private IConnectionManager _connectionManager { get; set; }

        public RepositoryBase(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
            _connectionManager.OpenConnection();
        }

        public void Delete(T entity)
        {
            _connectionManager.GetConnection().Delete(entity, _connectionManager.GetTransaction());
        }

        public Task DeleteAsync(T entity)
        {
            return _connectionManager.GetConnection().DeleteAsync(entity, _connectionManager.GetTransaction());
        }

        public void Dispose()
        {
        }

        public int ExecProc(string procName, object param)
        {
            return _connectionManager.GetConnection().Execute(procName, param, _connectionManager.GetTransaction(), commandType: CommandType.StoredProcedure);
        }

        public Task<int> ExecProcAsync(string procName, object param)
        {
            return _connectionManager.GetConnection().ExecuteAsync(procName, param, _connectionManager.GetTransaction(), commandType: CommandType.StoredProcedure);
        }

        public IList<T> GetAll()
        {
            return _connectionManager.GetConnection().GetAll<T>(_connectionManager.GetTransaction()).ToList();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return _connectionManager.GetConnection().GetAllAsync<T>(_connectionManager.GetTransaction()).Result.ToList();
        }

        public T GetById(int id)
        {
            return _connectionManager.GetConnection().Get<T>(id, _connectionManager.GetTransaction());
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _connectionManager.GetConnection().GetAsync<T>(id, _connectionManager.GetTransaction());
        }

        public long Insert(T entity)
        {
            return _connectionManager.GetConnection().Insert(entity, _connectionManager.GetTransaction());
        }

        public async Task<long> InsertAsync(T entity)
        {
            return await _connectionManager.GetConnection().InsertAsync(entity, _connectionManager.GetTransaction());
        }

        public T Query(string sql, object param)
        {
            return _connectionManager.GetConnection().QueryFirstOrDefault<T>(sql, param, _connectionManager.GetTransaction());
        }

        public Task<T> QueryAsync(string sql, object param)
        {
            return _connectionManager.GetConnection().QueryFirstOrDefaultAsync<T>(sql, param, _connectionManager.GetTransaction());
        }

        public IList<T> QueryToList(string sql, object param)
        {
            return _connectionManager.GetConnection().Query<T>(sql, param, _connectionManager.GetTransaction()).ToList();
        }

        public async Task<IList<T>> QueryToListAsync(string sql, object param)
        {
            return _connectionManager.GetConnection().QueryAsync<T>(sql, param, _connectionManager.GetTransaction()).Result.ToList();
        }

        public void Update(T entity)
        {
            _connectionManager.GetConnection().Update(entity, _connectionManager.GetTransaction());
        }

        public Task UpdateAsync(T entity)
        {
            return _connectionManager.GetConnection().UpdateAsync(entity, _connectionManager.GetTransaction());
        }
    }
}