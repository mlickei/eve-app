using EveOnlineMissioningApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EveOnlineMissioningApp.Controllers
{
    public class HomeController : Controller
    {
        private MissionCaptureContext missionCaptures = new MissionCaptureContext();

        public ActionResult Index()
        {
            return View();
        }

    }

}