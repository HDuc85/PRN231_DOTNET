using InternManagementCommon;
using InternManagementData;
using InternManagementData.Models;
namespace InternManagementBusiness.GraphQL
{
    public class InternGraphQLBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public InternGraphQLBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<List<InternProfile>> GetAllIntern()
        {
            return await _unitOfWork.InternRepository.GetAllAsync();
        }
    }
}
