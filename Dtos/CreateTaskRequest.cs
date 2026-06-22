using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class CreateTaskRequest
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;
}