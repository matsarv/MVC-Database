﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Database.Controllers
{
    public class CSCoStudentCoursentroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}