using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryServices;
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
            var nextShuttle = GetNextPresentShuttle(level, shuttle);
            var fitnessRatingViewModel = new FitnessRatingViewModel();
            var beeptestjson = _repositoryService.ReadFitnessRatingJson();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FitnessRatingViewModel>>(beeptestjson)
                        .OrderBy(x => Convert.ToInt32(x.SpeedLevel))
                        .FirstOrDefault(x => Convert.ToInt32(x.SpeedLevel) > level);
            result.NextShuttle = Convert.ToDateTime("00:" + result.CommulativeTime).Subtract(Convert.ToDateTime("00:" + result.StartTime)).TotalSeconds;
            result.NextShuttle = 5;
            return PartialView("FitnessRating", result); 
        }

        public IEnumerable<string> GetNextPresentShuttle(int level, int shuttle)
        { 
            var beeptestjson = _repositoryService.ReadFitnessRatingJson();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FitnessRatingViewModel>>(beeptestjson)
                         .GroupBy(f => new { f.SpeedLevel })
                        .Select(a => a.AsEnumerable())
                        .Select(b => b.OrderBy(f => f.ShuttleNo).FirstOrDefault(x => Convert.ToInt32(x.ShuttleNo) > shuttle))
                        .Select(x=>x.ShuttleNo);
             

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
    }
}
 
