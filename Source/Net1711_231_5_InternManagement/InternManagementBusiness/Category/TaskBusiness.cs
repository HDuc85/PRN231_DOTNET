using InternManagementCommon;
using InternManagementData;
using InternManagementData.DTO;
using InternManagementData.Models;
using InternManagementData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternManagementBusiness.Category
{
    public class TaskBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public TaskBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<ITaskManagementResult> GetAll()
        {
            try
            {
                var tasks = await _unitOfWork.TaskRepository.GetAllAsync();
                if (tasks == null)
                    return new BaseResult(Const.WARNING_NO_DATA, "No task data");
                else
                    return new BaseResult(Const.SUCCESS_GET, "Get task list success", tasks);
            }
            catch (Exception ex) { return new BaseResult(Const.ERROR_EXCEPTION, ex.Message); }

        }
        public async Task<ITaskManagementResult> GetById(int code)
        {
            try
            {
                if (code == null)
                    return new BaseResult(Const.ERROR_EXCEPTION, "task code can not be null");
                var task = await _unitOfWork.TaskRepository.GetByIdAsync(code);

                if (task == null)
                    return new BaseResult(Const.WARNING_NO_DATA, "No task data by code");
                else
                    return new BaseResult(Const.SUCCESS_GET, "Get task success", task);
            }
            catch (Exception ex)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
       
        public async Task<ITaskManagementResult> Create(InternManagementData.Models.Task task)
        {
            try
            {
                if (task == null)
                {
                    return new BaseResult(Const.ERROR_EXCEPTION, "task profile cannot be null.");
                }
                if (await _unitOfWork.TaskRepository.CreateAsync(task) > 0)
                    return new BaseResult(Const.SUCCESS_GET, "Create task success", task);
                else
                    return new BaseResult(Const.WARNING_NO_DATA, "Create fail");
            }
            catch (Exception ex) { return new BaseResult(Const.ERROR_EXCEPTION, ex.Message); }
        }
        public async Task<ITaskManagementResult> Update(InternManagementData.Models.Task task)
        {
            try
            {
                if (task == null)
                {
                    return new BaseResult(Const.ERROR_EXCEPTION, "task profile cannot be null.");
                }
                await _unitOfWork.TaskRepository.UpdateAsync(task);
                return new BaseResult(Const.SUCCESS_GET, "Update task success", task);
            }
            catch (Exception ex)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<ITaskManagementResult> Remove(InternManagementData.Models.Task task)
        {
            try
            {
                if (task == null)
                {
                    return new BaseResult(Const.ERROR_EXCEPTION, "task profile cannot be null.");
                }
                await _unitOfWork.TaskRepository.RemoveAsync(task);
                return new BaseResult(Const.SUCCESS_GET, "Update task success", task);
            }
            catch (Exception ex)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<ITaskManagementResult> Search(TaskSearchRequest request)
        {
            try
            {
                if (request == null)
                {
                    var tasks = await _unitOfWork.TaskRepository.GetAllAsync();
                    if (tasks == null)
                        return new BaseResult(Const.WARNING_NO_DATA, "No task data");
                    else
                        return new BaseResult(Const.SUCCESS_GET, "Get task list success", tasks);
                }
                var result = await _unitOfWork.TaskRepository.Search(request);
                return new BaseResult(Const.SUCCESS_GET, "Search task list success", result);
            }
            catch (Exception ex)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

    }
}
