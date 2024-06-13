using InternManagementData.Models;

namespace InternManagementData.Repository.Interface
{
    public interface IInternRepository
    {
       public InternProfile CheckLogin(string email, string password);
    }
}