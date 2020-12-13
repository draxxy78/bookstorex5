using System;
using System.ComponentModel.DataAnnotations;

namespace CollageLibraryManager.User.Api
{
    public class LoginRequest
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string password { get; set; }
    }
}
