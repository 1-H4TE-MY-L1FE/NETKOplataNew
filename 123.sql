USE [master]
GO
/****** Object:  Database [OplataNETK]    Script Date: 21.12.2023 8:26:33 ******/
CREATE DATABASE [OplataNETK]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OplataNETK', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\OplataNETK.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OplataNETK_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\OplataNETK_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [OplataNETK] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OplataNETK].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OplataNETK] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OplataNETK] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OplataNETK] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OplataNETK] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OplataNETK] SET ARITHABORT OFF 
GO
ALTER DATABASE [OplataNETK] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OplataNETK] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OplataNETK] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OplataNETK] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OplataNETK] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OplataNETK] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OplataNETK] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OplataNETK] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OplataNETK] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OplataNETK] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OplataNETK] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OplataNETK] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OplataNETK] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OplataNETK] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OplataNETK] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OplataNETK] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OplataNETK] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OplataNETK] SET RECOVERY FULL 
GO
ALTER DATABASE [OplataNETK] SET  MULTI_USER 
GO
ALTER DATABASE [OplataNETK] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OplataNETK] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OplataNETK] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OplataNETK] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OplataNETK] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OplataNETK] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OplataNETK', N'ON'
GO
ALTER DATABASE [OplataNETK] SET QUERY_STORE = ON
GO
ALTER DATABASE [OplataNETK] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [OplataNETK]
GO
/****** Object:  Table [dbo].[CardStudent]    Script Date: 21.12.2023 8:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](50) NOT NULL,
	[IdGroup] [int] NOT NULL,
	[IdObshejit] [int] NOT NULL,
	[IdKatPlat] [int] NOT NULL,
	[YearStar] [date] NULL,
	[YearFinal] [date] NULL,
	[Otchis] [int] NULL,
	[Note] [nvarchar](50) NULL,
	[Room] [int] NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_CardStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 21.12.2023 8:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InputPrice]    Script Date: 21.12.2023 8:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InputPrice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DatePrice] [date] NOT NULL,
	[NumberDoc] [int] NOT NULL,
	[SumPrice] [int] NOT NULL,
	[Note] [nvarchar](50) NOT NULL,
	[IdCardStudent] [int] NOT NULL,
	[Lgota] [int] NULL,
 CONSTRAINT [PK_InputPrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KatPlat]    Script Date: 21.12.2023 8:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KatPlat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_KatPlat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PriceLife]    Script Date: 21.12.2023 8:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceLife](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Obshejit] [nvarchar](50) NOT NULL,
	[FormLearn] [nvarchar](50) NOT NULL,
	[IdKatPlat] [int] NOT NULL,
	[September] [int] NOT NULL,
	[October] [int] NOT NULL,
	[November] [int] NOT NULL,
	[December] [int] NOT NULL,
	[January] [int] NOT NULL,
	[February] [int] NOT NULL,
	[March] [int] NOT NULL,
	[April] [int] NOT NULL,
	[May] [int] NOT NULL,
	[June] [int] NOT NULL,
	[July] [int] NOT NULL,
	[August] [int] NOT NULL,
	[Norma] [int] NULL,
 CONSTRAINT [PK_PriceLife] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 21.12.2023 8:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21.12.2023 8:26:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CardStudent] ON 

INSERT [dbo].[CardStudent] ([Id], [FIO], [IdGroup], [IdObshejit], [IdKatPlat], [YearStar], [YearFinal], [Otchis], [Note], [Room], [Image]) VALUES (1, N'Иванов А.Н.', 1, 1, 1, CAST(N'2020-09-01' AS Date), CAST(N'2023-06-30' AS Date), NULL, N'Переч', 52, NULL)
INSERT [dbo].[CardStudent] ([Id], [FIO], [IdGroup], [IdObshejit], [IdKatPlat], [YearStar], [YearFinal], [Otchis], [Note], [Room], [Image]) VALUES (2, N'Сидоров Я.Р.', 2, 1, 1, CAST(N'2020-09-01' AS Date), CAST(N'2023-06-30' AS Date), NULL, N'Переч', 43, NULL)
INSERT [dbo].[CardStudent] ([Id], [FIO], [IdGroup], [IdObshejit], [IdKatPlat], [YearStar], [YearFinal], [Otchis], [Note], [Room], [Image]) VALUES (3, N'Архипов П.Л.', 3, 1, 1, CAST(N'2020-09-01' AS Date), CAST(N'2023-06-30' AS Date), NULL, N'Переч', 17, NULL)
INSERT [dbo].[CardStudent] ([Id], [FIO], [IdGroup], [IdObshejit], [IdKatPlat], [YearStar], [YearFinal], [Otchis], [Note], [Room], [Image]) VALUES (5, N'asd', 3, 4, 3, NULL, NULL, NULL, N'', NULL, NULL)
SET IDENTITY_INSERT [dbo].[CardStudent] OFF
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([Id], [Name]) VALUES (1, N'22Ю')
INSERT [dbo].[Group] ([Id], [Name]) VALUES (2, N'13Т')
INSERT [dbo].[Group] ([Id], [Name]) VALUES (3, N'31П')
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
SET IDENTITY_INSERT [dbo].[KatPlat] ON 

INSERT [dbo].[KatPlat] ([Id], [Name]) VALUES (1, N'Студент техникума')
INSERT [dbo].[KatPlat] ([Id], [Name]) VALUES (2, N'Студент другого учебного аведения')
INSERT [dbo].[KatPlat] ([Id], [Name]) VALUES (3, N'Прочие')
SET IDENTITY_INSERT [dbo].[KatPlat] OFF
GO
SET IDENTITY_INSERT [dbo].[PriceLife] ON 

INSERT [dbo].[PriceLife] ([Id], [Obshejit], [FormLearn], [IdKatPlat], [September], [October], [November], [December], [January], [February], [March], [April], [May], [June], [July], [August], [Norma]) VALUES (1, N'Общежитие 2', N'Очная', 1, 1650, 1650, 1650, 1650, 1650, 1650, 1650, 1650, 1650, 1650, 1650, 1650, 19800)
INSERT [dbo].[PriceLife] ([Id], [Obshejit], [FormLearn], [IdKatPlat], [September], [October], [November], [December], [January], [February], [March], [April], [May], [June], [July], [August], [Norma]) VALUES (2, N'Общежитие 2', N'Очная', 2, 2000, 2000, 2000, 2000, 2000, 2000, 2000, 2000, 2000, 2000, 2000, 2000, 24000)
INSERT [dbo].[PriceLife] ([Id], [Obshejit], [FormLearn], [IdKatPlat], [September], [October], [November], [December], [January], [February], [March], [April], [May], [June], [July], [August], [Norma]) VALUES (3, N'Общежитие 2', N'Очная', 3, 3000, 3000, 3000, 3000, 3000, 3000, 3000, 3000, 3000, 3000, 3000, 3000, 36000)
INSERT [dbo].[PriceLife] ([Id], [Obshejit], [FormLearn], [IdKatPlat], [September], [October], [November], [December], [January], [February], [March], [April], [May], [June], [July], [August], [Norma]) VALUES (4, N'Общежитие 3', N'Очная', 3, 9000, 9000, 9000, 9000, 9000, 9000, 9000, 9000, 9000, 9000, 9000, 9000, 108000)
SET IDENTITY_INSERT [dbo].[PriceLife] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Бухгалтер')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Классный руководитель')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Password], [IdRole]) VALUES (1, N'1', N'1', 1)
INSERT [dbo].[User] ([Id], [Name], [Password], [IdRole]) VALUES (2, N'2', N'2', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[CardStudent]  WITH CHECK ADD  CONSTRAINT [FK_CardStudent_Group] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[CardStudent] CHECK CONSTRAINT [FK_CardStudent_Group]
GO
ALTER TABLE [dbo].[CardStudent]  WITH CHECK ADD  CONSTRAINT [FK_CardStudent_KatPlat] FOREIGN KEY([IdKatPlat])
REFERENCES [dbo].[KatPlat] ([Id])
GO
ALTER TABLE [dbo].[CardStudent] CHECK CONSTRAINT [FK_CardStudent_KatPlat]
GO
ALTER TABLE [dbo].[CardStudent]  WITH CHECK ADD  CONSTRAINT [FK_CardStudent_PriceLife] FOREIGN KEY([IdObshejit])
REFERENCES [dbo].[PriceLife] ([Id])
GO
ALTER TABLE [dbo].[CardStudent] CHECK CONSTRAINT [FK_CardStudent_PriceLife]
GO
ALTER TABLE [dbo].[InputPrice]  WITH CHECK ADD  CONSTRAINT [FK_InputPrice_CardStudent] FOREIGN KEY([IdCardStudent])
REFERENCES [dbo].[CardStudent] ([Id])
GO
ALTER TABLE [dbo].[InputPrice] CHECK CONSTRAINT [FK_InputPrice_CardStudent]
GO
ALTER TABLE [dbo].[PriceLife]  WITH CHECK ADD  CONSTRAINT [FK_PriceLife_KatPlat] FOREIGN KEY([IdKatPlat])
REFERENCES [dbo].[KatPlat] ([Id])
GO
ALTER TABLE [dbo].[PriceLife] CHECK CONSTRAINT [FK_PriceLife_KatPlat]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [OplataNETK] SET  READ_WRITE 
GO
