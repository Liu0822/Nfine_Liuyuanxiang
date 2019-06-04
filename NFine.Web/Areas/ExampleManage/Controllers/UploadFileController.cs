using NFine.Application.ExampleManage;
using NFine.Code;
using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.ExampleManage.Controllers
{
    public class UploadFileController : ControllerBase
    {
        private OrderApp addfile = new OrderApp();  //文件管理
        /// <summary>
        /// 自定义字段
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
            /// <summary>
            /// 路径
            /// </summary>
            public string L_FilePath { get; set; }

            /// <summary>
            /// 后缀
            /// </summary>
            public string L_FileType { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadFileIndex()
        {
            return View();
        }

        public ActionResult Test4()
        {
            return View();
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ActionResult GetFile(string keyValue)
        {
            var data = addfile.GetForm(keyValue);
            return Content(data.ToJson());
        }

        /// <summary>
        /// 上传图片显示
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        [HttpPost]
        public ActionResult UploadFileData(string keyValue)
        {
            try
            {
                HttpFileCollection httpfile = System.Web.HttpContext.Current.Request.Files;
                if (httpfile.Count<0)
                {
                    return HttpNotFound();
                }
                List<File> list = new List<File>();  //自定义字段前台传什么字段
                for (int i = 0; i < httpfile.Count; i++)
                { 
                    string FileEextension = Path.GetExtension(httpfile[i].FileName);  //后缀
                    string UserId = OperatorProvider.Provider.GetCurrent().UserId; //获取当前用户
                    string fileGuid = Guid.NewGuid().ToString(); //guid
                    string datetime = DateTime.Now.ToString("yyyy-MM-dd"); //本机时间
                    string virtualPath = string.Format("/Resource/FileInfo/{0}/{1}{2}", datetime, fileGuid, FileEextension); //创建完整文件路径
                    string fullFileName = Server.MapPath("~"+ virtualPath);
                    string path = Path.GetDirectoryName(fullFileName);
                    Directory.CreateDirectory(path);
                    #region 返回自定义参数
                    if (!System.IO.File.Exists(fullFileName))
                    {
                        File file = new File();
                        file.F_Id = fileGuid;
                        file.L_FileName = httpfile[i].FileName;
                        file.L_FilePath = virtualPath;
                        file.L_FileType = FileEextension;
                        list.Add(file);
                    }
                    #endregion
                    httpfile[0].SaveAs(fullFileName);  //保存文件信息
                    #region 对应传参
                    OrderEntity fileInfo = new OrderEntity();
                    fileInfo.F_Id = fileGuid;
                    fileInfo.L_FileName = httpfile[i].FileName;
                    fileInfo.L_FilePath = virtualPath;   //文件路径
                    fileInfo.L_FileSize = Convert.ToString(httpfile[0].ContentLength);  //文件大小
                    fileInfo.L_FileSuffix = FileEextension;  //后缀名
                    fileInfo.L_FileType = FileEextension.Replace(".", "");  //截取文件后缀的点.  
                    addfile.Insert(fileInfo, keyValue);
                    #endregion
                }
                string msg = string.Format("上传成功");
                return Success(msg, list);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
