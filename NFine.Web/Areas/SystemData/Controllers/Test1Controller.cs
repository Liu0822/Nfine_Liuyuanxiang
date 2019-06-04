using NFine.Application.ExampleManage;
using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.SystemData.Controllers
{
    public class Test1Controller : Controller
    {
        /// <summary>
        /// 定义应用
        /// </summary>
        private MyRecordApp test = new MyRecordApp();

        /// <summary>
        /// Test1视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Test1Index()
        {
            return View();
        }


        /// <summary>
        ///零时列表展示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetMyRecord()
        {
            var data = test.GetList();
            return Content(data.ToJson());
        }
    }
}
