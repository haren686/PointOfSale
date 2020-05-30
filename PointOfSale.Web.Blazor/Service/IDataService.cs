using System.Collections.Generic;
using System.Threading.Tasks;
using PointOfSale.Repository.Models;

namespace PointOfSale.Service
{
    public interface IDataService
    {
        Task<List<Applications>> GetApplications();

        Task<List<Applications>> GetApplication(string? ApplicationNumber);

        Task<string> AddApplication(Applications Application);

        Task<int> DeleteApplication(string? ApplicationNumber);

        Task UpdateApplication(Applications Application);
    }
}
