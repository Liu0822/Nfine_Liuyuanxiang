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
    public class NewNumberRepository : RepositoryBase<NewNumberEntity>, INewNumberRepository
    {
        /// <summary>
        /// 获取首页最新消息总数
        /// </summary>
        /// <returns></returns>
        public NewNumberEntity GetEntityNum()
        {
            string sql = "SELECT COUNT(1) AS 'NewNumber' from [dbo].[L_Sendmessages] WHERE State = 0";
            return this.FindList(sql).FirstOrDefault();
         //   return this.FindEntity(sql.ToString());      
        }   
    }
}
