﻿using System;

namespace DomainEntities
{
    public class FitnessRating
    {
        public string AccumulatedShuttleDistance { get; set; }
        public string SpeedLevel { get; set; }
        public string ShuttleNo { get; set; }
        public string Speed { get; set; }
        public string LevelTime { get; set; }
        public string CommulativeTime { get; set; }
        public string StartTime { get; set; }
        public double NextShuttle { get; set; }
    }
}
