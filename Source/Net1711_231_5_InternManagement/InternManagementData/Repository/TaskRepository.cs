using InternManagementData.Base;
using InternManagementData.DAO;
using InternManagementData.DTO;
using InternManagementData.Models;
using InternManagementData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternManagementData.Repository
{
    public class TaskRepository : GenericRepository<Models.Task>, ITaskRepository
    {
        private readonly TaskDAO _dao;
        public TaskRepository()
        {
            _dao ??= new TaskDAO();
        }

        public async Task<List<Models.Task>> Search(TaskSearchRequest request)
        {
            var tasks = await this._dao.GetAllAsync();

            if (request.TaskName != null)
            {
                tasks = tasks.Where(t => t.TaskName != null && t.TaskName.ToLower().Contains(request.TaskName.ToLower())).ToList();
            }
            if (request.TaskDecription != null)
            {
                tasks = tasks.Where(t => t.TaskDecription != null && t.TaskDecription.ToLower().Contains(request.TaskDecription.ToLower())).ToList();
            }
            if (request.TaskCategory != null)
            {
                tasks = tasks.Where(t => t.TaskCategory != null && t.TaskCategory.ToLower().Contains(request.TaskCategory.ToLower())).ToList();
            }
            if (request.Comments != null)
            {
                tasks = tasks.Where(t => t.Comments != null && t.Comments.ToLower().Contains(request.Comments.ToLower())).ToList();
            }
            if (request.Priority != null)
            {
                tasks = tasks.Where(t => t.Priority != null && t.Priority.Value.ToString().Contains(request.Priority.Value.ToString())).ToList();
            }
            if (request.StartDate.HasValue)
            {
                tasks = tasks.Where(t => t.StartDate >= request.StartDate).ToList();
            }
            if (request.EndDate.HasValue)
            {
                tasks = tasks.Where(t => t.EndDate <= request.EndDate).ToList();
            }
            return tasks;
        }

        
    }
}
