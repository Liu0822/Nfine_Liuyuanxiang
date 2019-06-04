using NFine.Data;
using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._04_IRepository.ExampleManage
{

   public interface IOrderRepository: IRepositoryBase<OrderEntity>
    {
        /// <summary>
        /// 彻底删除文件信息
        /// </summary>
        /// <param name="keyValue">主键</param>
      //  void DeletekeyValue(string keyValue);
    }
}
