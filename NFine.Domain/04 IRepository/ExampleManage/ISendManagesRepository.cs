using NFine.Data;
using NFine.Domain._03_Entity.ExampleManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._04_IRepository.ExampleManage
{
    /// <summary>
    /// 定义仓储 -  定义接口 生成SendManagesRepository方法
    /// </summary>
    public interface ISendManagesRepository: IRepositoryBase<SendMessagesEntity>
    {
        /// <summary>
        /// 最新邮件sql语句
        /// </summary>
        /// <returns></returns>
        List<SendMessagesEntity> GetSqlTable();    
           //DataTable GetSqlTableDataTable();
    }
}
