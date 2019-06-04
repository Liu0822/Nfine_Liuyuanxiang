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
    /// 2018年9月20日 12:06:04(我的公告应用服务层)
    /// </summary>
    public class AnnouncementApp
    {
        private IAnnouncementRepository service = new AnnouncementRepository();  //调用接口层实例化业务层
        /// <summary>
        /// 查询公告列表
        /// </summary>
        /// <returns></returns>
        public List<AnnouncementEntity> GetAnnouncement()
        {
            //按降序展示
            return service.IQueryable().OrderByDescending(t => t.F_CreatorTime).ToList();
        }
        /// <summary>
        /// 单独给首页展示最新公告消息方法
        /// </summary>
        /// <returns></returns>
        public List<AnnouncementEntity> GetAnnouncementCount()
        {
            return service.IQueryable().OrderBy(t => t.F_CreatorTime).ToList();
        }
        /// <summary>
        /// 新增修改操作(我的公告)
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="keyValue"></param>
        public void AddAnnouncement(AnnouncementEntity Entity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))  //判断keyValue是否为空
            {
                Entity.Modify(keyValue); //修改实体
                service.Update(Entity); //更新表
            }
            else
            {
                Entity.Create(); //新增数据，主键自增
                service.Insert(Entity); //插入数据到表实体
            }
        }

        public void DeleteAnnouncement(string DeleteKeyID)
        {
             service.Delete(t => t.F_Id == DeleteKeyID);
        }
    }   
}
