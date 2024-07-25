using InternManagementCommon;
using InternManagementData;
using InternManagementData.DTO;
using InternManagementData.Models;

namespace InternManagementBusiness.Category
{
    public class JobboardBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public JobboardBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IInternManagementResult> GetAll(string? serach)
        {
            try
            {
                var jobboards = _unitOfWork.JobboardProfileRepository.GetAll(serach ?? "");
                if (jobboards == null)
                    return new BaseResult(Const.WARNING_NO_DATA, "No jobboard data");
                else
                    return new BaseResult(Const.SUCCESS_GET, "Get jobboard list success", jobboards);
            }
            catch (Exception ex) { return new BaseResult(Const.ERROR_EXCEPTION, ex.Message); }

        }
        public async Task<IInternManagementResult> GetById(int code)
        {
            try
            {
                if (code == null)
                    return new BaseResult(Const.ERROR_EXCEPTION, "Jobbooard code can not be null");
                var jobboardProfile = await _unitOfWork.JobboardProfileRepository.GetByIdAsync(code);

                if (jobboardProfile == null)
                    return new BaseResult(Const.WARNING_NO_DATA, "No jobboard data by code");
                else
                    return new BaseResult(Const.SUCCESS_GET, "Get jobboard success", jobboardProfile);
            }
            catch (Exception ex)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        //public async Task<IInternManagementResult> Save(InternProfile internProfile)
        public async Task<IInternManagementResult> Create(JobboardProfileRequest request)
        {
            try
            {
                if (request == null)
                {
                    return new BaseResult(Const.ERROR_EXCEPTION, "request cannot be null.");
                }
                JobboardProfile create = new JobboardProfile()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Position = request.Position,
                    YearOfBirth = request.YearOfBirth,
                };
                if (await _unitOfWork.JobboardProfileRepository.CreateAsync(create) > 0)
                    return new BaseResult(Const.SUCCESS_GET, "Create jobbooard success", create);
                else
                    return new BaseResult(Const.WARNING_NO_DATA, "Create fail");
            }
            catch (Exception ex) { return new BaseResult(Const.ERROR_EXCEPTION, ex.Message); }
        }
        public async Task<IInternManagementResult> Update(int id, JobboardProfileRequest request)
        {
            try
            {
                if (request == null)
                {
                    return new BaseResult(Const.ERROR_EXCEPTION, "request cannot be null.");
                }
                //JobboardProfile found = _unitOfWork.JobboardProfileRepository.GetById(id);
                //if (found is null) return new BaseResult(Const.WARNING_NO_DATA, "not found.");

                JobboardProfile update = new JobboardProfile()
                {
                    Id = id,
                    Name = request.Name,
                    Description = request.Description,
                    Position = request.Position,
                    YearOfBirth = request.YearOfBirth,
                };
                await _unitOfWork.JobboardProfileRepository.UpdateAsync(update);
                return new BaseResult(Const.SUCCESS_GET, "Update jobboard success", request);
            }
            catch (Exception ex)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<IInternManagementResult> Remove(int id)
        {
            try
            {
                if (id == null)
                {
                    return new BaseResult(Const.ERROR_EXCEPTION, "id cannot be null.");
                }
                JobboardProfile found = _unitOfWork.JobboardProfileRepository.GetById(id);
                if (found is null) return new BaseResult(Const.WARNING_NO_DATA, "not found.");
                _unitOfWork.JobboardProfileRepository.RemoveAsync(found);
                return new BaseResult(Const.SUCCESS_GET, "Remove jobboard success", found);
            }
            catch (Exception ex)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    }
}
