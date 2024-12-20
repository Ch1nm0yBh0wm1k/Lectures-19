USE [master]
GO
/****** Object:  Database [19B1]    Script Date: 11/8/2024 11:21:08 PM ******/
CREATE DATABASE [19B1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'19B1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\19B1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'19B1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\19B1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [19B1] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [19B1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [19B1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [19B1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [19B1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [19B1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [19B1] SET ARITHABORT OFF 
GO
ALTER DATABASE [19B1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [19B1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [19B1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [19B1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [19B1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [19B1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [19B1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [19B1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [19B1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [19B1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [19B1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [19B1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [19B1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [19B1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [19B1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [19B1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [19B1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [19B1] SET RECOVERY FULL 
GO
ALTER DATABASE [19B1] SET  MULTI_USER 
GO
ALTER DATABASE [19B1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [19B1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [19B1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [19B1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [19B1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [19B1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'19B1', N'ON'
GO
ALTER DATABASE [19B1] SET QUERY_STORE = ON
GO
ALTER DATABASE [19B1] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [19B1]
GO
/****** Object:  UserDefinedFunction [dbo].[CalculateSquare]    Script Date: 11/8/2024 11:21:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CalculateSquare] (@Number INT)
RETURNS INT
AS
BEGIN
RETURN @Number * @Number;
END
GO
/****** Object:  Table [dbo].[mis_Students]    Script Date: 11/8/2024 11:21:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mis_Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Age] [int] NULL,
	[Address] [varchar](max) NULL,
 CONSTRAINT [PK_mis_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mis_Courses]    Script Date: 11/8/2024 11:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mis_Courses](
	[Id] [int] NOT NULL,
	[StudentId] [int] NULL,
	[CourseName] [varchar](50) NULL,
	[CourseDescription] [varchar](50) NULL,
 CONSTRAINT [PK_mis_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_StudentCourseInnerJoin]    Script Date: 11/8/2024 11:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   view [dbo].[vw_StudentCourseInnerJoin]
as
select S.Id, S.Name, S.Address, C.Id as CID, c.CourseName, C.CourseDescription
from [dbo].[mis_Students] S
inner join
[dbo].[mis_Courses] C
on S.Id = C.StudentId
GO
/****** Object:  UserDefinedFunction [dbo].[GetActiveStudents]    Script Date: 11/8/2024 11:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   FUNCTION [dbo].[GetActiveStudents]()
RETURNS TABLE
AS
RETURN
(
SELECT *
FROM [dbo].[mis_Students]

);
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/8/2024 11:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Age] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 11/8/2024 11:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [Age]) VALUES (1, N'Test2', 12)
INSERT [dbo].[Customer] ([Id], [Name], [Age]) VALUES (2, N'Xyz', 2)
INSERT [dbo].[Customer] ([Id], [Name], [Age]) VALUES (3, N'AAA', 2)
INSERT [dbo].[Customer] ([Id], [Name], [Age]) VALUES (4, N'Chinmoy', 1)
INSERT [dbo].[Customer] ([Id], [Name], [Age]) VALUES (5, N'Abir', 3)
INSERT [dbo].[Customer] ([Id], [Name], [Age]) VALUES (6, N'rhythm', 11)
INSERT [dbo].[Customer] ([Id], [Name], [Age]) VALUES (7, N'hagsf', 12)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[mis_Courses] ([Id], [StudentId], [CourseName], [CourseDescription]) VALUES (1, 1, N'OS', N'dbhc')
INSERT [dbo].[mis_Courses] ([Id], [StudentId], [CourseName], [CourseDescription]) VALUES (2, 2, N'C#', N'djh')
INSERT [dbo].[mis_Courses] ([Id], [StudentId], [CourseName], [CourseDescription]) VALUES (3, 1, N'Java', N'sdugv')
INSERT [dbo].[mis_Courses] ([Id], [StudentId], [CourseName], [CourseDescription]) VALUES (4, 1, N'CN', NULL)
INSERT [dbo].[mis_Courses] ([Id], [StudentId], [CourseName], [CourseDescription]) VALUES (5, 2, N'Archi', N'dhgcasdvc')
INSERT [dbo].[mis_Courses] ([Id], [StudentId], [CourseName], [CourseDescription]) VALUES (6, 3, N'CSE', N'dhj')
INSERT [dbo].[mis_Courses] ([Id], [StudentId], [CourseName], [CourseDescription]) VALUES (7, 4, N'AI', N'djgvdch')
INSERT [dbo].[mis_Courses] ([Id], [StudentId], [CourseName], [CourseDescription]) VALUES (8, 5, N'ANN', N'udhbdh')
GO
SET IDENTITY_INSERT [dbo].[mis_Students] ON 

INSERT [dbo].[mis_Students] ([Id], [Name], [Age], [Address]) VALUES (1, N'Chinmoy', 2, N'Abcd`')
INSERT [dbo].[mis_Students] ([Id], [Name], [Age], [Address]) VALUES (2, N'Rahul', 3, N'jhbc')
INSERT [dbo].[mis_Students] ([Id], [Name], [Age], [Address]) VALUES (3, N'Rafi', 4, N'sdcd')
INSERT [dbo].[mis_Students] ([Id], [Name], [Age], [Address]) VALUES (4, N'Sajid', 6, N'djcghvdsc')
SET IDENTITY_INSERT [dbo].[mis_Students] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllStudentList]    Script Date: 11/8/2024 11:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--create procedure
CREATE PROCEDURE [dbo].[sp_GetAllStudentList]
--@ParameterName DataType, -- Input parameter
--@AnotherParameterName DataType = DefaultValue -- Optional parameter
AS
BEGIN
-- SQL statements go here
SELECT * from [dbo].[mis_Students];
END;
GO
USE [master]
GO
ALTER DATABASE [19B1] SET  READ_WRITE 
GO
