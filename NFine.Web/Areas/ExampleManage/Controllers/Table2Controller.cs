using NFine.Application.ExampleManage;
using NFine.Code;
using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.ExampleManage.Controllers
{
    public class Table2Controller : ControllerBase
    {
        private Table2App tb = new Table2App();
        public ActionResult Table2Index()
        {
            return View();
        }
        /// <summary>
        /// 计算器
        /// </summary>
        /// <returns></returns>
        public ActionResult Table3Index()
        {
            return View();
        }

        /// <summary>
        /// TABLe2
        /// </summary>
        /// <param name="table2Entity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult InsertTable2(Table2Entity table2Entity,string keyValue)
        {
            tb.InsertTable(table2Entity, keyValue);
            return Success("TABLE2新增成功");
        }



        /// <summary>
        /// 实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetList()
        {          
                  
            var data = tb.GetForm();
            var jsonData = new
            {
                rows = data,
                statusName = "status", //数据状态的字段名称，默认：code
                statusCode = 0, //成功的状态码，默认：0
                msgName = "msg", //状态信息的字段名称，默认：msg
                countName = "total", //数据总数的字段名称，默认：count
                dataName = "rows" //数据列表的字段名称，默认：data

            };
            return Json(new {data}, JsonRequestBehavior.AllowGet);
         //return Json(jsonData, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 下拉
        /// </summary>
        /// <param name="LL_Id"></param>
        /// <returns></returns>
        public ActionResult GetSelect(string LL_Id)
        {
            var data = tb.GetSelect(LL_Id);
            var itmes = data.Select(t => new { id = t.F_Id, valeu = t.F_ididid });
            return Json(itmes, JsonRequestBehavior.AllowGet);         
        }
    }
}
