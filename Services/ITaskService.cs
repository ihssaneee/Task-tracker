using TaskTrackerApi.Models;
using TaskTrackerApi.Dtos;
namespace TaskTrackerApi.Services
{
    public interface ITaskService

    {
        
            Task<List<TaskItem>> GetAllAsync();

            Task<TaskItem?>  GetTaskItemAsync(int id);

            Task<TaskItem> CreateTaskAsync(CreateTaskRequest request);

            Task<TaskItem?> UpdateTaskAsync (int id, UpdateTaskRequest request);

            Task <bool> DeleteTaskAsync (int id);



        }
    
    }
