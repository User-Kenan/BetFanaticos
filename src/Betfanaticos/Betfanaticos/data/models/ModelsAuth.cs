using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

    public class ErrorResponse
    {
        public string message { get; set; }
    }



    public class ChallengeResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("required_amount")]
        public int RequiredAmount { get; set; }

        [JsonPropertyName("reward")]
        public int Reward { get; set; }

        [JsonPropertyName("current_state")]
        public int CurrentState { get; set; }

        [JsonPropertyName("completed")]
        public bool Completed { get; set; }

        [JsonPropertyName("reward_claimed")]
        public bool RewardClaimed { get; set; }
    }
    

    public class WalletCreate
    {
        public int user_id { get; set; }
        public double coins { get; set; }
    }

    public class WalletResponse
    {
        public int wallet_id { get; set; }
        public int user_id { get; set; }
        public double coins { get; set; }
    }

}
