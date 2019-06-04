using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.ExampleManage
{
    public class AnnouncementEntity : IEntity<AnnouncementEntity> , ICreationAudited, IDeleteAudited, IModificationAudited
    {
        /// <summary>
        /// 公告主键
        /// </summary>
        public string F_Id { get; set; }
        /// <summary>
        /// 公告标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 公告内容
        /// </summary>
        public string Contents { get; set; }
        /// <summary>
        ///类别
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string files { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public bool? F_DeleteMark { get; set; }
        public string F_DeleteUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }



        //#region 扩展方法    新增修改
        ///// <summary>
        ///// 新增
        ///// </summary>
        //public new void Create()
        //{
        //    this.F_Id = Guid.NewGuid().ToString();
        //    this.CreateUserTime = DateTime.Now;
        //    this.CreateUserId = OperatorProvider.Provider.GetCurrent().UserId;
        //    this.CreateUserName = OperatorProvider.Provider.GetCurrent().UserName;
        //    this.DeleteMark = false;
        //}
        ///// <summary>
        ///// 修改
        ///// </summary>
        ///// <param name="keyValue"></param>
        //public new void Modify(string keyValue)
        //{
        //    this.F_Id = keyValue;
        //    this.LastModifyTime = DateTime.Now;
        //    this.LastModifyUserId = OperatorProvider.Provider.GetCurrent().UserId;
        //    this.LastModifyUserName = OperatorProvider.Provider.GetCurrent().UserName;
        //}
        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="keyValue"></param>
        ////public  void Delete(string keyValue)
        ////{
        ////    this.F_Id = keyValue;
        ////    this.DeleteTime = DateTime.Now;
        ////    this.DeleteUserId = OperatorProvider.Provider.GetCurrent().UserId;
        ////    this.DeleteMark = true; //是否删除
        ////}
        //#endregion
    }
}
