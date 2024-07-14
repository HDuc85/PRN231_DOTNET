using InternManagementData.DTO;
using InternManagementData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternManagementData.Repository.Interface
{
    public interface ITaskRepository
    {
        public Task<List<Models.Task>> Search(TaskSearchRequest request);
    }
}
