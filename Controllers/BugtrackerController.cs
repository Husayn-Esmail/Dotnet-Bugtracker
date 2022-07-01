using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bugtracker.Models;

/* this controller should call the functions of Issue and JointUserIssue
 controllers */

namespace bugtracker.Controllers
{
    public class BugtrackerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
