using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SM.CrossCutting.Models.Models
{
    public class User
    {
        [Key]
        public string IdUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
