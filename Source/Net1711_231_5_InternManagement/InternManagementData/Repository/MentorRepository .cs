using InternManagementData.Base;
using InternManagementData.DAO;
using InternManagementData.Models;
using InternManagementData.Repository.Interface;

namespace InternManagementData.Repository
{
    public class MentorRepository : GenericRepository<MentorProfile>, IMentorRepository
    {
        private readonly MentorDAO _dao;
        public MentorRepository()
        {
            _dao ??= new MentorDAO();
        }

        public MentorProfile CheckLogin(string email, string password)
        {
            return this._dao.Get().Where(x => x.MentorEmail == email && x.Password == password).FirstOrDefault();
        }
    }
}
