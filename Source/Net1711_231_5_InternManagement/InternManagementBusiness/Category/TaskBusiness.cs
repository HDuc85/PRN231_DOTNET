using InternManagementCommon;
using InternManagementData;
using m = InternManagementData.Models;

namespace InternManagementBusiness.Category
{
    public class TaskBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public TaskBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }
        public async Task<IInternManagementResult> GetAll()
        {
            try
            {
                var interns = await _unitOfWork.TaskRepository.GetAllAsync();
                if (interns == null)
                    return new BaseResult(Const.WARNING_NO_DATA, "No task data");
                else
                    return new BaseResult(Const.SUCCESS_GET, "Get task list success", interns);
            }
            catch (Exception ex) { return new BaseResult(Const.ERROR_EXCEPTION, ex.Message); }

        }
        public async Task<IInternManagementResult> GetById(int code)
        {
            try
            {
                if (code == null)
                    return new BaseResult(Const.ERROR_EXCEPTION, "task code can not be null");
                var intern = await _unitOfWork.TaskRepository.GetByIdAsync(code);

                if (intern == null)
                    return new BaseResult(Const.WARNING_NO_DATA, "No task data by code");
                else
                    return new BaseResult(Const.SUCCESS_GET, "Get task success", intern);
            }
            catch (Exception ex)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<IInternManagementResult> Create(m.Task task)
        {
            try
            {
                if (task == null)
                {
                    return new BaseResult(Const.ERROR_EXCEPTION, "Task cannot be null.");
                }
                if (await _unitOfWork.TaskRepository.CreateAsync(task) > 0)
                    return new BaseResult(Const.SUCCESS_GET, "Create intern success", task);
                else
                    return new BaseResult(Const.WARNING_NO_DATA, "Create fail");
            }
            catch (Exception ex) { return new BaseResult(Const.ERROR_EXCEPTION, ex.Message); }
        }
        public async Task<IInternManagementResult> Update(m.Task task)
        {
            try
            {
                if (task == null)
                {
                    return new BaseResult(Const.ERROR_EXCEPTION, "Intern profile cannot be null.");
                }
                await _unitOfWork.TaskRepository.UpdateAsync(task);
                return new BaseResult(Const.SUCCESS_GET, "Update intern success", task);
            }
            catch (Exception ex)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<IInternManagementResult> Remove(m.Task task)
        {
            try
            {
                if (task == null)
                {
                    return new BaseResult(Const.ERROR_EXCEPTION, "Intern profile cannot be null.");
                }
                _unitOfWork.TaskRepository.RemoveAsync(task);
                return new BaseResult(Const.SUCCESS_GET, "Update intern success", task);
            }
            catch (Exception ex)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    }
}