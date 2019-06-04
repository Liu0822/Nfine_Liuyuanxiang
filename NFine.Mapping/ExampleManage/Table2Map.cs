using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.ExampleManage
{
   public class Table2Map : EntityTypeConfiguration<Table2Entity>
    {
        public Table2Map()
        {
            this.ToTable("Table_2");
            this.HasKey(t => t.F_Id);
        }
    }
}
