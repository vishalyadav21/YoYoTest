namespace DomainEntities
{
    public class TrackDetails
    {
        public int SrNo { get; set; }
        public string AthleteName { get; set; }
        public bool IsWarned { get; set; }
        public bool IsStopped { get; set; }
        public string StoppedAt { get; set; }
    }
}
