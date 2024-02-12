using DataAccessLayer.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class StatusEntity : Entity
    {
        public Status Status { get; set; } 
    }

    public enum Status
    {
        Created = 0,
        InProgress = 1,
        Resolved = 2
    }
}
