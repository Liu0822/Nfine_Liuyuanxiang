/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.ExampleManage.Controllers
{
    public class SendMailController : ControllerBase
    {
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]     
        public ActionResult SendMail(string account, string title, string content)
        {
            // 统一从system.config配置
            MailHelper mail = new MailHelper();
            mail.MailServer = Configs.GetValue("smtp");   //主机   使用QQ主机 -smtp.qq.com
            mail.MailUserName = Configs.GetValue("Email");// 设置发件人地址
            mail.MailPassword = Configs.GetValue("MiMa");      //授权码 = 密码
            mail.Send(account,title,content);    //获取三个参数
            return Success("发送成功， 注意查收QQ邮箱");
        }
    }
}
