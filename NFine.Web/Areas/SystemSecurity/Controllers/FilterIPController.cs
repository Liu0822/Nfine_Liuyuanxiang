/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Application.SystemSecurity;
using NFine.Code;
using NFine.Domain.Entity.SystemSecurity;
using System.Web.Mvc;

namespace NFine.Web.Areas.SystemSecurity.Controllers
{
    public class FilterIPController : ControllerBase
    {
        private FilterIPApp filterIPApp = new FilterIPApp();

        /// <summary>
        /// 访问控制  列表查询，展示(GetList)
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            var data = filterIPApp.GetList(keyword);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = filterIPApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        /// <summary>
        /// 访问控制 新增，修改操作
        /// </summary>
        /// <param name="filterIPEntity">实体</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(FilterIPEntity filterIPEntity, string keyValue)
        {
            filterIPApp.SubmitForm(filterIPEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            filterIPApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}
