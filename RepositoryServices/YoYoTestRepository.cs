using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryServices
{
    public interface IYoYoTestRepository
    {
        string ReadFitnessRatingJson();
        string GetTrackDetails();
        void InsertIntoJson(string output);
        FitnessRating GetNextShuttle(List<FitnessRating> fitnessRatingList, int level, int shuttle);
    }

    public class YoYoTestRepository : IYoYoTestRepository
    {
        public string ReadFitnessRatingJson()
        {
            var fullPath = System.IO.File.ReadAllText(@"fitnessrating_beeptest.json"); 
            return fullPath;
        }

        public string GetTrackDetails()
        {
            var fullPath = System.IO.File.ReadAllText(@"Athletes.json");
            return fullPath; 
        }

        public void InsertIntoJson(string output)
        { 
            System.IO.File.WriteAllText("Athletes.json", output);
        }

        public FitnessRating GetNextShuttle(List<FitnessRating> fitnessRatingList, int level, int shuttle)
        {
            var result = new FitnessRating();
            List<FitnessRating> newList = fitnessRatingList
                                                    .Where(m => Convert.ToInt32(m.SpeedLevel) == level)
                                                    .Select(m => new FitnessRating
                                                    {
                                                        SpeedLevel = m.SpeedLevel,
                                                        ShuttleNo = m.ShuttleNo,
                                                        CommulativeTime = m.CommulativeTime,
                                                        StartTime = m.StartTime,
                                                        LevelTime = m.LevelTime,
                                                        NextShuttle = m.NextShuttle,
                                                        AccumulatedShuttleDistance = m.AccumulatedShuttleDistance,
                                                        Speed = m.Speed
                                                    }).ToList();
            if (newList.Count == 0)
            {
                result = fitnessRatingList.OrderBy(x => Convert.ToInt32(x.SpeedLevel)).FirstOrDefault(x => Convert.ToInt32(x.SpeedLevel) > level);
            }
            if (newList.Count > 1)
            {
                result = newList.FirstOrDefault(x => Convert.ToInt32(x.ShuttleNo) > shuttle);
                if (result == null)
                {
                    result = fitnessRatingList.OrderBy(x => Convert.ToInt32(x.SpeedLevel)).FirstOrDefault(x => Convert.ToInt32(x.SpeedLevel) > level);
                }
            }

            if (result != null && result.CommulativeTime == null)
            {
                result = fitnessRatingList.OrderBy(x => Convert.ToInt32(x.SpeedLevel)).FirstOrDefault(x => Convert.ToInt32(x.SpeedLevel) > level);
            }
            result.NextShuttle = Convert.ToDateTime("00:" + result.CommulativeTime).Subtract(Convert.ToDateTime("00:" + result.StartTime)).TotalSeconds;
            return result;
        }
    }
}
