select * from [dbo].[Proj_Info]  --��Ŀ��
select * from [dbo].[Loan_Make]  --�ſ��
select * from [dbo].[Loan_PlanDetail]  --�ſ�Ӧ�ռ�¼��
select * from  [dbo].[Contract_Info]
select * from [dbo].[Contract_PreSigned]  --���
select * from Loan_PlanDetail
select ML_Fact_start_date from [dbo].[Proj_Info] as proj_info join [dbo].[Loan_Make] as loan_make on proj_info.PI_Porj_Id = loan_make.PI_Porj_Id

 
select * from [dbo].[Loan_Make]
select * from [dbo].[Loan_PlanDetail]  where Loan_Id = @loanId and  FFPD_Fee_Type = '���ʿ�'
select * from [dbo].[Loan_PlanDetail] where Loan_Id =@InterestId and FFPD_Fee_Type = '������Ϣ'
--��ʵ�ձ���
select * from [dbo].[Loan_Make] loan join [dbo].[Loan_PlanDetail] loanplan on loan.Id = loanplan.Loan_ID
  where Loan_Id = '1b276c7d-e9d9-4f72-b3ff-dc02698d28ab' and  FFPD_Fee_Type = '���ʿ�'

  --��Ӧ��������Ϣ(Ӧ����Ϣ)
select FFPD_Fact_Money from [dbo].[Loan_Make] loan join [dbo].[Loan_PlanDetail] loanplan on loan.Id = loanplan.Loan_ID
  where Loan_Id = '1b276c7d-e9d9-4f72-b3ff-dc02698d28ab' and  FFPD_Item_Methon = '������Ϣ'

select * from  [dbo].[Loan_Make]


select FFPD_Item_Methon,Sum(ReceivedAmount)'ʵ��' from [dbo].[Loan_PlanDetail] 
where loan_Id  in(select id from [dbo].[Loan_Make] 
where PI_Porj_Id = '9b8b1bc6-79b3-44ca-a3ee-2ca647cb5ffe') 
group by FFPD_Item_Methon

--sum ��Ŀ�����ʿ�
select FFPD_Item_Methon,Sum(FFPD_Fact_Money)'Ӧ��',Sum(ReceivedAmount)'ʵ��',Sum(ResidualAmount)'δ��' from [dbo].[Loan_PlanDetail] 
where loan_Id  in(select id from [dbo].[Loan_Make] 
where PI_Porj_Id = 'd9218589-d066-4fd2-bb09-071face79e60') 
group by FFPD_Item_Methon

--���ʿ� -  ʵ�ձ���
select FFPD_Item_Methon,Sum(ReceivedAmount)'ʵ��' from [dbo].[Loan_PlanDetail] 
where loan_Id  in(select id from [dbo].[Loan_Make] 
where FFPD_Item_Methon = '���ʿ�') 
group by FFPD_Item_Methon

--Ӧ��ʵ��
select * from  [dbo].[Loan_Make] where id = '031e2e6a-93ef-4186-8fa1-3f5a679169b2'
select * from  [dbo].[Proj_Info] where PI_Porj_Id = 'd9218589-d066-4fd2-bb09-071face79e60'
select * from [dbo].[Loan_PlanDetail]  where FFPD_Item_Methon ='������Ϣ'


select * from [dbo].[Loan_PlanDetail]  where FFPD_Fee_Type = '��֤��'
--�����ֶ�
select FFPD_Item_Methon,Sum(FFPD_Fact_Money)'Ӧ��',Sum(ReceivedAmount)'ʵ��',Sum(ResidualAmount)'δ��' from [dbo].[Loan_PlanDetail] 
group by FFPD_Item_Methon

select * from [dbo].[Loan_PlanDetail] 


select FFPD_Item_Methon,Sum(FFPD_Fact_Money)'Ӧ��' from [dbo].[Loan_PlanDetail]  group by FFPD_Item_Methon 

select FFPD_Item_Methon from [dbo].[Loan_PlanDetail] where Loan_Id ='79a98ec8-479f-4b49-8557-2cbe25b3f032'  and FFPD_Item_Methon = '������'

