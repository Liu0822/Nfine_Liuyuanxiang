using NFine.Code;
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
   public class OrderApp
    {
        private IOrderRepository service = new OrderRepository();
        private ITable2Repository service2 = new Table2Repository();
        /// <summary>
        /// 新增Table - 1
        /// </summary>
        /// <param name="orderEntity"></param>
        /// <param name="keyValue"></param>
        public void Insert(OrderEntity orderEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                orderEntity.Modify(keyValue);
                service.Update(orderEntity);
            }
            else
            {
                orderEntity.Create();
                service.Insert(orderEntity);
            }
        }
        /// <summary>
        ///查询最新5条数据，文件管理
        /// </summary>
        /// <returns></returns>
        public List<OrderEntity> GetList()
        {
            //按降序展示
            // return service.IQueryable().ToList();
            return service.IQueryable().OrderByDescending(t => t.F_CreatorTime).Take(5).ToList();
        }

        /// <summary>
        /// 查询全部数据 - 文件管理
        /// </summary>
        /// <returns></returns>
        public List<OrderEntity> GetFormCountJson()
        {
            return service.IQueryable().OrderByDescending(t => t.F_CreatorTime).ToList();
        }
        /// <summary>
        /// 删除文件信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void DeleteFile(string keyValue)
        {
            service.Delete(t => t.F_Id == keyValue);           
        }

        /// <summary>
        /// 获取实体， 下拉
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public OrderEntity GetForm(string F_Id)
        {
            return service.FindEntity(F_Id);
        }


        /// <summary>
        /// 文件实体
        /// </summary>
        /// <param name="F_Id"></param>
        /// <returns></returns>
        public OrderEntity GetFileForm(string F_CreatorUserId)
        {
            return service.FindEntity(F_CreatorUserId);
        }

    }
}
