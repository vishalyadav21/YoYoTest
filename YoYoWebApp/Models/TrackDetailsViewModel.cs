using System.Collections.Generic;

namespace YoYoWebApp
{
    public class TrackDetailsViewModel
    {
        public int SrNo { get; set; }
        public string AthleteName { get; set; }
        public bool IsWarned { get; set; }
        public bool IsStopped { get; set; }
        public string StoppedAt { get; set; } = string.Empty;
        public IEnumerable<string> LevelVsShuttleList { get; set; }
    }
}
