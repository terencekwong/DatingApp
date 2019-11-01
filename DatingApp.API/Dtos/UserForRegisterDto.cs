using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string username { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Wrong Password length")]
        public string password { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string knownAs { get; set; }
        [Required]
        public DateTime dateOfBirth { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string country { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}