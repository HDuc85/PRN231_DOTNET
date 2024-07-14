using InternManagementData.Base;
using InternManagementData.DAO;
using InternManagementData.DTO;
using InternManagementData.Models;
using InternManagementData.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InternManagementData.Repository
{
    public class JobboardProfileRepository : GenericRepository<JobboardProfile>, IJobboardProfileRepository
    {
        private readonly JobboardProfileDAO dao;
        public JobboardProfileRepository() { 
            this.dao ??= new JobboardProfileDAO();
        }
        public bool Create(JobboardProfileRequest request)
        {
            JobboardProfile create = new JobboardProfile()
            {
                Name = request.Name,
                Description = request.Description,
                Position = request.Position,
                YearOfBirth = request.YearOfBirth,
            };
            dao.Create(create);
            return true;
        }

        public bool Delete(int id)
        {
            JobboardProfile found = dao.GetById(id);
            if (found is null) return false;
            return dao.Remove(found);
        }

        public JobboardProfile Get(int id)
        {
            return dao.GetById(id);
        }

        public bool Update(int id, JobboardProfileRequest request)
        {
            JobboardProfile found = dao.GetById(id);
            if(found is null) return false;
            
            JobboardProfile update = new JobboardProfile()
            {
                Id = id,
                Name = request.Name ?? found.Name,
                Description = request.Description ?? found.Description,
                Position = request.Position ?? found.Position,
                YearOfBirth = request.YearOfBirth ?? found.YearOfBirth,
            };
            dao.Update(update);
            return true;
        }

        public IEnumerable<JobboardProfile> GetAll(string search)
        {
            Expression<Func<JobboardProfile, bool>> predicate = x => x.Name.Contains(search) || x.Description.Contains(search);
            IQueryable<JobboardProfile> query = _dbSet.Where(predicate);
            return query.AsNoTracking().AsEnumerable();
        }
    }
}
