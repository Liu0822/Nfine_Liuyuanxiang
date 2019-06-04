using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.ExampleManage
{
  public  class OrderMap: EntityTypeConfiguration<OrderEntity>
    {
        public OrderMap()
        {
            this.ToTable("Table_1");
            this.HasKey(t => t.F_Id);
        }
    }
}
