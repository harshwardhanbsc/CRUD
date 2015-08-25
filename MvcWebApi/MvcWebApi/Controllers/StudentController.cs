using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebApi.Controllers
{
    public class StudentController : Controller
    {
       /// <summary>
       /// Call the View
       /// </summary>
       /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

    }
}
