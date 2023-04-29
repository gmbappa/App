USE [master]
GO
/****** Object:  Database [Portfolio]    Script Date: 4/29/2023 8:50:06 PM ******/
CREATE DATABASE [Portfolio]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Portfolio', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\Portfolio.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Portfolio_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\Portfolio_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Portfolio] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Portfolio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Portfolio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Portfolio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Portfolio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Portfolio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Portfolio] SET ARITHABORT OFF 
GO
ALTER DATABASE [Portfolio] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Portfolio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Portfolio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Portfolio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Portfolio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Portfolio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Portfolio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Portfolio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Portfolio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Portfolio] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Portfolio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Portfolio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Portfolio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Portfolio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Portfolio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Portfolio] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Portfolio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Portfolio] SET RECOVERY FULL 
GO
ALTER DATABASE [Portfolio] SET  MULTI_USER 
GO
ALTER DATABASE [Portfolio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Portfolio] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Portfolio] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Portfolio] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Portfolio] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Portfolio] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Portfolio', N'ON'
GO
ALTER DATABASE [Portfolio] SET QUERY_STORE = OFF
GO
USE [Portfolio]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/29/2023 8:50:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 4/29/2023 8:50:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 4/29/2023 8:50:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [nvarchar](50) NOT NULL,
	[Degree] [nvarchar](100) NOT NULL,
	[Institute] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Experience]    Script Date: 4/29/2023 8:50:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Experience](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Designation] [nvarchar](50) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NULL,
	[Responsibilities] [nvarchar](1000) NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Experience] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalInfo]    Script Date: 4/29/2023 8:50:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DoB] [datetime2](7) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](13) NOT NULL,
	[MaritalStatus] [nvarchar](10) NULL,
 CONSTRAINT [PK_PersonalInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 4/29/2023 8:50:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Technologies] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resume]    Script Date: 4/29/2023 8:50:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resume](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[FileData] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Resume] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230429133554_init', N'6.0.15')
GO
SET IDENTITY_INSERT [dbo].[Company] ON 
GO
INSERT [dbo].[Company] ([Id], [Name], [Location]) VALUES (1, N'Hydrus Digital BD (Pvt) Ltd.', N'Dhaka')
GO
INSERT [dbo].[Company] ([Id], [Name], [Location]) VALUES (2, N'KKD', N'Jeshore')
GO
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[Education] ON 
GO
INSERT [dbo].[Education] ([Id], [Year], [Degree], [Institute]) VALUES (1, N'2016', N'Post Graduate Diploma in ICT', N'Bangladesh Computer Council')
GO
SET IDENTITY_INSERT [dbo].[Education] OFF
GO
SET IDENTITY_INSERT [dbo].[Experience] ON 
GO
INSERT [dbo].[Experience] ([Id], [Designation], [StartDate], [EndDate], [Responsibilities], [CompanyId]) VALUES (1, N'Senior Software Engineer', CAST(N'2022-07-29T14:03:34.0960000' AS DateTime2), CAST(N'2023-04-29T14:03:34.0960000' AS DateTime2), N'• Lead Team, Supervise the subordinate’s activities • Requirement’s collection & analysis • System& Database Design • Design and develop APIsproducts', 1)
GO
SET IDENTITY_INSERT [dbo].[Experience] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonalInfo] ON 
GO
INSERT [dbo].[PersonalInfo] ([Id], [Name], [DoB], [Address], [Email], [Phone], [MaritalStatus]) VALUES (1, N'Md. Golam Mostafa', CAST(N'1990-03-15T00:00:00.0000000' AS DateTime2), N'17, Dogair, Demra Dhaka1261.', N'gmostafa358@gmail.com', N'01886621899', N'Married')
GO
SET IDENTITY_INSERT [dbo].[PersonalInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 
GO
INSERT [dbo].[Project] ([Id], [Name], [Description], [Technologies]) VALUES (1, N'Patients Management System', N'It refers to several efficient automated systems that track patient information, diagnoses, prescriptions, interactions and encounters.', N'Asp.net core Api, Angular')
GO
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[Resume] ON 
GO
GO
SET IDENTITY_INSERT [dbo].[Resume] OFF
GO
/****** Object:  Index [IX_Experience_CompanyId]    Script Date: 4/29/2023 8:50:07 PM ******/
CREATE NONCLUSTERED INDEX [IX_Experience_CompanyId] ON [dbo].[Experience]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Experience]  WITH CHECK ADD  CONSTRAINT [FK_Experience_Company_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Experience] CHECK CONSTRAINT [FK_Experience_Company_CompanyId]
GO
USE [master]
GO
ALTER DATABASE [Portfolio] SET  READ_WRITE 
GO