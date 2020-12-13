using System;

namespace CollageLibraryManager.User.Api
{
    public class LoginResponse
    {
        public bool LoginStatus { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
    }
}
