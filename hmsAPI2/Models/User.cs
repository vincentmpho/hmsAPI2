using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hmsAPI2.Models
{
    public class User
    {
        [Key]
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string password { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string type { get; set; }

        [Display(Description = "Username or ID number")]
        public int UserId { get; set; }


        [Required(ErrorMessage = "Please enter password.")]
        public string Username { get; set; }
        

    }
}
