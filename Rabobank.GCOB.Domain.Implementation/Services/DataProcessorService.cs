using Rabobank.GCOB.Domain.Implementation.Helper;
using Rabobank.GCOB.Domain.Interfaces.Models;
using Rabobank.GCOB.Domain.Interfaces.Repositories;
using Rabobank.GCOB.Domain.Interfaces.Services;
using Rabobank.GCOB.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabobank.GCOB.Domain.Implementation.Services
{
    #region DataProcessorService is the Service class, it is the business layer class which is invoked in controller/api and also used in unit test.
    public class DataProcessorService : ClientDataReader, IDataProcessorService
    {
        /// <summary>
        /// Private variable of irepository for dependency injection
        /// </summary>
        private readonly IRepository<Interfaces.Models.Client> _irepository;

        /// <summary>
        /// Construtor for dependency injection of repository
        /// </summary>
        /// <param name="irepository"></param>
        public DataProcessorService(IRepository<Interfaces.Models.Client> irepository)
        {
            this._irepository = irepository;
        }

        /// <summary>
        /// This method is used for reading the data from the file and saving it in database
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ProcessData()
        {
            try
            {
                Client client = null;
                string roboticsResult = null;

                var files = (new ReadData()).GetData().Skip(1);

                foreach (var line in files)
                {

                    client = OperateClientData(line); ;

                    if (string.Compare(line[0], AppConstants.LegaEntity, true) == 0 && client.Turnover > 1000000)
                    {
                        roboticsResult =await Robotics.ScreeningAsync(client.FullName, client.Address.Country);
                    }

                    if (roboticsResult != AppConstants.RoboticsResultFailed)
                        await _irepository.Update(client);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(AppConstants.CustomExceptionMessageProcessingData, ex);
            }
        }
    }
    #endregion
}
