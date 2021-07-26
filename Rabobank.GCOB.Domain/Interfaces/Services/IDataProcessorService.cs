using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabobank.GCOB.Domain.Interfaces.Services
{
    #region Interface for Data processor service
    public interface IDataProcessorService
    {
        Task<bool> ProcessData();
    } 
    #endregion
}
