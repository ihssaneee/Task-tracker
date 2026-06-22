using Microsoft.AspNetCore.Http.HttpResults;
using TaskTrackerApi.Models;
using TaskTrackerApi.Data;

namespace TaskTrackerApi.Services
{
    public class TaskService : ITaskService
    {

       private readonly AppDbContext _context;
      
      public  TaskService(AppDbContext context)
        {
            _context=context;
        }
        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await  _context.Tasks.ToListAsync();
        }

        public  Task<TaskItem?> GetTaskItemAsync (int id)
        {
            var task= _tasks.FirstOrDefault(t=>t.Id==id);
            return  Task.FromResult(task);

        }
        


        public  Task<TaskItem> CreateTaskAsync (TaskItem taskItem)
        {
            taskItem.Id=_nextId++;
            taskItem.CreatedAt=DateTime.UtcNow;
            
            _tasks.Add(taskItem);
            return   Task.FromResult(taskItem);
        }
        

        public Task<TaskItem?> UpdateTaskAsync(int id, TaskItem updatedTask)
        {
            var task= _tasks.FirstOrDefault(t=>t.Id==id);
           Console.WriteLine(updatedTask.IsCompleted);
            if (task==null) return Task.FromResult<TaskItem?>(null);
            task.Title=updatedTask.Title;
            task.Description=updatedTask.Description;
            task.IsCompleted=updatedTask.IsCompleted;
            return Task.FromResult<TaskItem?>(task);
            
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
         var task=await GetTaskItemAsync(id);
         if (task==null) return false;
         _tasks.Remove(task);
         return true ;
            
        }


        
    }
}