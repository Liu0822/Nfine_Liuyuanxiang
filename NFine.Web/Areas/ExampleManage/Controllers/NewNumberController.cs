using NFine.Application.ExampleManage;
using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.ExampleManage.Controllers
{
    public class NewNumberController : ControllerBase
    {
        private NewNumberApp nnapp = new NewNumberApp();     
        /// <summary>
        /// 获取首页最新消息总数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetEntityNum()
        {
            var data = nnapp.GetEntityNum();
            return Content(data.ToJson());
        }

    }
}
