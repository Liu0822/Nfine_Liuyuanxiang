using NFine.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.ExampleManage
{
    /// <summary>
    /// 定义实体 -  我的记录
    /// </summary>
    public class MyRecordEntity : IEntity<MyRecordEntity>//, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string F_Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string L_Title { get; set; } 
        /// <summary>
        /// 内容
        /// </summary>
        public string L_Centent { get; set; }
        /// <summary>
        /// 预备字段1
        /// </summary>
        public string L_Field1 { get; set; }
        /// <summary>
        /// 预备字段2
        /// </summary>
        public string L_Field2 { get; set; }

        public string CreateUserId { get; set; }
        public DateTime? CreateUserTime { get; set; }
        public bool? DeleteMark { get; set; } 
        public string CreateUserName { get; set; }
        public string LastModifyUserName { get; set; }
        public string LastModifyUserId { get; set; }
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
