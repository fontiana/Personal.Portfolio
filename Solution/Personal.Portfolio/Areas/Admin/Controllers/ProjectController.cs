﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Personal.Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }
    }
}
