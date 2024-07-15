using InternManagementData.Base;
using Task = InternManagementData.Models.Task;

namespace InternManagementData.DAO
{
    public class TaskDAO : GenericRepository<Task>  
    {
        public TaskDAO()
        {

        }
    }
}