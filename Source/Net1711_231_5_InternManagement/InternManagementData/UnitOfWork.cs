using InternManagementData.Models;
using InternManagementData.Repository;

namespace InternManagementData
{
    public class UnitOfWork
    {
        private Net17112315InternManagementContext _unitOfWorkContext;
        private InternRepository _intern;

        public UnitOfWork()
        {
        }

        public InternRepository InternRepository
        {
            get
            {
                return _intern ??= new InternRepository();
            }
        }
    }
}
