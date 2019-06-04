using NFine.Domain._03_Entity.ExampleManage;
using NFine.Domain._04_IRepository.ExampleManage;
using NFine.Repository.ExampleManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.ExampleManage
{ 
  public  class Table2App
    {
        private ITable2Repository service = new Table2Repository();
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="table2Entity">实体</param>
        /// <param name="keyValue">主键</param>
        public void InsertTable(Table2Entity table2Entity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                table2Entity.Modify(keyValue);
                service.Update(table2Entity);
            }
            else
            {
                table2Entity.Create();
                service.Insert(table2Entity);
            }
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>       
        public List<Table2Entity> GetForm()
        {
            // return service.IQueryable().ToList();
            return service.IQueryable().OrderByDescending(t => t.F_CreatorTime).ToList();
        }


        /// <summary>
        /// 下拉
        /// </summary>
        /// <param name="LL_Id"></param>
        /// <returns></returns>
        public IEnumerable<Table2Entity> GetSelect(string LL_Id)
        {
            return service.GetSelect(LL_Id);
        }
    }
}
