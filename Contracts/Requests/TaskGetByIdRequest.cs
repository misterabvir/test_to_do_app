using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Requests
{
    public class TaskGetByIdRequest
    {

        [Required]
        public int Id { get; set; }
    }
}
