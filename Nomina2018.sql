USE [master]
GO
/****** Object:  Database [Nomina2018]    Script Date: 11/08/2021 10:37:40 a. m. ******/
CREATE DATABASE [Nomina2018]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Nomina2018', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Nomina2018.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Nomina2018_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Nomina2018_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Nomina2018] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Nomina2018].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Nomina2018] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Nomina2018] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Nomina2018] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Nomina2018] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Nomina2018] SET ARITHABORT OFF 
GO
ALTER DATABASE [Nomina2018] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Nomina2018] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Nomina2018] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Nomina2018] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Nomina2018] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Nomina2018] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Nomina2018] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Nomina2018] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Nomina2018] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Nomina2018] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Nomina2018] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Nomina2018] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Nomina2018] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Nomina2018] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Nomina2018] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Nomina2018] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Nomina2018] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Nomina2018] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Nomina2018] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Nomina2018] SET  MULTI_USER 
GO
ALTER DATABASE [Nomina2018] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Nomina2018] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Nomina2018] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Nomina2018] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Nomina2018]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 11/08/2021 10:37:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[IdDepartment] [int] IDENTITY(1,1) NOT NULL,
	[Department] [varchar](50) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[IdDepartment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/08/2021 10:37:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[IdEmployee] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](10) NULL,
	[Mail] [varchar](50) NOT NULL,
	[Direction] [varchar](80) NULL,
	[TypeUser] [int] NOT NULL,
	[IdDepartment] [int] NULL,
	[IdSalary] [int] NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[IdEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 11/08/2021 10:37:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[IdEmployee] [int] NOT NULL,
	[PaymentDate] [date] NOT NULL,
	[PaymentAmount] [numeric](14, 0) NOT NULL,
	[IdPayment] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[IdPayment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Salary]    Script Date: 11/08/2021 10:37:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Salary](
	[IdSalary] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [numeric](18, 0) NOT NULL,
	[Currency] [varchar](10) NOT NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_Salary] PRIMARY KEY CLUSTERED 
