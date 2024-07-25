using InternManagementData.Base;
using InternManagementData.DAO;
using InternManagementData.Models;
using InternManagementData.Repository.Interface;

namespace InternManagementData.Repository
{
  public class InternRepository : GenericRepository<InternProfile>, IInternRepository
  {
    private readonly InternDAO _dao;
    public InternRepository()
    {
      _dao ??= new InternDAO();
    }

    public InternProfile CheckLogin(string email, string password)
    {
      return this._dao.Get().Where(x => x.InternEmail == email && x.Password == password).FirstOrDefault();
    }
  }
}

