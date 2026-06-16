using Betfanaticos.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos.data.Services
{
    public interface IAuthServiceRest
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<UserResponse> Register(UserCreate request);
    }
}
