using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using YoYoWebApp.Models;

namespace YoYoWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IYoYoTestRepository _repositoryService;
        public HomeController(ILogger<HomeController> logger, IYoYoTestRepository repositoryService)
        {
            _logger = logger;
            _repositoryService = repositoryService;
        }

        public IActionResult Play(int level = 0)
        {
            var fitnessRatingViewModel = new FitnessRatingViewModel();
            var beeptestjson = _repositoryService.ReadFitnessRatingJson();            
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FitnessRatingViewModel>>(beeptestjson).OrderBy(x=> Convert.ToInt32(x.SpeedLevel)).FirstOrDefault(x=> Convert.ToInt32(x.SpeedLevel) > level);
            result.TrackDetails = GetTrackDetails();
            result.NextShuttle = Convert.ToDateTime(result.CommulativeTime).Subtract(Convert.ToDateTime(result.StartTime)).TotalSeconds;
            return View("Index", result);


            //var finalResult = result
            //            .GroupBy(f => new { f.SpeedLevel })
            //            .Select(a => a.AsEnumerable())
            //            .Select(b => b.OrderBy(f => f.ShuttleNo)).ToList();

        }

        public IActionResult Index()
        {
            var fitnessRatingViewModel = GetDetails(); 
            return View(fitnessRatingViewModel);
        }

        public FitnessRatingViewModel GetDetails()
        {
            var fitnessRatingViewModel = new FitnessRatingViewModel();
            var beeptestjson = _repositoryService.ReadFitnessRatingJson();
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FitnessRatingViewModel>>(beeptestjson);
            var levelVsShuttleList = new List<string>();
            foreach (var item in result)
            {
                levelVsShuttleList.Add(item.SpeedLevel + "-" + item.ShuttleNo);
            }

            var trackDetails = GetTrackDetails(levelVsShuttleList);
            fitnessRatingViewModel.TrackDetails = trackDetails;
            return fitnessRatingViewModel;
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
