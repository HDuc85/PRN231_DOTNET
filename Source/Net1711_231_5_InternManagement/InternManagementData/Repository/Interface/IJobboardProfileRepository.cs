using InternManagementData.DTO;
using InternManagementData.Models;

namespace InternManagementData.Repository.Interface
{
    public interface IJobboardProfileRepository
    {
        public IEnumerable<JobboardProfile> GetAll(string search);
        public JobboardProfile Get(int id);
        public bool Create(JobboardProfileRequest request);
        public bool Update(int id, JobboardProfileRequest request);
        public bool Delete(int id);
    }
}
