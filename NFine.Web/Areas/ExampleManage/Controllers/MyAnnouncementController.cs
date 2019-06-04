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
    public class MyAnnouncementController : ControllerBase
    {
        private AnnouncementApp announcementapp = new AnnouncementApp();  //调用AnnouncementApp层

        #region 我的公告视图层
        public override ActionResult Index()
        {
            return View();
        }
        public override ActionResult Form()
        {
            return View();
        }
        #endregion

        /// <summary>
        /// 查询公告列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetAnnouncement()
        {
            var data = announcementapp.GetAnnouncement();
            return Content(data.ToJson());           
        }
        /// <summary>
        /// 新增修改
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddAnnouncement(AnnouncementEntity Entity, string keyValue)
        {
            announcementapp.AddAnnouncement(Entity, keyValue);
            return Success("操作成功");
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="DeleteKeyID"></param>
        /// <returns></returns>
        public ActionResult DeleteAnnouncement(string DeleteKeyID)
        {
            announcementapp.DeleteAnnouncement(DeleteKeyID);
            return Success("操作成功");
        }
        /// <summary>
        /// 首页展示最新公告消息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAnnouncementCount()
        {
            var data =    announcementapp.GetAnnouncementCount();
            return Content(data.ToJson());
        }
    }
}
