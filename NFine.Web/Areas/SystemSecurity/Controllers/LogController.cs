/**  
 *   ┏┓　　　┏┓  
 * ┏┛┻━━━┛┻┓  
 * ┃　　　　　　　┃  
 * ┃　　　━　　　┃  
 * ┃　＞　　　＜　┃  
 * ┃　　　　　　　┃  
 * ┃...　⌒　...　┃  
 * ┃　　　　　　　┃  
 * ┗━┓　　　┏━┛  
 *     ┃　　　┃　  
 *     ┃　　　┃  
 *     ┃　　　┃  
 *     ┃　　　┃  神兽保佑  
 *     ┃　　　┃  代码无bug　　  
 *     ┃　　　┃  
 *     ┃　　　┗━━━┓  
 *     ┃　　　　　　　┣┓  
 *     ┃　　　　　　　┏┛  
 *     ┗┓┓┏━┳┓┏┛  
 *       ┃┫┫　┃┫┫  
 *       ┗┻┛　┗┻┛  
 */
using NFine.Application.SystemSecurity;
using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.SystemSecurity.Controllers
{
    public class LogController : ControllerBase
    {
        private LogApp logApp = new LogApp();

        /// <summary>
        /// 系统日志视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RemoveLog()
        {
            return View();
        }
        /// <summary>
        /// 系统日志log  列表展示
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">参数查询</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = logApp.GetList(pagination, queryJson),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        /// <summary>
        /// 系统日志log
        /// </summary>
        /// <param name="queryJson">参数查询</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetGridJsonData(string queryJson)
        {
            var data = logApp.GetList(queryJson);
            return Content(data.ToJson());
        }
        /// <summary>
        /// 系统日志清空按钮
        /// </summary>
        /// <param name="keepTime"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRemoveLog(string keepTime)
        {
            logApp.RemoveLog(keepTime);
            return Success("清空成功。");
        }
    }
}
