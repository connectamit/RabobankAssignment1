using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabobank.GCOB.Domain.Interfaces.Repositories
{
    #region Interface for generic repository
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(T Id);
        Task<bool> Update(T itemToUpdate);
        Task<bool> Insert(T itemToUpdate);
        Task<bool> Delete(T itemToUpdate);
        Task<bool> Save();
    } 
    #endregion
}
