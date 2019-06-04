using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.ExampleManage
{
   public class PrintEntity:IEntity<PrintEntity>
    {
        #region 表单字段
        /// <summary>
        /// 主键
        /// </summary>
        public string F_Id { get; set; }
        /// <summary>
        /// 公司
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contacts { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 报价人
        /// </summary>
        public string Bidder { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
        #endregion

        #region 配置自动生成字段
        /// <summary>
        /// 创建人id
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateUserTime { get; set; }
        /// <summary>
        /// 标记是否删除
        /// </summary>
        public bool? DeleteMark { get; set; }
        /// <summary>
        /// 创建用户名
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 修改人用户名
        /// </summary>
        public string LastModifyUserName { get; set; }
        /// <summary>
        /// 修改人id
        /// </summary>
        public string LastModifyUserId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }
        #endregion

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
        #endregion

    }
}
