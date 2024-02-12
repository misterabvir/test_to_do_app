using System.ComponentModel.DataAnnotations;

namespace Contracts.Requests
{
    public class TaskCreateRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
