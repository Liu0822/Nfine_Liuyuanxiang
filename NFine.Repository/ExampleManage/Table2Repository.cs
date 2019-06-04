using NFine.Data;
using NFine.Domain._03_Entity.ExampleManage;
using NFine.Domain._04_IRepository.ExampleManage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Repository.ExampleManage
{
   public  class Table2Repository : RepositoryBase<Table2Entity>,ITable2Repository
    {

        public IEnumerable<Table2Entity> GetSelect(string LL_Id)
        {
            string sql = "select F_Id,F_ididid from Table_2 where LL_id=@LL_Id";
            DbParameter[] parameter =
          {
                 new SqlParameter("@LL_Id",LL_Id)
            };
            return this.FindList(sql.ToString(), parameter);
           
        }      
    }
}
