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
# region DataProcessorService is the Service class, it is the business layer class which is invoked in controller/api and also used in unit test.
    public class DataProcessorService : ProcessClientData, IDataProcessorService
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
        /// Process data is the main method for reading the data from the file and saving it in database
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ProcessData()
        {
            try
            {
                var file = (new ReadData()).GetData();

                Client client = null;
                string roboticsResult = null;
                var files = file.Skip(1);

                foreach (var line in files)
                {

                    client = OperateClientData(line).Result;

                    if (string.Compare(line[0], "LegalEntity", true) == 0 && client.Turnover> 1000000)
                    {
                        roboticsResult = Robotics.ScreeningAsync(client.FullName, client.Address.Country).Result;
                    }

                    if (roboticsResult != "Failed" && client != null)
                        await _irepository.Update(client);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    } 
    #endregion
}
