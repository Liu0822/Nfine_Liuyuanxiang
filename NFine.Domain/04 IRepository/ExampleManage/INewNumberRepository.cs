using NFine.Data;
using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._04_IRepository.ExampleManage
{
  public  interface INewNumberRepository: IRepositoryBase<NewNumberEntity>
    {
        /// <summary>
        /// 获取最新消息总数
        /// </summary>
        /// <returns></returns>
        NewNumberEntity GetEntityNum();
    }
}
