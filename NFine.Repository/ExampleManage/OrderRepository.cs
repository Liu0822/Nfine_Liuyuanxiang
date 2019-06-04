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
   public class OrderRepository : RepositoryBase<OrderEntity>, IOrderRepository
    {    
        /// <summary>
        /// 彻底删除文件
        /// </summary>
        /// <param name="keyValue">主键</param>
        //public void ThoroughRemoveForm(string keyValue)
        //{
           
      
        //}
    }
}
