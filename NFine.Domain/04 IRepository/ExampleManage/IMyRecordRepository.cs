using NFine.Data;
using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._04_IRepository.ExampleManage
{
    /// <summary>
    /// 我的记录 -  定义领域   接口层
    /// </summary>
  public  interface IMyRecordRepository: IRepositoryBase<MyRecordEntity>
    {
        /// <summary>
        /// 获取当前用户的信息
        /// </summary>
        /// <param name="UserId">用户id</param>
        /// <returns></returns>
        IEnumerable<MyRecordEntity> GetCustomByUserId(string UserId);
    }
}
