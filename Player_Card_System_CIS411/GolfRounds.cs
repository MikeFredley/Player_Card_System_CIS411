﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_Card_System_CIS411
{
    class GolfRounds
    {
        int year;
        int totalRounds;
        string packageType;
        decimal costPerRound;

        public GolfRounds()
        {
            year = 0;
            totalRounds = 0;
            packageType = "";
            costPerRound = 0;
        }

        public int Year { get => year; set => year = value; }
        public int TotalRounds { get => totalRounds; set => totalRounds = value; }
        public string PackageType { get => packageType; set => packageType = value; }
        public decimal CostPerRound { get => costPerRound; set => costPerRound = value; }




    }
}
