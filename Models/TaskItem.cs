using TaskTrackerApi.Enums;
namespace TaskTrackerApi.Models
{
public class TaskItem
{
    public int Id {get;set;}

    public string Title {get;set;} = string.Empty;

    public string Description {get;set;} = string.Empty;

    public bool IsCompleted {get;set;}

    public DateTime CreatedAt {get;set;}

    public DateTime UpdatedAt {get;set;}

    public TaskItemStatus Status {get;set;} = TaskItemStatus.NotStarted;

    public Priority Priority {get;set;} = Priority.Medium;

    public User User {get;set;} =null!;

}
}