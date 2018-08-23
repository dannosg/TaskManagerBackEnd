using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskProject.Entities;

namespace TaskProject.Contracts 
{
    public interface ITaskRepository
    {
        Task<bool> Exists(Guid id);
        IEnumerable<TaskEntity> GetAllTasks();
        Task<TaskEntity> FindTask(Guid id);
        Task<TaskEntity> AddTask(TaskEntity task);
        Task<TaskEntity> UpdateTask(TaskEntity task);
        Task<TaskEntity> DeleteTask(Guid id);
    }
}