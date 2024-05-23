using InternManagementCommon;
using InternManagementData;
namespace InternManagementBusiness.Category
{
    public class InternBusiness
    {
        //private readonly InternDAO _internDAO;
        private readonly UnitOfWork _unitOfWork;
        public InternBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IInternManagementResult> GetAll()
        {
            try
            {
                var interns = await _unitOfWork.InternRepository.GetAllAsync();
                if (interns == null)
                    return new BaseResult(Const.WARNING_NO_DATA, "No intern data");
                else
                    return new BaseResult(Const.SUCCESS_GET, "Get intern list success", interns);
            }
            catch (Exception ex) { return new BaseResult(Const.ERROR_EXCEPTION, ex.Message); }

        }
        public async Task<IInternManagementResult> GetById(int code)
        {
            try
            {
                var intern = await _unitOfWork.InternRepository.GetByIdAsync(code);

                if (intern == null)
                    return new BaseResult(Const.WARNING_NO_DATA, "No intern data by code");
                else
                    return new BaseResult(Const.SUCCESS_GET, "Get intern success", intern);
            }
            catch (Exception ex)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        //public async Task<IInternManagementResult> Save(InternProfile internProfile)
    }
}
