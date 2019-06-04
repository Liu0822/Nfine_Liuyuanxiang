using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.ExampleManage
{
    /// <summary>
    /// (Map数据映射) 公告通知
    /// </summary>
    public class SendMessagesMap : EntityTypeConfiguration<SendMessagesEntity>
    {
        public SendMessagesMap()
        {           
            this.ToTable("L_SendMessages");
            this.HasKey(t => t.F_Id);
        }       
    }
}
