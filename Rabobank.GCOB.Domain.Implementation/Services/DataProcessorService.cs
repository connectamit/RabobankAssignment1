namespace Rabobank.GCOB.Domain.Implementation.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Rabobank.GCOB.Domain.Implementation.Helper;
    using Rabobank.GCOB.Domain.Interfaces.Models;
    using Rabobank.GCOB.Domain.Interfaces.Repositories;
    using Rabobank.GCOB.Domain.Interfaces.Services;
    using Rabobank.GCOB.External;

    public class DataProcessorService : ClientDataReader, IDataProcessorService
    {
        /// <summary>
        /// Private variable of irepository for dependency injection.
        /// </summary>
        private readonly IRepository<Interfaces.Models.Client> irepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProcessorService"/> class.
        /// Construtor for dependency injection of repository
        /// </summary>
        /// <param name="irepository"> DI for repsitory.</param>
        public DataProcessorService(IRepository<Interfaces.Models.Client> irepository)
        {
            this.irepository = irepository;
        }

        /// <summary>
        /// This method is used for reading the data from the file and saving it in database.
        /// </summary>
        /// <returns>A <see cref="Task"/>returns boolean if successfully processed data .</returns>
        public async Task<bool> ProcessData()
        {
            try
            {
                Client client = null;
                string roboticsResult = null;

                var files = new ReadData().GetData().Skip(1);

                foreach (var line in files)
                {
                    client = this.OperateClientData(line);

                    if (string.Compare(line[0], AppConstants.LegaEntity, true) == 0 && client.Turnover > 1000000)
                    {
                        roboticsResult =await Robotics.ScreeningAsync(client.FullName, client.Address.Country);
                    }

                    if (roboticsResult != AppConstants.RoboticsResultFailed)
                    {
                        await this.irepository.Update(client);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(AppConstants.CustomExceptionMessageProcessingData, ex);
            }
        }
    }
}
