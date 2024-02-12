using DataAccessLayer.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class TaskEntity : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int StatusId { get; set; }
        public StatusEntity StatusEntity { get; set; }
    }
}
