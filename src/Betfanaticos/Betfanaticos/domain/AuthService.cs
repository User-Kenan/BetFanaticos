using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos.domain
{
    public class AuthService
    {
        private List<User> users = new List<User>();
        public User CurrentUser { get; private set; }

        public User Register(string username, string password)
        {
            foreach(User u in users)
            {
                if(username == u.UserName)
                {
                    Console.WriteLine("User Existiert bereits.");
                    return null;
                } 
            }

            User user = new User
            {
                UserName = username,
                PasswortHash = password 
            };

            users.Add(user);

            CurrentUser = user;

            return user;
        }

        public EnumLoginResponse Login(string username, string password)
        {
            foreach(User u in users)
            {
            
                if(u.UserName == username)
                {
                    if(u.PasswortHash == password)
                    {
                        CurrentUser = u;
                        return EnumLoginResponse.Success;
                    }

                    return EnumLoginResponse.WrongPassword;
                }
               
            }

            return EnumLoginResponse.UserNotFound;
        }

        public void HashPassword(string password)
        {
            // TODO
        }
    }
}
