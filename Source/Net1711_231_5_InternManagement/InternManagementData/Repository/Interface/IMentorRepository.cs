using InternManagementData.Models;

namespace InternManagementData.Repository.Interface
{
    public interface IMentorRepository
    {
       public MentorProfile CheckLogin(string email, string password);
    }
}