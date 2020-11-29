using System;

namespace DomainEntities
{
    public class FitnessRating
    {
        public string AccumulatedShuttleDistance { get; set; }
        public string SpeedLevel { get; set; }
        public string ShuttleNo { get; set; }
        public string Speed { get; set; }
        public float LevelTime { get; set; }
        public TimeSpan CommulativeTime { get; set; }
        public TimeSpan StartTime { get; set; }
        public IEquatable<TrackDetails> TrackDetails { get; set; }
    }
}
