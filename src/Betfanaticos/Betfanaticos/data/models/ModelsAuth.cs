using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos.data.models
{

    public class LoginRequest
    {
        public string name { get; set; }
        public string password { get; set; }
    }


    public class UserCreate
    {
        public string name { get; set; }
        public string password { get; set; }
    }

    public class UserResponse
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }

    public class LoginResponse
    {
        public string api_key { get; set; }
        public UserResponse user { get; set; }
    }
}
