using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySqlDapper.Data.Interface
{
    public interface IRepositoryBase<T> : IDisposable
    {
        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        IList<T> GetAll();

        Task<IList<T>> GetAllAsync();

        long Insert(T entity);

        Task<long> InsertAsync(T entity);

        void Update(T entity);

        Task UpdateAsync(T entity);

        void Delete(T entity);

        Task DeleteAsync(T entity);

        T Query(string sql, object param);

        Task<T> QueryAsync(string sql, object param);

        IList<T> QueryToList(string sql, object param);

        Task<IList<T>> QueryToListAsync(string sql, object param);

        int ExecProc(string procName, object param);

        Task<int> ExecProcAsync(string procName, object param);
    }
}