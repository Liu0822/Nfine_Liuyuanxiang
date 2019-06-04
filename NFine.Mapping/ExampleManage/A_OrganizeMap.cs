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
    ///By. L 2018年9月6日 16:36:08  继承 EntityTypeConfiguration<A_OrganizeEntity>   Map映射数据库表，需对应数据库表，
    /// </summary>
    public class A_OrganizeMap : EntityTypeConfiguration<A_OrganizeEntity>
        {
            public A_OrganizeMap()
            {
                this.ToTable("A_Organize");
                this.HasKey(t => t.F_Id);
            }
    }
}
