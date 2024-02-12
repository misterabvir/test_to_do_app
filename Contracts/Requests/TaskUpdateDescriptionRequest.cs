using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Requests
{
    public class TaskUpdateDescriptionRequest
    {

        [Required]
        public int Id { get; set; }


        [Required]
        public string Description { get; set; }
    }
}
