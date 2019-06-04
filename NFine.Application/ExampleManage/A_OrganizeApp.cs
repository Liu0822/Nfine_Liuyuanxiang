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
   public class A_OrganizeApp
    {
        /// <summary>
        ///  by.L 2018年9月6日 16:20:48   调用在接口层的方法， 实现该方法
        /// </summary>
        private IA_OrganizeRepository service = new A_OrganizeRepository();
        public IEnumerable<A_OrganizeEntity> TreeJson()
        {
            return service.TreeJson();
        }
        public IEnumerable<A_OrganizeEntity> GetTreeJson()
        {
            return service.GetTreeJson();
        }
        public void InsertTree(A_OrganizeEntity a_OrganizeEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                a_OrganizeEntity.Modify(keyValue);
                service.Update(a_OrganizeEntity);
            }
            else
            {
                a_OrganizeEntity.Create();
                service.Insert(a_OrganizeEntity);
            }
        }
    }
}
