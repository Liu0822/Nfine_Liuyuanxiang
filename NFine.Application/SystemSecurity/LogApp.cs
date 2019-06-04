/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Code;
using NFine.Domain.Entity.SystemSecurity;
using NFine.Domain.IRepositoryBase.SystemSecurity;
using NFine.Repository.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace NFine.Application.SystemSecurity
{
    public class LogApp
    {
        private ILogRepository service = new LogRepository();

        /// <summary>
        /// 系统日志列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<LogEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<LogEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();
                expression = expression.And(t => t.F_Account.Contains(keyword));
            }
            if (!queryParam["timeType"].IsEmpty())
            {
                string timeType = queryParam["timeType"].ToString();
                DateTime startTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate();
                DateTime endTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate().AddDays(1);
                switch (timeType)
                {
                    case "1":
                        break;
                    case "2":
                        startTime = DateTime.Now.AddDays(-7);
                        break;
                    case "3":
                        startTime = DateTime.Now.AddMonths(-1);
                        break;
                    case "4":
                        startTime = DateTime.Now.AddMonths(-3);
                        break;
                    default:
                        break;
                }
                expression = expression.And(t => t.F_Date >= startTime && t.F_Date <= endTime);
            }
            return service.FindList(expression, pagination);
        }
        /// <summary>
        /// log不带分页参数
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<LogEntity> GetList(string queryJson)
        {
            return service.IQueryable().OrderByDescending(t => t.F_CreatorTime).Take(1).ToList();
            //var expression = ExtLinq.True<LogEntity>();
            //var queryParam = queryJson.ToJObject();
            //if (!queryParam["keyword"].IsEmpty())
            //{
            //    string keyword = queryParam["keyword"].ToString();
            //    expression = expression.And(t => t.F_Account.Contains(keyword));
            //}
            //if (!queryParam["timeType"].IsEmpty())
            //{
            //    string timeType = queryParam["timeType"].ToString();
            //    DateTime startTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate();
            //    DateTime endTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate().AddDays(1);
            //    switch (timeType)
            //    {
            //        case "1":
            //            break;
            //        case "2":
            //            startTime = DateTime.Now.AddDays(-7);
            //            break;
            //        case "3":
            //            startTime = DateTime.Now.AddMonths(-1);
            //            break;
            //        case "4":
            //            startTime = DateTime.Now.AddMonths(-3);
            //            break;
            //        default:
            //            break;
            //    }
            //    expression = expression.And(t => t.F_Date >= startTime && t.F_Date <= endTime);
            //}
            //return service.FindList(expression.ToString());
        }
        /// <summary>
        ///    根据条件查询清空系统日志
        /// </summary>
        /// <param name="keepTime"></param>
        public void RemoveLog(string keepTime)
        {
            DateTime operateTime = DateTime.Now;
            if (keepTime == "7")            //保留近一周
            {
                operateTime = DateTime.Now.AddDays(-7);
            }
            else if (keepTime == "1")       //保留近一个月
            {
                operateTime = DateTime.Now.AddMonths(-1);
            }
            else if (keepTime == "3")       //保留近三个月
            {
                operateTime = DateTime.Now.AddMonths(-3);
            }
            var expression = ExtLinq.True<LogEntity>();
            expression = expression.And(t => t.F_Date <= operateTime);
            service.Delete(expression);
        }
        public void WriteDbLog(bool result, string resultLog)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.F_Id = Common.GuId();
            logEntity.F_Date = DateTime.Now;
            logEntity.F_Account = OperatorProvider.Provider.GetCurrent().UserCode;
            logEntity.F_NickName = OperatorProvider.Provider.GetCurrent().UserName;
            logEntity.F_IPAddress = Net.Ip;
            logEntity.F_IPAddressName = Net.GetLocation(logEntity.F_IPAddress);
            logEntity.F_Result = result;
            logEntity.F_Description = resultLog;
            logEntity.Create();
            service.Insert(logEntity);
        }
        /// <summary>
        /// 登录后信息 获取当前用户ip信息  修改版 （原方法已注释在下面）
        /// </summary>
        /// <param name="logEntity"></param>
        public void WriteDbLog(LogEntity logEntity)
        {
            //获取系统信息
            System.OperatingSystem osInfo = System.Environment.OSVersion;
            //获取操作系统ID
            System.PlatformID platformID = osInfo.Platform;
            //获取主版本号
            int versionMajor = osInfo.Version.Major;
            //获取副版本号
            int versionMinor = osInfo.Version.Minor;

            string strSystem = Environment.OSVersion.ToString(); //电脑版本
            logEntity.F_Type = strSystem;

            logEntity.F_Id = Common.GuId();  //guid
            logEntity.F_ModuleName = Net.Browser; //浏览器
            logEntity.F_Account = Dns.GetHostName();//获取本机的计算机名              
            logEntity.F_Date = DateTime.Now;  //获取登录时间
            logEntity.F_IPAddress = Net.Ip;    //获取当前Ip地址
            //logEntity.F_IPAddressName = Net.GetLocation(logEntity.F_IPAddress); //获取ip信息
            logEntity.Create();
            service.Insert(logEntity);
        }

        ///// <summary>
        ///// 登录后log信息    获取当前用户ip信息
        ///// </summary>
        ///// <param name="logEntity"></param>
        //public void WriteDbLog(LogEntity logEntity)
        //{
        //    logEntity.F_NickName = Dns.GetHostName();//获取本机的计算机名       
        //    logEntity.F_Id = Common.GuId();  //guid
        //    logEntity.F_Date = DateTime.Now;  //获取登录时间
        //    logEntity.F_IPAddress = Net.Ip;    //获取当前Ip地址
        //    logEntity.F_IPAddressName = Net.GetLocation(logEntity.F_IPAddress); //获取ip信息
        //    logEntity.Create();
        //    service.Insert(logEntity);
        //}
    }
}
