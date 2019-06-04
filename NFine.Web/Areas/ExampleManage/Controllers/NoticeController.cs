using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.ExampleManage.Controllers
{
    public class NoticeController : Controller
    {
      
        /// <summary>
        /// Index视图
        /// </summary>
        /// <returns></returns>
        public ActionResult NoticeIndex()
        {
            return View();
        }
        /// <summary>
        /// Form视图
        /// </summary>
        /// <returns></returns>
        public ActionResult NoticeForm()
        {
            return View();
        }

    }
}
