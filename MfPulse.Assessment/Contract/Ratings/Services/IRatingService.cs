using System.Threading.Tasks;

namespace MfPulse.Assessment.Contract.Ratings.Services
{
    public interface IRatingService
    {
        public Task CreateDefault(string companyId);
        public Task Delete(string id);
    }
}