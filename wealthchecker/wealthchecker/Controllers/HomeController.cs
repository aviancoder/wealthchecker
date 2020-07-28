﻿using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using wealthchecker.CustomLogic;
using wealthchecker.Data;
using wealthchecker.Models;

namespace wealthchecker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WealthTracker(BasicDetails _basicDetails)
        {

            BasicDetails basicDetails = _basicDetails;
            WealthTrackerOutputModel.BasicDetails = basicDetails;

            WealthTrackerCustomLogic cl = new WealthTrackerCustomLogic();
            cl.FillUpKiwiData();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
