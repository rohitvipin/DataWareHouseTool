using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataWareHouseTool.DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IDbConnection DbConnection { get; set; }

        Task<IEnumerable<T>> Get();

        Task<T> GetById(int id);

        Task<bool> Insert(T item);

        Task<bool> Update(T item);

        Task<bool> Delete(int id);
    }
}