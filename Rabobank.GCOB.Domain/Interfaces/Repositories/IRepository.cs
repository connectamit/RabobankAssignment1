namespace Rabobank.GCOB.Domain.Interfaces.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(T Id);

        Task<bool> Update(T itemToUpdate);

        Task<bool> Insert(T itemToUpdate);

        Task<bool> Delete(T itemToUpdate);

        Task<bool> Save();
    }
}
