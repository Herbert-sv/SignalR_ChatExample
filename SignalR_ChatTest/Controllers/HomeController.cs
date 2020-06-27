using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalR_ChatTest.Models;

namespace SignalR_ChatTest.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
           return View("RegisterSession");
        }
        [HttpPost]
        public IActionResult Register(string UserName, string Password)
        {
           string username = "user1";
            string password = "signalr";
            string teamuser = "user2";
           
            
            if(UserName==username && Password == password)
            {
                ViewBag.Test = "Chat Box";
                ViewBag.username = UserName;
                return View("Index");
            }
            else if(UserName== teamuser && Password == password)
            {
                ViewBag.Test = "Chat Box";
                ViewBag.username = UserName;
                return View("Index");
            }

            return View("RegisterSession");
        }
        [HttpGet]
        [Route("_")]
        public IActionResult Index()
        {
            ViewBag.Test = "Chat Box";
            return View();
        }

      

      
    }
}
