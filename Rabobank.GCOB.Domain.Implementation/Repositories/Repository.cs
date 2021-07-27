namespace Rabobank.GCOB.Domain.Implementation.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Rabobank.GCOB.Domain.Interfaces.Repositories;

    public class Repository<T> : IRepository<T> where T : class
    {
        // private DBContext _dbContext=null;
        public Repository()
        {
            // this._dbContext = new DBContext();
        }

        /// <summary>
        /// Delete the object.
        /// </summary>
        /// <param name="itemToUpdate"> passing the object to delete record. </param>
        /// <returns>A <see cref="Task"/>returns true or false.</returns>
        public async Task<bool> Delete(T itemToUpdate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all objects.
        /// </summary>
        /// <returns>A <see cref="Task"/> returns list list of objects.</returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get object by id.
        /// </summary>
        /// <param name="itemToUpdate"> passing the object to get single record. </param>
        /// <returns>A <see cref="Task"/> returns object.</returns>
        public async Task<T> GetById(T Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert the object.
        /// </summary>
        /// <param name="itemToUpdate"> passing the object to insert. </param>
        /// <returns>A <see cref="Task"/> returns true or false.</returns>
        public async Task<bool> Insert(T itemToUpdate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Save db context.
        /// </summary>
        /// <returns>A <see cref="Task"/> returns true or false.</returns>
        public async Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update the object.
        /// </summary>
        /// <param name="itemToUpdate"> passing the object to update. </param>
        /// <returns>A <see cref="Task"/> returns true or false.</returns>
        public async Task<bool> Update(T itemToUpdate)
        {
            try
            {
               return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(AppConstants.CustomExceptionMessageUpdate, ex);
            }
        }
    }
}