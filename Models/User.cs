using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace HealthAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string Password { get; set; }
    }
}