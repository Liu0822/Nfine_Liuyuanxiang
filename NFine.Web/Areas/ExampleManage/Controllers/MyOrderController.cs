using NFine.Application.ExampleManage;
using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain._03_Entity.ExampleManage;
using NFine.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.ExampleManage.Controllers
{
    public class MyOrderController : ControllerBase
    {
        private OrderApp odapp = new OrderApp();  //文件管理
        private UserApp user = new UserApp();//用户信息

        #region 文件管理自定义参数
        /// <summary>
        /// 配置文件信息字段
        /// </summary>
        private class File
        {
            /// <summary>
            /// 主键
            /// </summary>		
            public string F_Id { get; set; }
            /// <summary>
            /// 文件名
            /// </summary>		
            public string L_FileName { get; set; }

            ///// <summary>
            ///// 文件保存时间
            ///// </summary>
            //public string datetime { get; set; }
        }
        #endregion

        #region 视图页面
        /// <summary>
        /// 视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OrderIndex()
        {
            ViewBag.UserId = OperatorProvider.Provider.GetCurrent().UserCode;
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 新增 Table - 1
        /// </summary>
        /// <param name="orderEntity"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(OrderEntity orderEntity, string keyValue)
        {
            odapp.Insert(orderEntity, keyValue);
            return Success("新增成功");
        }

        /// <summary>
        /// 查询最新5条数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson()
        {
            var data = odapp.GetList();
            return Content(data.ToJson());
        }
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormCountJson()
        {
            var data = odapp.GetFormCountJson();
            return Content(data.ToJson());
        }
        /// <summary>
        ///  列表删除
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteForm(string keyValue)
        {
            odapp.DeleteFile(keyValue);
            return Success("操作成功");
        }
        #endregion

        #region 附件上传 删除附件
        /// <summary>
        /// 附件上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadFile(string keyValue)
        {
            OrderEntity fileInfoEntity = new OrderEntity();
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            if (files.Count < 0)  //判断文件是否小于0
            {
                return HttpNotFound();
            }
            //if (files[0].ContentLength == 0 || string.IsNullOrEmpty(files[0].FileName)) //判断获取文件大小，和文件名
            //{
            //    return HttpNotFound();
            //}
            List<File> list = new List<File>();  //实例化集合
            for (int i = 0; i < files.Count; i++)
            {
                #region 文件上传配置           
                string FileEextension = Path.GetExtension(files[i].FileName); //获取文件后缀
                string UserId = OperatorProvider.Provider.GetCurrent().UserId; //获取当前用户id
                string fileGuid = Guid.NewGuid().ToString(); //生成一个guid命名
                string datetime = DateTime.Now.ToString("yyyy-MM-dd"); //生成时间命名文件夹
                string virtualPath = string.Format("/Resource/File/{0}/{1}{2}", datetime, fileGuid, FileEextension); //创建文件路径
                string fullFileName = Server.MapPath("~" + virtualPath); //获取整个项目所在路径
                string path = Path.GetDirectoryName(fullFileName); //项目路径 - 不包括文件名
                Directory.CreateDirectory(path);
                #endregion

                #region 确定指定文件是否存在，返回array
                if (!System.IO.File.Exists(fullFileName))
                {
                    File arrlist = new File();
                    arrlist.F_Id = fileInfoEntity.F_Id;
                    arrlist.L_FileName = files[i].FileName;
                    list.Add(arrlist);
                }
                #endregion
                //保存文件
                files[0].SaveAs(fullFileName);
                #region 数据对应到实体里               
                //    fileInfoEntity.Create();
                fileInfoEntity.F_Id = fileGuid;
                fileInfoEntity.L_FileName = files[i].FileName;  //文件名
                fileInfoEntity.L_FilePath = virtualPath;   //文件路径
                fileInfoEntity.L_FileSize = Convert.ToString(files[0].ContentLength);  //文件大小
                fileInfoEntity.L_FileSuffix = FileEextension;  //后缀名
                fileInfoEntity.L_FileType = FileEextension.Replace(".", "");  //截取文件后缀的点.     
                odapp.Insert(fileInfoEntity, keyValue);
                #endregion

            }
            string msg = string.Format("上传成功");
            return Success(msg, list);  //返回消息和文件集合
        }
        /// <summary>
        /// 删除上传后的文件
        /// </summary>
        /// <param name="keyValue">主键id</param>
        /// <param name="FileName">文件名</param>
        /// <returns></returns>
        public ActionResult DeleteFile(string FileName)
        {
            string userId = OperatorProvider.Provider.GetCurrent().UserId;
            string FileEextension = Path.GetExtension(FileName);
            string datetime = DateTime.Now.ToString("yyyy-MM-dd"); //生成时间命名文件夹
            string urlPath = string.Format("/Resource/File/{0}/{1}{2}", datetime, FileName, FileEextension);  //找到文件路径
            string localPath = HttpRuntime.AppDomainAppPath + urlPath;
            //判断路径下的文件是否存在
            if (System.IO.File.Exists(localPath))
            {
                FileInfo fi = new FileInfo(localPath);
                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                    fi.Attributes = FileAttributes.Normal;
                //删除附件路径
                System.IO.File.Delete(localPath);
                //删除文件数据            
                odapp.DeleteFile(FileName);
                return Json(true);
            }
            return Json(false);
        }
        #endregion

        #region 附件上传案例
        /// <summary>
        /// 上传附件案例()
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public ActionResult FileUP(HttpPostedFileBase file)
        {
            var files = Request.Files;
            if (files != null && files.Count > 0)
            {
                #region  执行多个文件上传  
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase fileitem = files[i];
                    //判定文件的大小  
                    string strExtension = Path.GetExtension(fileitem.FileName);
                    double dFileSize = fileitem.ContentLength;
                    if (dFileSize > 5242880)//1024*1024*5)  
                    {
                        return Content("<script>alert('" + fileitem.FileName + "文件大于5MB')</script>");
                    }
                    else
                    {
                        //创建文件  
                        string filePath = "~/images/Student/";
                        Directory.CreateDirectory(Server.MapPath(filePath));
                        //创建唯一的文件名  
                        string fileName = Guid.NewGuid().ToString();
                        string fFullDir = filePath + fileName + strExtension;
                        fileitem.SaveAs(Server.MapPath(fFullDir));
                    }
                }
                #endregion
            }
            else
            {
                #region 执行单个文件上传  
                if (file != null)
                {
                    //可以判断它的大小格式  
                    //创建文件夹  
                    string filePath = "~/images/Student/";
                    Directory.CreateDirectory(Server.MapPath(filePath));
                    //string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");  
                    string fileName = Guid.NewGuid().ToString();
                    file.SaveAs(Server.MapPath(filePath + fileName + ".png"));
                    return Content("<script>alert('上传成功！');location.href="
                        + Url.Content(filePath) + "</script>");
                }
                #endregion
            }
            return View();
        }
        #endregion
     
    }
}