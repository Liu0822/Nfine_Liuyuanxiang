using NFine.Application.ExampleManage;
using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain.Entity.SystemManage;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using NFine.Web.Areas.ExampleManage.Controllers;
namespace NFine.Web.Controllers
{
    [HandlerLogin]
    public class HomeController : Controller
    {
        private MyRecordApp MyRecordApp = new MyRecordApp();
        private SendMessagesApp smapp = new SendMessagesApp();  //最新消息
        #region 视图页面
        /// <summary>
        /// 左侧菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 内容部分
        /// </summary>
        /// <returns></returns>
        public ActionResult Default()
        {
            return View();
        }
        /// <summary>
        /// 关于视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
        /// <summary>
        /// 首页列表展示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DefaultDateils()
        {
            return View();
        }
        /// <summary>
        /// 图标模态查看表单
        /// </summary>
        /// <returns></returns>
        public ActionResult IconForm()
        {
            return View();
        }
        /// <summary>
        /// 快捷计算器
        /// </summary>
        /// <returns></returns>
        public ActionResult CalculatorForm()
        {
            return View();
        }
        /// <summary>
        /// 二维码生成
        /// </summary>
        /// <returns></returns>
        public ActionResult QRCodeForm()
        {
            return View();
        }
        #endregion
    }
}
