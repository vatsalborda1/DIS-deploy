﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBIApplication.Controllers
{
    public class PoliceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
