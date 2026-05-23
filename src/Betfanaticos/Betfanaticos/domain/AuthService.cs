using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos.domain
{
    public class AuthService
    {
        private User registeredUser;

        public User Register(string username, string password)
        {

            registeredUser = new User();
            registeredUser.Username = username;
            registeredUser.Password = password; 

            return registeredUser;
        }

        public bool Login(string username, string password)
        {
            
            
            if (registeredUser.Username == username && registeredUser.Password == password && registeredUser != null)
            {
                return true;
            }
            

            else 
            {
                return false;
            }
            
        }

        public void HashPassword(string password)
        {
            // TODO
        }
    }
}
