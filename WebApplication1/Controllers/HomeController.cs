﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
