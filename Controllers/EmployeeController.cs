using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(string id) //url
        {
            return Ok("Your Emplid is = " + id);
        }

        public IActionResult DetailQuery([FromQuery]string emplid) //querystring
        {
            return Ok("Your Emplid is = " + emplid);
        }
    }
}
