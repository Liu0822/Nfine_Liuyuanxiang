using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.ExampleManage
{
   public class A_OrganizeEntity: IEntity<A_OrganizeEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        /// <summary>
        /// A_Id
        /// </summary>
       public string F_Id { get; set; }
        /// <summary>
        /// A_父id
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// A_内容
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// A_Json数据
        /// </summary>
       public string Data { get; set; }

        public string F_CreatorUserId { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public bool? F_DeleteMark { get; set; }
        public string F_DeleteUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
    }
}
