select * from [dbo].[Proj_Info]  --项目表
select * from [dbo].[Loan_Make]  --放款表
select * from [dbo].[Loan_PlanDetail]  --放款应收记录表
select * from  [dbo].[Contract_Info]
select * from [dbo].[Contract_PreSigned]  --风控
select * from Loan_PlanDetail
select ML_Fact_start_date from [dbo].[Proj_Info] as proj_info join [dbo].[Loan_Make] as loan_make on proj_info.PI_Porj_Id = loan_make.PI_Porj_Id

 
select * from [dbo].[Loan_Make]
select * from [dbo].[Loan_PlanDetail]  where Loan_Id = @loanId and  FFPD_Fee_Type = '融资款'
select * from [dbo].[Loan_PlanDetail] where Loan_Id =@InterestId and FFPD_Fee_Type = '逾期利息'
--查实收本金
select * from [dbo].[Loan_Make] loan join [dbo].[Loan_PlanDetail] loanplan on loan.Id = loanplan.Loan_ID
  where Loan_Id = '1b276c7d-e9d9-4f72-b3ff-dc02698d28ab' and  FFPD_Fee_Type = '融资款'

  --查应收逾期利息(应收利息)
select FFPD_Fact_Money from [dbo].[Loan_Make] loan join [dbo].[Loan_PlanDetail] loanplan on loan.Id = loanplan.Loan_ID
  where Loan_Id = '1b276c7d-e9d9-4f72-b3ff-dc02698d28ab' and  FFPD_Item_Methon = '逾期利息'

select * from  [dbo].[Loan_Make]


select FFPD_Item_Methon,Sum(ReceivedAmount)'实收' from [dbo].[Loan_PlanDetail] 
where loan_Id  in(select id from [dbo].[Loan_Make] 
where PI_Porj_Id = '9b8b1bc6-79b3-44ca-a3ee-2ca647cb5ffe') 
group by FFPD_Item_Methon

--sum 项目的融资款
select FFPD_Item_Methon,Sum(FFPD_Fact_Money)'应收',Sum(ReceivedAmount)'实收',Sum(ResidualAmount)'未收' from [dbo].[Loan_PlanDetail] 
where loan_Id  in(select id from [dbo].[Loan_Make] 
where PI_Porj_Id = 'd9218589-d066-4fd2-bb09-071face79e60') 
group by FFPD_Item_Methon

--融资款 -  实收本金
select FFPD_Item_Methon,Sum(ReceivedAmount)'实收' from [dbo].[Loan_PlanDetail] 
where loan_Id  in(select id from [dbo].[Loan_Make] 
where FFPD_Item_Methon = '融资款') 
group by FFPD_Item_Methon

--应收实收
select * from  [dbo].[Loan_Make] where id = '031e2e6a-93ef-4186-8fa1-3f5a679169b2'
select * from  [dbo].[Proj_Info] where PI_Porj_Id = 'd9218589-d066-4fd2-bb09-071face79e60'
select * from [dbo].[Loan_PlanDetail]  where FFPD_Item_Methon ='逾期利息'


select * from [dbo].[Loan_PlanDetail]  where FFPD_Fee_Type = '保证金'
--所有字段
select FFPD_Item_Methon,Sum(FFPD_Fact_Money)'应收',Sum(ReceivedAmount)'实收',Sum(ResidualAmount)'未收' from [dbo].[Loan_PlanDetail] 
group by FFPD_Item_Methon

select * from [dbo].[Loan_PlanDetail] 


select FFPD_Item_Methon,Sum(FFPD_Fact_Money)'应收' from [dbo].[Loan_PlanDetail]  group by FFPD_Item_Methon 

select FFPD_Item_Methon from [dbo].[Loan_PlanDetail] where Loan_Id ='79a98ec8-479f-4b49-8557-2cbe25b3f032'  and FFPD_Item_Methon = '手续费'

