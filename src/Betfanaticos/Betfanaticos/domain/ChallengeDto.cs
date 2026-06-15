using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betfanaticos.domain
{
    // Ich brauche eine zusätliche Challenge Klasse für trennung von Kommuniktaion und Logik 
    public class ChallengeDto
    {
        public int side_quest_id { get; set; }
        public string challange { get; set; }
        public string description { get; set; }
        public int required_amount { get; set; }
        public int current_state { get; set; }
        public bool completed { get; set; }
        public int earned_coins { get; set; }
    }
}
