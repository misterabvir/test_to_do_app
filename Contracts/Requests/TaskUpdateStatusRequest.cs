using System.ComponentModel.DataAnnotations;

namespace Contracts.Requests
{
    public class TaskUpdateStatusRequest
    {

        [Required]
        public int Id { get; set; }
    }
}
