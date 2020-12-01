using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace HealthAPI.Models
{
    public class Pulse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Bpm { get; set; }
        private DateTime? _Date;
        public DateTime Date { 
            get 
            {
                if (_Date == null)
                {
                    _Date = DateTime.Now;
                }
                return _Date.Value;
            }
            set { _Date = value; }
        }

        
        [ForeignKey("User")]
        [Required]
        public int userId { get; set; }
        public virtual User User { get; set; }
    }
}