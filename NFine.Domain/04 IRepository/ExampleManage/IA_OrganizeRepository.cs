using NFine.Code;
using NFine.Data;
using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._04_IRepository.ExampleManage
{
    /// <summary>
    ///  by.L  2018年9月6日 16:18:53  接口 - 在服务层实现方法
    /// </summary>
    public interface IA_OrganizeRepository : IRepositoryBase<A_OrganizeEntity>
    {
        IEnumerable<A_OrganizeEntity> TreeJson();
        IEnumerable<A_OrganizeEntity> GetTreeJson();
    }
}
