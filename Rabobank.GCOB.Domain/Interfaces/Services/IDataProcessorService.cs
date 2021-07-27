namespace Rabobank.GCOB.Domain.Interfaces.Services
{
    using System.Threading.Tasks;

    public interface IDataProcessorService
    {
        Task<bool> ProcessData();
    }
}
