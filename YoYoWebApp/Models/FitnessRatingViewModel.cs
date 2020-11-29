using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace YoYoWebApp.Models
{
    public class FitnessRatingViewModel
    {
        [DisplayName("TOTAL DISTANCE")]
        public string AccumulatedShuttleDistance { get; set; }

        [DisplayName("Level")]
        public string SpeedLevel { get; set; }

        [DisplayName("Shuttle")]
        public string ShuttleNo { get; set; }

        [DisplayName("TOTAL TIME")]
        public string LevelTime { get; set; }

        [DisplayName("NEXT SHUTTLE")]
        public double NextShuttle { get; set; }

        public string Speed { get; set; }
        public string CommulativeTime { get; set; }
        public string StartTime { get; set; }
                
        public IEnumerable<TrackDetailsViewModel> TrackDetails { get; set; }

        //public FitnessRatingViewModel()
        //{
        //    SpeedLevel = "0";
        //    ShuttleNo = "0";
        //    AccumulatedShuttleDistance = "0";
        //}
    }
}
