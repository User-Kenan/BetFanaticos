using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos.data.Services
{
    using Betfanaticos.data.models;
    using static AuthServiceREST;

    public class FakeAuthService : IAuthServiceRest
    {
        public Task<LoginResponse> Login(LoginRequest request)
        {
            var response = new LoginResponse
            {
                api_key = "fake-api-key",
                user = new UserResponse
                {
                    userId = 1,
                    name = request.name,
                    role = "user"
                }
            };

            SessionService.SetUser(response);

            return Task.FromResult(response);
        }

        public Task<UserResponse> Register(UserCreate request)
        {
            var response = new UserResponse
            {
                userId = 1,
                name = request.name,
                role = "user"
            };

            return Task.FromResult(response);
        }
    }
}
