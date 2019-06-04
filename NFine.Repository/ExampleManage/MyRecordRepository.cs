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
    public class MyRecordRepository : RepositoryBase<MyRecordEntity>, IMyRecordRepository
    {
        /// <summary>
        /// 仓储层，  L_MyRecord表数据 取当前用户id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public IEnumerable<MyRecordEntity> GetCustomByUserId(string UserId)
        {
            return this.IQueryable().Where(t => t.CreateUserId == UserId);
        }
    }
}
