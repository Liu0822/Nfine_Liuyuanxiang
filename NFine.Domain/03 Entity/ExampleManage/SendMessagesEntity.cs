using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.ExampleManage
{
   /// <summary>
   /// (定义实体)通知
   /// </summary>
    public class SendMessagesEntity : IEntity<SendMessagesEntity>//, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string F_Id { get; set; }
        /// <summary>
        /// L_MyRecord表主键id
        /// </summary>
        public string MyRecordID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>   
        public string L_Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string L_Centent { get; set; }
        /// <summary>
        /// 状态0未读，1已读
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 创建人id
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建用户名
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateUserTime { get; set; }
        /// <summary>
        /// 是否删除标记
        /// </summary>
        public bool? DeleteMark { get; set; }       
        /// <summary>
        /// 修改人id
        /// </summary>
        public string LastModifyUserId { get; set; }
        /// <summary>
        /// 修改人名称
        /// </summary>
        public string LastModifyUserName { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        #region 扩展方法    
        /// <summary>
        /// 新增
        /// </summary>
        public new void Create()
        {    
            this.F_Id = Guid.NewGuid().ToString();
            this.CreateUserTime = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.GetCurrent().UserId;
            this.CreateUserName = OperatorProvider.Provider.GetCurrent().UserName;
            this.State = 0; //新增默认状态未读
            this.DeleteMark = false;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="keyValue"></param>
        public new void Modify(string keyValue)
        {
            this.F_Id = keyValue;
            this.LastModifyTime = DateTime.Now;
            this.LastModifyUserId = OperatorProvider.Provider.GetCurrent().UserId;
            this.LastModifyUserName = OperatorProvider.Provider.GetCurrent().UserName;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue"></param>
        //public  void Delete(string keyValue)
        //{
        //    this.F_Id = keyValue;
        //    this.DeleteTime = DateTime.Now;
        //    this.DeleteUserId = OperatorProvider.Provider.GetCurrent().UserId;
        //    this.DeleteMark = true; //是否删除
        //}
        #endregion

    }
}
