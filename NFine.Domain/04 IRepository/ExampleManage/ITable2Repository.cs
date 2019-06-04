using NFine.Data;
using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._04_IRepository.ExampleManage
{
   public interface ITable2Repository : IRepositoryBase<Table2Entity>
    {
        IEnumerable<Table2Entity> GetSelect(string LL_Id);
    }
}
