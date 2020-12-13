using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CollageLibraryManager.User.Api.Manager
{
    public class UserManager : IUserManager
    {
        public LoginResponse Login(string userName, string password)
        {
            var userJson = File.ReadAllText("Data/User.json");
            var userInfo = JsonConvert.DeserializeObject<List<UserInfo>>(userJson);
            if(userInfo.Any(x=>x.UserId == userName && x.password == password))
            {
                var user = userInfo.Where(x => x.UserId == userName && x.password == password).FirstOrDefault();
                return new LoginResponse()
                {
                    LoginStatus = true,
                    Branch = user.Branch,
                    Name = user.Name,
                    Role = user.Role,
                    UserId = user.UserId
                };
            }
            return new LoginResponse()
            {
                LoginStatus = false
            };
        }
    }
}
