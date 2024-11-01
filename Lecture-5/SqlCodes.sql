USE [19B2]
GO

/****** Object:  View [dbo].[vw_StudentDetails]    Script Date: 11/1/2024 3:38:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER VIEW [dbo].[vw_StudentDetails2]
as
select StdName, StdAddress
from [dbo].[mis_StudentInfo] std
INNER JOIN [dbo].[mis_CourseInfo] ci
ON std.CourseId = CI.CourseId


GO



SP_HELPTEXT vw_StudentDetails2


---scalar function

CREATE FUNCTION dbo.CalculateSquare (@Number INT)
RETURNS INT
AS
BEGIN
	RETURN @Number * @Number;
END
--invoke scalar function
select dbo.CalculateSquare(5) as Result

--table valued function

CREATE FUNCTION dbo.GetActiveStudents()
RETURNS TABLE
AS
RETURN
(
SELECT Id,[StdName]
FROM [dbo].[mis_StudentInfo]

);

select * from  [dbo].[GetActiveStudents]()
where Id = 3

--procedure

CREATE PROCEDURE sp_PrintSomething

AS
BEGIN
-- SQL statements go here
SELECT 'Hello, World!' AS Message;
END;

exec [dbo].[sp_PrintSomething] 


create function func_GetOrderedAmount(@CusID int)
returns int
as 

begin
select sum(orderedAmt) from your_vwName
where CustomerId = @CusID
end

select func_GetOrderedAmount(3)

create procedure sp_GetCusNameAndAmt
@cusId int
As
begin

declare @OrdAmt int;
set @OrdAmt = (select func_GetOrderedAmount(@CusId));

declare @CusName varchar;
set @CusName = (select distinct customerName from your_View where CustomerId = @Cusid);

SELECT @CusName as CustomerName, @OrdAmt as TotalAmount 
end

EXEC sp_GetCusNameAndAmt @cusId=5



