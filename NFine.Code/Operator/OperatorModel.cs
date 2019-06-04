using System;
namespace NFine.Code
{
    public class OperatorModel
    {
        public string UserId { get; set; }
        /// <summary>
        /// 当前用户
        /// </summary>
        public string UserCode { get; set; }        
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string CompanyId { get; set; }
        public string DepartmentId { get; set; }
        public string RoleId { get; set; }
        public string LoginIPAddress { get; set; }
        public string LoginIPAddressName { get; set; }
        public string LoginToken { get; set; }
        public DateTime LoginTime { get; set; }
        public bool IsSystem { get; set; }
    }
}
