using NFine.Code;
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
    /// <summary>
    /// 我的记录 -  
    /// </summary>
   public class MyRecordApp
    {
        private IMyRecordRepository service = new MyRecordRepository();  //应用层调用

        /// <summary>
        /// L_MyRecord表 业务层
        /// </summary>
        /// <param name="verification"></param>
        /// <returns></returns>
        public IEnumerable<MyRecordEntity> GetCustomByUserId(bool verification)
        {
            return service.GetCustomByUserId(OperatorProvider.Provider.GetCurrent().UserId);
        }


        /// <summary>
        ///实体列表  - 查询最新5条数据
        /// </summary>
        /// <returns></returns>
        public List<MyRecordEntity> GetList()
        {
            //按降序展示
            return service.IQueryable().OrderByDescending(t => t.CreateUserTime).Take(5).ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public MyRecordEntity GetVoidMyRecordEntity(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.F_Id == keyValue);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="myRecordEntity">实体</param>
        /// <param name="keyValue">主键</param>
        public void InsertRecord(MyRecordEntity myRecordEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                myRecordEntity.Modify(keyValue);
                service.Update(myRecordEntity);
            }
            else
            {
                myRecordEntity.Create();
                service.Insert(myRecordEntity);
            }
        }
    }
}
