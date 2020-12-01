using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HealthAPI.Models
{
    public class Weight
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Kgs { get; set; }
        public DateTime Date { get; set; }

        
        [ForeignKey("User")]
        [Required]
        public int userId { get; set; }
        public virtual User User { get; set; }
    }
}