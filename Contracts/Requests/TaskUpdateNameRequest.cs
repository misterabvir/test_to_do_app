using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Requests
{
    public class TaskUpdateNameRequest
    {

        [Required]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }
    }
}