SELECT pro.PI_Proj_Name '项目名称',
([dbo].[F_Project_Expirytime](con.Id))'到期日期',
IsNull([dbo].[F_Project_Amountofloan](pro.PI_Porj_Id),0.00)'放款金额',
IsNull([dbo].[F_Project_loan](pro.PI_Porj_Id),0.00)'实收本金',
IsNull([dbo].[F_Project_Interest](pro.PI_Porj_Id),0.00)'应收利息',
IsNull([dbo].[F_Project_SSInterest](pro.PI_Porj_Id),0.00)'实收利息',
IsNull([dbo].[F_Project_ServiceCharge](pro.PI_Porj_Id),0.00)'应收手续费',
IsNull([dbo].[F_Project_Chargingfee](pro.PI_Porj_Id),0.00)'实收手续费',
IsNull([dbo].[F_Project_Bond](pro.PI_Porj_Id),0.00)'应收保证金',
IsNull([dbo].[F_Project_Cashdeposit](pro.PI_Porj_Id),0.00)'实收保证金',
IsNull([dbo].[F_Project_ConsultingFee](pro.PI_Porj_Id),0.00)'应收咨询费',
IsNull([dbo].[F_Project_ChargeForconsultation](pro.PI_Porj_Id),0.00)'实收咨询费',
IsNull([dbo].[F_Project_Uncollected](pro.PI_Porj_Id),0.00)'待收金额'
FROM [dbo].[Proj_Info] pro 
join [dbo].[Contract_Info] con  on pro.PI_Porj_Id = con.PI_Porj_Id 
--join [dbo].[Contract_PreSigned] per on pro.PI_Porj_Id = per.PI_Porj_Id
join [dbo].[Loan_Make]  loan on pro.PI_Porj_Id = loan.PI_Porj_Id

select * from [dbo].[Loan_PlanDetail]
select * from [dbo].[Contract_Info]
select * from  [dbo].[Contract_Info]

--sum 项目的融资款
select FFPD_Item_Methon,Sum(FFPD_Fact_Money)'应收',Sum(ReceivedAmount)'实收',Sum(ResidualAmount)'未收' from [dbo].[Loan_PlanDetail] 
where loan_Id  in(select id from [dbo].[Loan_Make] 
where PI_Porj_Id = 'd9218589-d066-4fd2-bb09-071face79e60') 
group by FFPD_Item_Methon

--待收金额
select sum(ResidualAmount)'待收金额' from [dbo].[Loan_PlanDetail] where Loan_ID=(select ID from [dbo].[Loan_Make] where PI_Porj_Id='d9218589-d066-4fd2-bb09-071face79e60')

select ([dbo].[F_Project_Uncollected]('1751291f-2b7b-4a2b-af51-7e2f89b2c'))'待收金额' 

select ReceivedAmount from [dbo].[Loan_PlanDetail] where Loan_Id = '79a98ec8-479f-4b49-8557-2cbe25b3f032' and FFPD_Item_Methon = '手续费'
--查询数据应收，实收，未收的sql语句
select sum(FFPD_Fact_Money)'应收' from [dbo].[Loan_PlanDetail] where Loan_Id in(select Id  from [dbo].[Loan_Make] where PI_Porj_Id='62d4eebf-c960-4660-a63c-43d8890de851')  and FFPD_Item_Methon = '手续费'
--查询到期时间
SELECT MAX(FFPD_Plan_Date) FROM Loan_PlanDetail WHERE Loan_ID=(SELECT Id FROM Loan_Make WHERE Contract_Info_Id=(SELECT Id FROM Contract_Info WHERE Id='64497e2f-7f06-4e4c-85f5-2e1f717b9d54'))
select* from Contract_Info
--查询是否存在数据
select * from [dbo].[Loan_Make]
select * from [dbo].[Loan_PlanDetail] 
--融资款
select ReceivedAmount from [dbo].[Loan_PlanDetail]  where Loan_ID = '79a98ec8-479f-4b49-8557-2cbe25b3f032' and FFPD_Item_Methon ='融资款'
--应收利息
select FFPD_Fact_Money '应收利息' from [dbo].[Loan_PlanDetail] where Loan_ID = '79a98ec8-479f-4b49-8557-2cbe25b3f032' and FFPD_Item_Methon ='逾期利息'
--手续费
select FFPD_Fact_Money from [dbo].[Loan_PlanDetail] where Loan_Id = '79a98ec8-479f-4b49-8557-2cbe25b3f032' and FFPD_Item_Methon = '手续费'
--保证金
select ReceivedAmount from [dbo].[Loan_PlanDetail] where Loan_Id = '79a98ec8-479f-4b49-8557-2cbe25b3f032' and FFPD_Item_Methon = '保证金'
select FFPD_Fact_Money from [dbo].[Loan_PlanDetail] where Loan_Id = '79a98ec8-479f-4b49-8557-2cbe25b3f032' and FFPD_Item_Methon = '保证金'
select * from [dbo].[Loan_PlanDetail] where Id = '5823cdec-b41a-4d15-bb0f-9a9d7536d715'  --保证金144.00
select * from [dbo].[Loan_Make] where id = '031e2e6a-93ef-4186-8fa1-3f5a679169b2'
select *  from   [dbo].[Proj_Info] where PI_Porj_Id= 'd9218589-d066-4fd2-bb09-071face79e60'