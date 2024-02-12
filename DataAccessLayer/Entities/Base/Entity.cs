using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities.Base
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
