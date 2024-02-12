using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Requests
{
    public class TaskDeleteRequest
    {

        [Required]
        public int Id { get; set; }
    }
}
