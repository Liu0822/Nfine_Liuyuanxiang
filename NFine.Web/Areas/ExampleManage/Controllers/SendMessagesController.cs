using NFine.Application.ExampleManage;
using NFine.Code;
using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/**                              _  
 *  _._ _..._ .-',     _.._(`))  
 * '-. `     '  /-._.-'    ',/  
 *    )         \            '.  
 *   / _    _    |             \  
 *  |  a    a    /              |  
 *  \   .-.                     ;  
 *   '-('' ).-'       ,'       ;  
 *      '-;           |      .'  
 *         \           \    /  
 *         | 7  .__  _.-\   \  
 *         | |  |  ``/  /`  /  
 *        /,_|  |   /,_/   /  
 *           /,_/      '`-'  
 */
namespace NFine.Web.Areas.ExampleManage.Controllers
{
    /// <summary>
    /// 测试内容控制器 -  
    /// </summary>
    public class SendMessagesController : ControllerBase
    {     
      private SendMessagesApp  sendMessagesApp = new SendMessagesApp();
        #region 获取数据
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        //    [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = sendMessagesApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        /// <summary>
        /// 获取表单  -  列表 用户桌面展示最新5条
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormTableJson(string keyword)
        {
            var data = sendMessagesApp.GetList(keyword);
            return Content(data.ToJson());
        }
        /// <summary>
        /// 查询列表全部数据
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormTableCountJson(string keyword)
        {
            var data = sendMessagesApp.GetFormTableCountJson(keyword);
            return Content(data.ToJson());
        }
        /// <summary>
        /// 列表(邮件使用) 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSqlTable()
        {
            var data = sendMessagesApp.GetSqlTable();
            return Content(data.ToJson());
        }
        /// <summary>
        /// 滚动消息
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult GetNumJson(string keyValue)
        {
            var data = sendMessagesApp.GetNum(keyValue);
            return Content(data.ToJson());
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 新增,修改操作
        /// </summary>
        /// <param name="sendMessagesEntity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>      
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult InsertNotice(SendMessagesEntity sendMessagesEntity, string keyValue)
        {
            sendMessagesApp.InsertNotice(sendMessagesEntity, keyValue);
            return Success("操作成功");
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteForm(string keyValue)
        {
            sendMessagesApp.DeleteForm(keyValue);
            return Success("操作成功");
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult ChangeState(string keyValue)
        {
            sendMessagesApp.ChangeState(keyValue);
            return Success("操作成功");
        }
        #endregion
    }
}
