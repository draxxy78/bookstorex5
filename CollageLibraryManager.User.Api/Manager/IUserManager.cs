using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollageLibraryManager.User.Api.Manager
{
    public interface IUserManager
    {
        LoginResponse Login(string userName, string password);
    }
}
