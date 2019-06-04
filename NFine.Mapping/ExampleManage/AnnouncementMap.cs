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
    /// Map映射数据库实体表
    /// </summary>
   public class AnnouncementMap: EntityTypeConfiguration<AnnouncementEntity>
    {
        public AnnouncementMap()
        {
            this.ToTable("MyAnnouncement");   //Map映射数据库实体表  * 一定要和数据库表字段对应
            this.HasKey(t => t.F_Id);   //Map映射数据库实体主键Id
        }

    }
}
