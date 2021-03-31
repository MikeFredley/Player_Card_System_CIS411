using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Card_System_CIS411
{
    class GetRounds
    {
        int id;
        int rounds;
        string dateTime;

        public GetRounds()
        {
            id = 0;
            rounds = 0;
            dateTime = "";
        }

        public int ID { get => id; set => id = value; }
        public int Rounds { get => rounds; set => rounds = value; }
        public string DateTime { get => dateTime; set => dateTime = value; }
    }
}
