using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskTrackerApi.Dtos{
public class CreateTaskRequest
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;
}
}