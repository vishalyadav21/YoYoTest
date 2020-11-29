using DomainEntities;
using System;
using System.Collections.Generic;

namespace RepositoryServices
{
    public interface IYoYoTestRepository
    {
        string ReadFitnessRatingJson();
        //List<TrackDetails> GetTrackDetails();
    }

    public class YoYoTestRepository : IYoYoTestRepository
    {
        public string ReadFitnessRatingJson()
        {
            var fullPath = System.IO.File.ReadAllText(@"fitnessrating_beeptest.json"); 
            return fullPath;
        }

        public List<TrackDetails> GetTrackDetails()
        {
            var trackDetails = new List<TrackDetails>();
            trackDetails.Add(new TrackDetails { SrNo = 1, AthleteName = "Aston Eaton", IsStopped = false, IsWarned = false });
            trackDetails.Add(new TrackDetails { SrNo = 2, AthleteName = "Bryan Clay", IsStopped = false, IsWarned = false });
            trackDetails.Add(new TrackDetails { SrNo = 3, AthleteName = "Dean Karnazes", IsStopped = false, IsWarned = false });
            trackDetails.Add(new TrackDetails { SrNo = 4, AthleteName = "Usain Bolt", IsStopped = false, IsWarned = false });
            return trackDetails;
        }

    }
}
