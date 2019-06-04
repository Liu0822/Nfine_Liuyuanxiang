using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.ExampleManage.Controllers
{
    public class MyCalendarController : Controller
    {
        //
        // GET: /ExampleManage/MyCalendar/

        public ActionResult CalendarIndex()
        {
            return View();        
        }

    }
}