(
	[IdSalary] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([IdDepartment], [Department], [Location], [IsActive]) VALUES (1, N'Marketing', N'Mérida', 1)
INSERT [dbo].[Department] ([IdDepartment], [Department], [Location], [IsActive]) VALUES (2, N'Sistemas', N'Mérida', 1)
INSERT [dbo].[Department] ([IdDepartment], [Department], [Location], [IsActive]) VALUES (3, N'Testing', N'Campeche', 1)
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([IdEmployee], [Name], [LastName], [PhoneNumber], [Mail], [Direction], [TypeUser], [IdDepartment], [IdSalary], [IsActive]) VALUES (2, N'Ricardo', N'Dzul', N'8882334444', N'rd@mail.com', N'C. 12 x 90 y 12 centro', 1, 3, 2, 1)
INSERT [dbo].[Employee] ([IdEmployee], [Name], [LastName], [PhoneNumber], [Mail], [Direction], [TypeUser], [IdDepartment], [IdSalary], [IsActive]) VALUES (3, N'Laura', N'Martinez ', N'8383717143', N'correo@mail.con', N'C. 30 x 12 y 19', 1, 1, 1, 1)
INSERT [dbo].[Employee] ([IdEmployee], [Name], [LastName], [PhoneNumber], [Mail], [Direction], [TypeUser], [IdDepartment], [IdSalary], [IsActive]) VALUES (4, N'Manuel', N'Cabrera', N'9391022333', N'mc@mail.com', N'Calle del sur', 1, 2, 2, 1)
INSERT [dbo].[Employee] ([IdEmployee], [Name], [LastName], [PhoneNumber], [Mail], [Direction], [TypeUser], [IdDepartment], [IdSalary], [IsActive]) VALUES (5, N'Thaily', N'Rosado', N'9992228304', N'tr@mail.com', N'Zona este', 2, 1, 2, 1)
INSERT [dbo].[Employee] ([IdEmployee], [Name], [LastName], [PhoneNumber], [Mail], [Direction], [TypeUser], [IdDepartment], [IdSalary], [IsActive]) VALUES (6, N'Tomas ', N'Chan', N'8983344433', N'tc@mail.com', N'Zona Norte', 1, 2, 3, 1)
INSERT [dbo].[Employee] ([IdEmployee], [Name], [LastName], [PhoneNumber], [Mail], [Direction], [TypeUser], [IdDepartment], [IdSalary], [IsActive]) VALUES (7, N'Laura', N'Méndez', N'9990003322', N'lm@mail.com', N'Zona Sur', 1, 3, 1, 1)
INSERT [dbo].[Employee] ([IdEmployee], [Name], [LastName], [PhoneNumber], [Mail], [Direction], [TypeUser], [IdDepartment], [IdSalary], [IsActive]) VALUES (8, N'Manuel', N'Méndez', N'8983344423', N'mm@mail.com', N'Zona Centro', 2, 1, 3, 1)
INSERT [dbo].[Employee] ([IdEmployee], [Name], [LastName], [PhoneNumber], [Mail], [Direction], [TypeUser], [IdDepartment], [IdSalary], [IsActive]) VALUES (9, N'Manuela', N'Mendoza', N'9990001122', N'mma@mail.com', N'Zona Centro', 1, 2, 3, 1)
INSERT [dbo].[Employee] ([IdEmployee], [Name], [LastName], [PhoneNumber], [Mail], [Direction], [TypeUser], [IdDepartment], [IdSalary], [IsActive]) VALUES (10, N'Ricardo', N'Dzul', N'888233420', N'mail@gmail.com', N'C. 12 x 90 y 12 centro', 1, 3, 2, 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([IdEmployee], [PaymentDate], [PaymentAmount], [IdPayment]) VALUES (2, CAST(N'2001-01-11' AS Date), CAST(10000000 AS Numeric(14, 0)), 1)
INSERT [dbo].[Payment] ([IdEmployee], [PaymentDate], [PaymentAmount], [IdPayment]) VALUES (3, CAST(N'2011-10-10' AS Date), CAST(602989898 AS Numeric(14, 0)), 2)
INSERT [dbo].[Payment] ([IdEmployee], [PaymentDate], [PaymentAmount], [IdPayment]) VALUES (2, CAST(N'2021-08-04' AS Date), CAST(500 AS Numeric(14, 0)), 3)
INSERT [dbo].[Payment] ([IdEmployee], [PaymentDate], [PaymentAmount], [IdPayment]) VALUES (8, CAST(N'2021-08-26' AS Date), CAST(9000000 AS Numeric(14, 0)), 4)
SET IDENTITY_INSERT [dbo].[Payment] OFF
SET IDENTITY_INSERT [dbo].[Salary] ON 

INSERT [dbo].[Salary] ([IdSalary], [Amount], [Currency], [IsActive]) VALUES (1, CAST(10 AS Numeric(18, 0)), N'MXN', 1)
INSERT [dbo].[Salary] ([IdSalary], [Amount], [Currency], [IsActive]) VALUES (2, CAST(500 AS Numeric(18, 0)), N'USD', 1)
INSERT [dbo].[Salary] ([IdSalary], [Amount], [Currency], [IsActive]) VALUES (3, CAST(5000 AS Numeric(18, 0)), N'MXN', 1)
INSERT [dbo].[Salary] ([IdSalary], [Amount], [Currency], [IsActive]) VALUES (4, CAST(1000 AS Numeric(18, 0)), N'MXN', 1)
SET IDENTITY_INSERT [dbo].[Salary] OFF
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([IdDepartment])
REFERENCES [dbo].[Department] ([IdDepartment])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Salary] FOREIGN KEY([IdSalary])
REFERENCES [dbo].[Salary] ([IdSalary])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Salary]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Employee] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employee] ([IdEmployee])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Employee]
GO
USE [master]
GO
ALTER DATABASE [Nomina2018] SET  READ_WRITE 
GO
