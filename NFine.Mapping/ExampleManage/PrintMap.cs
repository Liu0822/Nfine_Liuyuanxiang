using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.ExampleManage
{
    public class PrintMap: EntityTypeConfiguration<PrintEntity>
    {
        /// <summary>
        /// 清单 （实体映射）
        /// </summary>
        public PrintMap()
        {
            this.ToTable("DetailedList");
            this.HasKey(t => t.F_Id);
        }

    }
}
