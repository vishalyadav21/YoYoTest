using DomainEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryServices;
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
            
            var beeptestjson = _repositoryService.ReadFitnessRatingJson();
            var fitnessRatingList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FitnessRating>>(beeptestjson); 
            var fitnessRating = _repositoryService.GetNextShuttle(fitnessRatingList, level, shuttle);
            var result = new FitnessRatingViewModel {
                AccumulatedShuttleDistance = fitnessRating.AccumulatedShuttleDistance,
                CommulativeTime = fitnessRating.CommulativeTime,
                LevelTime = fitnessRating.LevelTime,
                NextShuttle = fitnessRating.NextShuttle,
                ShuttleNo = fitnessRating.ShuttleNo,
                Speed = fitnessRating.Speed,
                SpeedLevel = fitnessRating.SpeedLevel,
                StartTime = fitnessRating.StartTime
            };  
            return PartialView("FitnessRating", result); 
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
            var athletes = _repositoryService.GetTrackDetails();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TrackDetailsViewModel>>(athletes);
            foreach (var item in result)
            {
                item.LevelVsShuttleList = levelVsShuttleList;
            }
            return result;
        } 

        public IActionResult WarnAthlete(int srNo)
        {
            var athletes = _repositoryService.GetTrackDetails();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TrackDetailsViewModel>>(athletes); 
            foreach (var item in result.Where(x => x.SrNo == srNo))
            {
                item.IsWarned = true; 
            }
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText("Athletes.json", output);

            return PartialView("TrackDetails", result);
        }

        public IActionResult StopAthlete(int srNo, string level)
        { 
            var athletes = _repositoryService.GetTrackDetails();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TrackDetailsViewModel>>(athletes);
            var beeptestjson = _repositoryService.ReadFitnessRatingJson();
            var fitnessRatings = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FitnessRatingViewModel>>(beeptestjson);
            var levelVsShuttleList = new List<string>(); 
            foreach (var item in fitnessRatings)
            {
                levelVsShuttleList.Add(item.SpeedLevel + "-" + item.ShuttleNo);
            }
            foreach (var item in result.Where(x => x.SrNo == srNo))
            {
                item.IsStopped = true;
                item.LevelVsShuttleList = levelVsShuttleList;
                item.StoppedAt = (levelVsShuttleList.IndexOf(level) - 1) > 0 ? levelVsShuttleList.ElementAt(levelVsShuttleList.IndexOf(level)-1) : levelVsShuttleList.ElementAt(0);
            }
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            _repositoryService.InsertIntoJson(output); 

            return PartialView("TrackDetails", result);
        }
    }
}
 
