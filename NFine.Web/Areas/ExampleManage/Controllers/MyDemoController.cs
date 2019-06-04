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
    public class MyDemoController : ControllerBase
    {
        /// <summary>
        /// By.L 2018年9月6日 16:23:28 调用APP层方法实现操作
        /// </summary>
        private A_OrganizeApp a_organizeapp = new A_OrganizeApp(); 

        #region 视图1
        public ActionResult OneDemoIndex()
        {
            return View();
        }
        public ActionResult OneDemoForm()
        {
            return View();
        }
        #endregion
        public ActionResult TwoDemoIndex()
        {
            return View();
        }
        public ActionResult ThreeDemoIndex()
        {
            return View();
        }
        #region 获取数据
        /// <summary>
        /// 获取下拉数据
        /// </summary>
        /// <returns></returns>
        public JsonResult TreeJson()
        {          
            var datajson = a_organizeapp.TreeJson().Select(t => new { id = t.F_Id, text = t.Code , parentid = t.ParentId});  //Select是将重新映射一张表返回，  Where是传到后台数据赋值给实体字段
            var jsonData = new { TreeJson = datajson }; return Json(jsonData);
        }
        /// <summary>
        /// 新增树
        /// </summary>
        /// <param name="a_organizeEntity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult InsertTree(A_OrganizeEntity a_organizeEntity, string keyValue)
        {
            a_organizeapp.InsertTree(a_organizeEntity, keyValue);
            return Success("操作成功。");
        }
        /// <summary>
        /// 查询树列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTreeJson()
        {
            var Data = a_organizeapp.GetTreeJson();
            return Content(Data.ToJson());
        }



        /// <summary>
        /// 查询获取树结构
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson()
        {
            var data = a_organizeapp.GetTreeJson();  //查询机构数据
            var treeList = new List<TreeSelectModel>();
            foreach (A_OrganizeEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.Code;
                treeModel.parentId = item.ParentId;
                treeModel.data = item;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());   //将树数据返回进TreeSelectJson方法
        }

        #endregion
    }
}
