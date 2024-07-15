using InternManagementData.Base;
using InternManagementData.DAO;
using InternManagementData.Models;
using InternManagementData.Repository.Interface;

namespace InternManagementData.Repository
{
<<<<<<< HEAD
    public class MentorRepository : GenericRepository<MentorProfile>
=======
    public class MentorRepository : GenericRepository<MentorProfile>, IMentorRepository
>>>>>>> 0f76685bb13278b4ca612a3b2abd16e6aca92ffa
    {
        private readonly MentorDAO _dao;
        public MentorRepository()
        {
            _dao ??= new MentorDAO();
        }
<<<<<<< HEAD
=======

        public MentorProfile CheckLogin(string email, string password)
        {
            return this._dao.Get().Where(x => x.MentorEmail == email && x.Password == password).FirstOrDefault();
        }
>>>>>>> 0f76685bb13278b4ca612a3b2abd16e6aca92ffa
    }
}
