using TaskTrackerApi.Models;

namespace TaskTrackerApi.Services
{
    public interface ITaskService

    {
        
            Task<List<TaskItem>> GetAllAsync();

            Task<TaskItem?>  GetTaskItemAsync(int id);

            Task<TaskItem> CreateTaskAsync(TaskItem taskItem);

            Task<TaskItem?> UpdateTaskAsync (int id, TaskItem updatedTask);

            Task <bool> DeleteTaskAsync (int id);



        }
    
    }
