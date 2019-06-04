using NFine.Code;
using NFine.Domain._03_Entity.ExampleManage;
using NFine.Domain._04_IRepository.ExampleManage;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepositoryBase.SystemManage;
using NFine.Repository.ExampleManage;
using NFine.Repository.SystemManage;
using System.Collections.Generic;
using System.Linq;

namespace NFine.Application.ExampleManage
{
    /// <summary>
    /// application   - 应用业务层
    /// </summary>

    public class SendMessagesApp
    {
        /// <summary>
        ///   测试内容
        /// </summary>
        private ISendManagesRepository service = new SendMessagesRepository();
        private IUserRepository users = new UserRepository();
        /// <summary>
        /// 测试内容 -  查询 - 列表展示
        /// </summary>
        /// <returns></returns>
        public List<SendMessagesEntity> GetList(string keyword)
        {
            var expression = ExtLinq.True<SendMessagesEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                //多个查询条件
                expression = expression.And(t => t.L_Title.Contains(keyword));
                expression = expression.Or(t => t.L_Centent.Contains(keyword));
            }
            //返回查询方法 - 按删除字段降序展示
            return service.IQueryable(expression).OrderByDescending(t => t.CreateUserTime).Take(5).ToList();
        }

        /// <summary>
        /// 列表列表全部数据
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<SendMessagesEntity> GetFormTableCountJson(string keyword)
        {
            var expression = ExtLinq.True<SendMessagesEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                //多个查询条件
                expression = expression.And(t => t.L_Title.Contains(keyword));
                expression = expression.Or(t => t.L_Centent.Contains(keyword));
            }
            //返回查询方法 - 按删除字段降序展示
            return service.IQueryable(expression).OrderByDescending(t => t.CreateUserTime).ToList();
        }
        /// <summary>
        /// sql 列表
        /// </summary>
        /// <returns></returns>
        public List<SendMessagesEntity> GetSqlTable()
        {
            return service.GetSqlTable();
        }
        /// <summary>
        /// 滚动消息排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public List<SendMessagesEntity> GetNum(string keyValue)
        {
            return service.IQueryable().OrderBy(t => t.CreateUserTime).ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public SendMessagesEntity GetForm(string keyValue)
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
        /// 修改状态
        /// </summary>
        /// <param name="keyValue"></param>
        public void ChangeState(string keyValue)
        {
            try
            {
                SendMessagesEntity SendMessagesEntity = new SendMessagesEntity();
                if (!string.IsNullOrEmpty(keyValue))
                {
                    if (SendMessagesEntity.State == 0)
                    {
                        SendMessagesEntity.State = 1;
                        SendMessagesEntity.Modify(keyValue);
                        service.Update(SendMessagesEntity);
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// 新增，修改
        /// </summary>
        /// <param name="sendMessagesEntity"></param>
        /// <param name="keyValue"></param>
        public void InsertNotice(SendMessagesEntity sendMessagesEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                sendMessagesEntity.Modify(keyValue);
                service.Update(sendMessagesEntity);
            }
            else
            {
                sendMessagesEntity.Create();
                service.Insert(sendMessagesEntity);
            }
        }
    }
}
