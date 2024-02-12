using System.ComponentModel.DataAnnotations;

namespace Contracts.Responses
{
    public class TaskResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Status { get; set; }
    }
}
