using Rabobank.GCOB.Domain.Interfaces.Models;
using Rabobank.GCOB.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabobank.GCOB.Domain.Implementation.Interface
{
    #region Implementation for crud operations, generic repository class, this class invokes DB context class for Entity framework
    public class Repository<T> : IRepository<T> where T : class
    {
        //private DBContext _dbContext=null;

        public Repository()
        {
            //this._dbContext = new DBContext();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="itemToUpdate"></param>
        /// <returns></returns>
        public async Task<bool> Delete(T itemToUpdate)
        {
            throw new NotImplementedException();
        }
         
        /// <summary>
        /// Get all objects
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get object by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<T> GetById(T Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="itemToUpdate"></param>
        /// <returns></returns>
        public async Task<bool> Insert(T itemToUpdate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Save db context
        /// </summary>
        /// <param name="itemToUpdate"></param>
        /// <returns></returns>
        public async Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="itemToUpdate"></param>
        /// <returns></returns>
        public async Task<bool> Update(T itemToUpdate)
        {
            //throw new NotImplementedException();

            return true;
        }
    }
} 
#endregion
