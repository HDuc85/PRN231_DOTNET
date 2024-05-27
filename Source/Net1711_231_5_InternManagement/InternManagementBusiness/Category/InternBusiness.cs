using InternManagementCommon;
using InternManagementData;
using InternManagementData.Models;
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
                if (code == null)
                    return new BaseResult(Const.ERROR_EXCEPTION, "Intern code can not be null");
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
        public async Task<IInternManagementResult> Create(InternProfile internProfile)
        {
            try
            {
                if (internProfile == null)
                {
                    return new BaseResult(Const.ERROR_EXCEPTION, "Intern profile cannot be null.");
                }
                if (await _unitOfWork.InternRepository.CreateAsync(internProfile) > 0)
                    return new BaseResult(Const.SUCCESS_GET, "Create intern success", internProfile);
                else
                    return new BaseResult(Const.WARNING_NO_DATA, "Create fail");
            } catch (Exception ex) { return new BaseResult(Const.ERROR_EXCEPTION, ex.Message); }
        }
        public async Task<IInternManagementResult> Update(InternProfile internProfile)
        {
            try
            {
                if (internProfile == null)
                {
                    return new BaseResult(Const.ERROR_EXCEPTION, "Intern profile cannot be null.");
                }
                await _unitOfWork.InternRepository.UpdateAsync(internProfile);
                return new BaseResult(Const.SUCCESS_GET, "Update intern success", internProfile);
            } catch (Exception ex)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<IInternManagementResult> Remove(InternProfile internProfile)
        {
            try
            {
                if (internProfile == null)
                {
                    return new BaseResult(Const.ERROR_EXCEPTION, "Intern profile cannot be null.");
                }
                _unitOfWork.InternRepository.RemoveAsync(internProfile);
                return new BaseResult(Const.SUCCESS_GET, "Update intern success", internProfile);
            } catch (Exception ex)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    }
}
