using Microsoft.AspNetCore.Http.HttpResults;
using TaskTrackerApi.Models;
using TaskTrackerApi.Data;
using Microsoft.EntityFrameworkCore;
using TaskTrackerApi.Dtos;

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

        public async Task<TaskItem?> GetTaskItemAsync (int id)
        {
           return await _context.Tasks.FindAsync(id);

        }
        


        public async Task<TaskItem> CreateTaskAsync (CreateTaskRequest request)
        {
            var task= new TaskItem
            {
                Title=request.Title,
                Description=request.Description,
                IsCompleted=false,
                CreatedAt=DateTime.UtcNow
            };
           
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
            return task;
        }
        

        public async Task<TaskItem?> UpdateTaskAsync(int id, UpdateTaskRequest request)
        {
            var task= await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return null;
            }
            task.Title=request.Title;
            task.Description=request.Description;
            task.IsCompleted=request.IsCompleted;
            await _context.SaveChangesAsync();

            return task;
            
            
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
        var task= await _context.FindAsync<TaskItem>(id);

        if (task == null)
            {
                return false;
            }
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
        


            
        }


        
    }
}