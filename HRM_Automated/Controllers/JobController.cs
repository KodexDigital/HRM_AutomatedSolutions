﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HRM_Automated.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}