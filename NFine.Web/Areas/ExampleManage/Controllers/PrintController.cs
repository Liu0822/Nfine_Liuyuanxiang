using NFine.Application.ExampleManage;
using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.ExampleManage.Controllers
{
    public class PrintController : ControllerBase
    {
        /// <summary>
        /// 表单视图
        /// </summary>
        /// <returns></returns>
        public ActionResult PrintForm()
        {
            return View();
        }
        private PrintApp PrintApp = new PrintApp();
        /// <summary>
        /// 新增/修改
        /// </summary>
        /// <param name="MyRecordEntity">实体</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SaveForm(PrintEntity Print, string keyValue)
        {
            PrintApp.SaveForm(Print, keyValue);
            return Success("操作成功");
        }
    }
}
