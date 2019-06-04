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
    /// <summary>
    /// 业务层，继承IAnnouncementRepository接口来实现方法写逻辑业务
    /// </summary>
    public class AnnouncementRepository: RepositoryBase<AnnouncementEntity>, IAnnouncementRepository
    {
    }
}
