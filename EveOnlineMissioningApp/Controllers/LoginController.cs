using EveOnlineMissioningApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EveOnlineMissioningApp.Controllers
{
    public class LoginController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            LoginViewModel loginViewMdl = new LoginViewModel();

            //Make sure we have enough info
            if (username == null || password == null)
            {
                loginViewMdl.code = (int)LoginResultCodes.NoCredentialsGiven;
                return View(loginViewMdl);
            }

            //Check to see if we have an account with that username
            AppDBContext dbCtx = new AppDBContext();
            Account account = dbCtx.Accounts.First(act => act.credential.username == username);

            if (account == null)
            {
                loginViewMdl.code = (int)LoginResultCodes.NoAccountFound;
                return View(loginViewMdl);
            }

            //Check to see if we have matching credentials
            if(!account.credential.authenticate(password))
            {
                loginViewMdl.code = (int)LoginResultCodes.InvalidCredentials;
                return View(loginViewMdl);
            }

            //Yay it worked
            loginViewMdl.code = (int) LoginResultCodes.ValidCredentials;
            return View(loginViewMdl);
        }

        public class LoginViewModel
        {
            public float code { get; set; }
        }

    }
}