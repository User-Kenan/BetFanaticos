using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos.domain
{
    public class FootballApiResponse
    {
        public List<ApiMatch> Matches { get; set; } = new();
    }

    public class ApiMatch
    {
        public DateTime UtcDate { get; set; }
        public string Status { get; set; }

        public ApiTeam HomeTeam { get; set; }
        public ApiTeam AwayTeam { get; set; }

        public ApiScore Score { get; set; }
        public string Name { get; set; } = "";
    }

    public class ApiTeam
    {
        public string Name { get; set; }
    }

    public class ApiScore
    {
        public ApiFullTime FullTime { get; set; }
    }

    public class ApiFullTime
    {
        public int? Home { get; set; }
        public int? Away { get; set; }
    }
}
