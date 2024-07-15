using InternManagementData.Base;
using InternManagementData.DAO;
using m = InternManagementData.Models;
using s = System.Threading.Tasks;
using InternManagementData.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InternManagementData.Repository
{
    public class TaskRepository : GenericRepository<m.Task>, ITaskRepository
    {
        private readonly TaskDAO _dao;
        public TaskRepository()
        {
            _dao ??= new TaskDAO();
        }
        public s.Task<m.Task?> GetTaskAsync(int taskId)
        {
            return this._dao.Get().Where(x => x.TaskId == taskId).FirstOrDefaultAsync();
        }
        public s.Task<List<m.Task>> GetAllTasksAsync()
        {
            return this._dao.GetAllAsync();
        }
    }
}