﻿using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VerificationWeb.Models;

namespace VerificationWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return View();
            
            var userModel = new UserModel
            {
                Username = HttpContext.Session.GetString(SessionClaims.Username),
                LoginType = HttpContext.Session.GetString(SessionClaims.LoginType)
            };
            return View(userModel);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}