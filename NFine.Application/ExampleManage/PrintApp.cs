using NFine.Data;
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
    public  class PrintApp : RepositoryBase
    {
        /// <summary>
        /// 新增/修改操作
        /// </summary>
        /// <param name="Print"></param>
        /// <param name="keyValue"></param>
        public void SaveForm(PrintEntity Print, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                Print.Modify(keyValue);
                Update(Print);            
            }
            else
            {
                Print.Create();
                Insert(Print);
            }
        }
    }
}