SELECT pro.PI_Proj_Name '��Ŀ����',
([dbo].[F_Project_Expirytime](con.Id))'��������',
IsNull([dbo].[F_Project_Amountofloan](pro.PI_Porj_Id),0.00)'�ſ���',
IsNull([dbo].[F_Project_loan](pro.PI_Porj_Id),0.00)'ʵ�ձ���',
IsNull([dbo].[F_Project_Interest](pro.PI_Porj_Id),0.00)'Ӧ����Ϣ',
IsNull([dbo].[F_Project_SSInterest](pro.PI_Porj_Id),0.00)'ʵ����Ϣ',
IsNull([dbo].[F_Project_ServiceCharge](pro.PI_Porj_Id),0.00)'Ӧ��������',
IsNull([dbo].[F_Project_Chargingfee](pro.PI_Porj_Id),0.00)'ʵ��������',
IsNull([dbo].[F_Project_Bond](pro.PI_Porj_Id),0.00)'Ӧ�ձ�֤��',
IsNull([dbo].[F_Project_Cashdeposit](pro.PI_Porj_Id),0.00)'ʵ�ձ�֤��',
IsNull([dbo].[F_Project_ConsultingFee](pro.PI_Porj_Id),0.00)'Ӧ����ѯ��',
IsNull([dbo].[F_Project_ChargeForconsultation](pro.PI_Porj_Id),0.00)'ʵ����ѯ��',
IsNull([dbo].[F_Project_Uncollected](pro.PI_Porj_Id),0.00)'���ս��'
FROM [dbo].[Proj_Info] pro 
join [dbo].[Contract_Info] con  on pro.PI_Porj_Id = con.PI_Porj_Id 
--join [dbo].[Contract_PreSigned] per on pro.PI_Porj_Id = per.PI_Porj_Id
join [dbo].[Loan_Make]  loan on pro.PI_Porj_Id = loan.PI_Porj_Id

select * from [dbo].[Loan_PlanDetail]
select * from [dbo].[Contract_Info]
select * from  [dbo].[Contract_Info]

--sum ��Ŀ�����ʿ�
select FFPD_Item_Methon,Sum(FFPD_Fact_Money)'Ӧ��',Sum(ReceivedAmount)'ʵ��',Sum(ResidualAmount)'δ��' from [dbo].[Loan_PlanDetail] 
where loan_Id  in(select id from [dbo].[Loan_Make] 
where PI_Porj_Id = 'd9218589-d066-4fd2-bb09-071face79e60') 
group by FFPD_Item_Methon

--���ս��
select sum(ResidualAmount)'���ս��' from [dbo].[Loan_PlanDetail] where Loan_ID=(select ID from [dbo].[Loan_Make] where PI_Porj_Id='d9218589-d066-4fd2-bb09-071face79e60')

select ([dbo].[F_Project_Uncollected]('1751291f-2b7b-4a2b-af51-7e2f89b2c'))'���ս��' 

select ReceivedAmount from [dbo].[Loan_PlanDetail] where Loan_Id = '79a98ec8-479f-4b49-8557-2cbe25b3f032' and FFPD_Item_Methon = '������'
--��ѯ����Ӧ�գ�ʵ�գ�δ�յ�sql���
select sum(FFPD_Fact_Money)'Ӧ��' from [dbo].[Loan_PlanDetail] where Loan_Id in(select Id  from [dbo].[Loan_Make] where PI_Porj_Id='62d4eebf-c960-4660-a63c-43d8890de851')  and FFPD_Item_Methon = '������'
--��ѯ����ʱ��
SELECT MAX(FFPD_Plan_Date) FROM Loan_PlanDetail WHERE Loan_ID=(SELECT Id FROM Loan_Make WHERE Contract_Info_Id=(SELECT Id FROM Contract_Info WHERE Id='64497e2f-7f06-4e4c-85f5-2e1f717b9d54'))
select* from Contract_Info
--��ѯ�Ƿ��������
select * from [dbo].[Loan_Make]
select * from [dbo].[Loan_PlanDetail] 
--���ʿ�
select ReceivedAmount from [dbo].[Loan_PlanDetail]  where Loan_ID = '79a98ec8-479f-4b49-8557-2cbe25b3f032' and FFPD_Item_Methon ='���ʿ�'
--Ӧ����Ϣ
select FFPD_Fact_Money 'Ӧ����Ϣ' from [dbo].[Loan_PlanDetail] where Loan_ID = '79a98ec8-479f-4b49-8557-2cbe25b3f032' and FFPD_Item_Methon ='������Ϣ'
--������
select FFPD_Fact_Money from [dbo].[Loan_PlanDetail] where Loan_Id = '79a98ec8-479f-4b49-8557-2cbe25b3f032' and FFPD_Item_Methon = '������'
--��֤��
select ReceivedAmount from [dbo].[Loan_PlanDetail] where Loan_Id = '79a98ec8-479f-4b49-8557-2cbe25b3f032' and FFPD_Item_Methon = '��֤��'
select FFPD_Fact_Money from [dbo].[Loan_PlanDetail] where Loan_Id = '79a98ec8-479f-4b49-8557-2cbe25b3f032' and FFPD_Item_Methon = '��֤��'
select * from [dbo].[Loan_PlanDetail] where Id = '5823cdec-b41a-4d15-bb0f-9a9d7536d715'  --��֤��144.00
select * from [dbo].[Loan_Make] where id = '031e2e6a-93ef-4186-8fa1-3f5a679169b2'
select *  from   [dbo].[Proj_Info] where PI_Porj_Id= 'd9218589-d066-4fd2-bb09-071face79e60'