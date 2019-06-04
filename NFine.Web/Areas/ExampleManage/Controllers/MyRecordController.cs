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
    public class MyRecordController : ControllerBase
    {
        private MyRecordApp MyRecordApp = new MyRecordApp();

        #region 视图页面
        public ActionResult MyRecordIndex()
        {
            return View();
        }
        public ActionResult MyRecordForm()
        {
            return View();
        }
        public ActionResult MyRecordDateils()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        ///列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetMyRecord()
        {
            var data = MyRecordApp.GetList();
            return Content(data.ToJson());
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetVoidMyRecordEntity(string keyValue)
        {
            var data = MyRecordApp.GetVoidMyRecordEntity(keyValue);
            return Content(data.ToJson());
        }
        #endregion

        #region 提交数据 删除数据
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
        public ActionResult SetRecord(MyRecordEntity myRecordEntity, string keyValue)
        {
            MyRecordApp.InsertRecord(myRecordEntity, keyValue);
            return Success("操作成功");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult DeleteForm(string keyValue)
        {
            MyRecordApp.DeleteForm(keyValue);
            return Success("操作成功");
        }
        #endregion

    }
}
