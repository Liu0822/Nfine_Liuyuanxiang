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
   public class NewNumberApp
    {
        private INewNumberRepository service = new NewNumberRepository();
        /// <summary>
        /// 获取最新消息总数
        /// </summary>
        /// <returns></returns>
        public NewNumberEntity GetEntityNum()
        {
            return service.GetEntityNum();
        }
    }
}
