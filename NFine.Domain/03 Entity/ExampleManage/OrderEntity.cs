using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.ExampleManage
{
    public class OrderEntity : IEntity<OrderEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        /// <summary>
        ///主键
        /// </summary>
        public string F_Id { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string L_FileName { get; set; }
        /// <summary>
        /// 文件后缀（带点的）
        /// </summary>
        public string L_FileSuffix { get; set; }
        /// <summary>
        /// 文件后缀类型(不带点的)
        /// </summary>
        public string L_FileType { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public string L_FileSize { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string L_FilePath { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public bool? F_DeleteMark { get; set; }
        public string F_DeleteUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
    }
}
