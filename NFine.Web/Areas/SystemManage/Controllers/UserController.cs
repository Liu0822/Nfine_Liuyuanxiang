/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain.Entity.SystemManage;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class UserController : ControllerBase
    {
        private UserApp userApp = new UserApp(); //用户
        private UserLogOnApp userLogOnApp = new UserLogOnApp(); //日志

        /// <summary>
        /// 用户实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult GetUser(string keyValue)
        {
            var data = userApp.GetUser(keyValue);
            return Content(data.ToJson());
                
        }
        /// <summary>
        /// 用户管理列表查询展示
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="keyword">查询参数</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = userApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        /// <summary>
        /// 用户实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = userApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        /// <summary>
        ///新增，修改
        /// </summary>
        /// <param name="userEntity"></param>
        /// <param name="userLogOnEntity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            userApp.SubmitForm(userEntity, userLogOnEntity, keyValue);
            return Success("操作成功。");
        }
        /// <summary>
        /// 用户头像上传
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadFile()
        {
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            if (files[0].ContentLength == 0 || string.IsNullOrEmpty(files[0].FileName)) //判断文件大小
            {
                return HttpNotFound();
            }
            string FileEextension = Path.GetExtension(files[0].FileName); //获取文件的路径
            string UserId = OperatorProvider.Provider.GetCurrent().UserId; //获取当前用户
          //  string me = "头像文件";
            string virtualPath = string.Format("/Resource/PhotoFile/{0}{1}", UserId, FileEextension); //拼接命名文件的名字
            string fullFileName = Server.MapPath("~" + virtualPath);
            string path = Path.GetDirectoryName(fullFileName); //创建文件夹，保存文件
            Directory.CreateDirectory(path);
            files[0].SaveAs(fullFileName);
            UserEntity u = new UserEntity
            {
                F_Id = OperatorProvider.Provider.GetCurrent().UserId,
                F_HeadIcon = virtualPath  //把文件名赋值给头像字段
            };
            userApp.SubmitForm1(u, u.F_Id);
            return Success("上传成功");            

        }
        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            userApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
        [HttpGet]
        public ActionResult RevisePassword()
        {
            return View();
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRevisePassword(string userPassword, string keyValue)
        {
            userLogOnApp.RevisePassword(userPassword, keyValue);
            return Success("重置密码成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DisabledAccount(string keyValue)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.F_Id = keyValue;
            userEntity.F_EnabledMark = false;
            userApp.UpdateForm(userEntity);
            return Success("账户禁用成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult EnabledAccount(string keyValue)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.F_Id = keyValue;
            userEntity.F_EnabledMark = true;
            userApp.UpdateForm(userEntity);
            return Success("账户启用成功。");
        }

        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }
    }
}
