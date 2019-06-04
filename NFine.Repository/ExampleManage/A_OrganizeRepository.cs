using NFine.Data;
using NFine.Domain._03_Entity.ExampleManage;
using NFine.Domain._04_IRepository.ExampleManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Repository.ExampleManage
{
    /// <summary>
    /// by .L 2018年9月6日 16:07:40    仓储层继承RepositoryBase<A_OrganizeEntity>  IA_OrganizeRepository接口
    /// </summary>
    public class A_OrganizeRepository: RepositoryBase<A_OrganizeEntity>,IA_OrganizeRepository
    {
        public IEnumerable<A_OrganizeEntity> GetTreeJson()
        {
            return this.IQueryable();
        }
        public IEnumerable<A_OrganizeEntity> TreeJson()
        {
            return this.IQueryable();
        }
    }
}
