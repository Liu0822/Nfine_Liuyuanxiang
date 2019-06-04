using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.ExampleManage
{
    public class Table2Entity : IEntity<Table2Entity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string F_Id { get; set; }  
        public string F_ididid { get; set; }
        public string F_iddididddd { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public bool? F_DeleteMark { get; set; }
        public string F_DeleteUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
    }
}
