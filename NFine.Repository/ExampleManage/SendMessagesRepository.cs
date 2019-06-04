using NFine.Data;
using NFine.Domain._03_Entity.ExampleManage;
using NFine.Domain._04_IRepository.ExampleManage;
using NFine.Domain.IRepositoryBase.SystemManage;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace NFine.Repository.ExampleManage
{
    /// <summary>
    /// (实现仓储  服务层)  定义接口写方法，没有业务逻辑可不走这一层写
    /// </summary>
    public class SendMessagesRepository : RepositoryBase<SendMessagesEntity>, ISendManagesRepository
    {
        /// <summary>
        /// 查询最新3条数据并查询状态为0的邮件
        /// </summary>
        /// <returns></returns>
        public List<SendMessagesEntity> GetSqlTable()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT   TOP  3 *  
                                                  FROM  [dbo].[L_Sendmessages]   WHERE State = 0 ORDER BY   CreateUserTime  DESC");
            return this.FindList(sb.ToString());
        }
    }
}
