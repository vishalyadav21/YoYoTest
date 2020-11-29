using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using YoYoWebApp.Models;

namespace YoYoWebApp.Controllers
{
    public class YoYoTestController : Controller
    {
        private readonly ILogger<YoYoTestController> _logger;
        private readonly IYoYoTestRepository _repositoryService;
        public YoYoTestController(ILogger<YoYoTestController> logger, IYoYoTestRepository repositoryService)
        {
            _logger = logger;
            _repositoryService = repositoryService;
        }

        public IActionResult Play(int level, int shuttle)
        {  
            var result = new FitnessRatingViewModel();
            var beeptestjson = _repositoryService.ReadFitnessRatingJson();
            List<FitnessRatingViewModel> newList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FitnessRatingViewModel>>(beeptestjson)
                                                    .Where(m => Convert.ToInt32(m.SpeedLevel) == level)
                                                    .Select(m => new FitnessRatingViewModel
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
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FitnessRatingViewModel>>(beeptestjson)
                            .OrderBy(x => Convert.ToInt32(x.SpeedLevel))
                            .FirstOrDefault(x => Convert.ToInt32(x.SpeedLevel) > level);
                result.NextShuttle = Convert.ToDateTime("00:" + result.CommulativeTime).Subtract(Convert.ToDateTime("00:" + result.StartTime)).TotalSeconds;
            }
            if (newList.Count > 1)
            { 
                result = newList.FirstOrDefault(x => Convert.ToInt32(x.ShuttleNo) > shuttle);
                if (result == null)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FitnessRatingViewModel>>(beeptestjson)
                            .OrderBy(x => Convert.ToInt32(x.SpeedLevel))
                            .FirstOrDefault(x => Convert.ToInt32(x.SpeedLevel) > level);
                    result.NextShuttle = Convert.ToDateTime("00:" + result.CommulativeTime).Subtract(Convert.ToDateTime("00:" + result.StartTime)).TotalSeconds;
                }
            }

            if (result != null && result.CommulativeTime == null)
            {
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FitnessRatingViewModel>>(beeptestjson)
                        .OrderBy(x => Convert.ToInt32(x.SpeedLevel))
                        .FirstOrDefault(x => Convert.ToInt32(x.SpeedLevel) > level);
                result.NextShuttle = Convert.ToDateTime("00:" + result.CommulativeTime).Subtract(Convert.ToDateTime("00:" + result.StartTime)).TotalSeconds;
            }
           // result.NextShuttle = 5;
            return PartialView("FitnessRating", result); 
        }

        public bool GetNextPresentShuttle(int level, int shuttle)
        { 
            var beeptestjson = _repositoryService.ReadFitnessRatingJson();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FitnessRatingViewModel>>(beeptestjson) 
                        .Any(x => Convert.ToInt32(x.SpeedLevel) == level && Convert.ToInt32(x.ShuttleNo) == shuttle); 

            return result;
        }
        public IActionResult Index()
        {
            var yoYoTestWrapper = new YoYoTestWrapper();
            yoYoTestWrapper.FitnessRating = new FitnessRatingViewModel();
            var levelVsShuttleList = new List<string>();
            var beeptestjson = _repositoryService.ReadFitnessRatingJson();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FitnessRatingViewModel>>(beeptestjson);            
            foreach (var item in result)
            {
                levelVsShuttleList.Add(item.SpeedLevel + "-" + item.ShuttleNo);
            }

            yoYoTestWrapper.TrackDetails = GetTrackDetails(levelVsShuttleList);
            return View(yoYoTestWrapper);
        } 

        public List<TrackDetailsViewModel> GetTrackDetails(List<string> levelVsShuttleList = null)
        {
            if (levelVsShuttleList == null)
            {
                levelVsShuttleList = new List<string>();
            }
            var trackDetails = new List<TrackDetailsViewModel>();
            trackDetails.Add(new TrackDetailsViewModel { SrNo = 1, AthleteName = "Aston Eaton", IsStopped = false, IsWarned = false, LevelVsShuttleList = levelVsShuttleList });
            trackDetails.Add(new TrackDetailsViewModel { SrNo = 2, AthleteName = "Bryan Clay", IsStopped = false, IsWarned = false, LevelVsShuttleList = levelVsShuttleList });
            trackDetails.Add(new TrackDetailsViewModel { SrNo = 3, AthleteName = "Dean Karnazes", IsStopped = false, IsWarned = false, LevelVsShuttleList = levelVsShuttleList });
            trackDetails.Add(new TrackDetailsViewModel { SrNo = 4, AthleteName = "Usain Bolt", IsStopped = false, IsWarned = false, LevelVsShuttleList = levelVsShuttleList });
            return trackDetails;
        }

        public IActionResult Tracks()
        {
            var result = new TrackDetailsViewModel();
            
            return PartialView("TrackDetails", result);
        }
    }
}
 
