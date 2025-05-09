USE [master]
GO
/****** Object:  Database [BDA_pat_otd]    Script Date: 10.04.2025 23:00:20 ******/
CREATE DATABASE [BDA_pat_otd]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDA_pat_otd', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BDA_pat_otd.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDA_pat_otd_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BDA_pat_otd_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BDA_pat_otd] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDA_pat_otd].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDA_pat_otd] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDA_pat_otd] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDA_pat_otd] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDA_pat_otd] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDA_pat_otd] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET RECOVERY FULL 
GO
ALTER DATABASE [BDA_pat_otd] SET  MULTI_USER 
GO
ALTER DATABASE [BDA_pat_otd] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDA_pat_otd] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDA_pat_otd] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDA_pat_otd] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDA_pat_otd] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDA_pat_otd] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BDA_pat_otd', N'ON'
GO
ALTER DATABASE [BDA_pat_otd] SET QUERY_STORE = ON
GO
ALTER DATABASE [BDA_pat_otd] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BDA_pat_otd]
GO
/****** Object:  User [PathologistUser]    Script Date: 10.04.2025 23:00:21 ******/
CREATE USER [PathologistUser] FOR LOGIN [PathologistLogin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ManagementUser]    Script Date: 10.04.2025 23:00:21 ******/
CREATE USER [ManagementUser] FOR LOGIN [ManagementLogin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [LabTechUser]    Script Date: 10.04.2025 23:00:21 ******/
CREATE USER [LabTechUser] FOR LOGIN [LabTechLogin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [AdminUser]    Script Date: 10.04.2025 23:00:21 ******/
CREATE USER [AdminUser] FOR LOGIN [AdminLogin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [PathologistRole]    Script Date: 10.04.2025 23:00:21 ******/
CREATE ROLE [PathologistRole]
GO
/****** Object:  DatabaseRole [ManagementRole]    Script Date: 10.04.2025 23:00:21 ******/
CREATE ROLE [ManagementRole]
GO
/****** Object:  DatabaseRole [LabTechnicianRole]    Script Date: 10.04.2025 23:00:21 ******/
CREATE ROLE [LabTechnicianRole]
GO
/****** Object:  DatabaseRole [AdminRole]    Script Date: 10.04.2025 23:00:21 ******/
CREATE ROLE [AdminRole]
GO
ALTER ROLE [PathologistRole] ADD MEMBER [PathologistUser]
GO
ALTER ROLE [ManagementRole] ADD MEMBER [ManagementUser]
GO
ALTER ROLE [LabTechnicianRole] ADD MEMBER [LabTechUser]
GO
ALTER ROLE [AdminRole] ADD MEMBER [AdminUser]
GO
ALTER ROLE [db_owner] ADD MEMBER [AdminUser]
GO
/****** Object:  Table [dbo].[Сотрудники]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Сотрудники](
	[ID_Сотрудника] [int] IDENTITY(1,1) NOT NULL,
	[Логин] [varchar](50) NOT NULL,
	[ПарольHash] [varchar](255) NOT NULL,
	[ФИО] [varchar](255) NOT NULL,
	[Должность] [varchar](100) NOT NULL,
	[КонтактныйТелефон] [varchar](15) NULL,
	[Email] [varchar](100) NULL,
 CONSTRAINT [PK__Сотрудни__F4052FE3C78411BB] PRIMARY KEY CLUSTERED 
(
	[ID_Сотрудника] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Умершие]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Умершие](
	[ID_Умершего] [int] IDENTITY(1,1) NOT NULL,
	[ФИО] [varchar](255) NOT NULL,
	[Дата_Смерти] [date] NOT NULL,
	[Место_Смерти] [varchar](255) NULL,
	[Причина_Смерти] [text] NULL,
	[Дата_Поступления] [date] NOT NULL,
 CONSTRAINT [PK__Умершие__4D6164C377EA592F] PRIMARY KEY CLUSTERED 
(
	[ID_Умершего] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Исследования]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Исследования](
	[ID_Исследования] [int] IDENTITY(1,1) NOT NULL,
	[ID_Умершего] [int] NOT NULL,
	[Тип_Исследования] [varchar](255) NOT NULL,
	[Дата_Проведения] [date] NOT NULL,
	[Описание] [text] NULL,
	[Результаты] [text] NULL,
	[ID_Исполнителя] [int] NOT NULL,
 CONSTRAINT [PK__Исследов__F7A88EA5F9E66EFA] PRIMARY KEY CLUSTERED 
(
	[ID_Исследования] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Отчет_Проведенные_Исследования]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Отчет_Проведенные_Исследования]
AS
SELECT 
    и.ID_Исследования,
    у.ФИО AS ФИО_Умершего,
    и.Тип_Исследования,
    и.Дата_Проведения,
    и.Описание,
    и.Результаты,
    с.ФИО AS ФИО_Исполнителя
FROM 
    [dbo].[Исследования] и
JOIN 
    [dbo].[Умершие] у ON и.ID_Умершего = у.ID_Умершего
JOIN 
    [dbo].[Сотрудники] с ON и.ID_Исполнителя = с.ID_Сотрудника;
GO
/****** Object:  Table [dbo].[Транспортировка]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Транспортировка](
	[ID_Транспортировки] [int] IDENTITY(1,1) NOT NULL,
	[ID_Умершего] [int] NOT NULL,
	[Тип_Перемещения] [varchar](50) NOT NULL,
	[Дата_Время] [datetime] NOT NULL,
	[Место_Отправления] [varchar](255) NULL,
	[Место_Назначения] [varchar](255) NULL,
	[ID_Ответственного] [int] NOT NULL,
 CONSTRAINT [PK__Транспор__D80A3ACC0A8810C0] PRIMARY KEY CLUSTERED 
(
	[ID_Транспортировки] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Статистика_Движения_Умерших]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Статистика_Движения_Умерших]
AS
SELECT 
    у.ID_Умершего,
    у.ФИО,
    у.Дата_Смерти,
    у.Место_Смерти,
    у.Причина_Смерти,
    т.Тип_Перемещения,
    т.Дата_Время AS Дата_Перемещения,
    т.Место_Отправления,
    т.Место_Назначения,
    с.ФИО AS ФИО_Ответственного
FROM 
    [dbo].[Умершие] у
LEFT JOIN 
    [dbo].[Транспортировка] т ON у.ID_Умершего = т.ID_Умершего
LEFT JOIN 
    [dbo].[Сотрудники] с ON т.ID_Ответственного = с.ID_Сотрудника;
GO
/****** Object:  Table [dbo].[Способ_Оплаты]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Способ_Оплаты](
	[ID_Способа] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Способ_О__B24A498714D78E75] PRIMARY KEY CLUSTERED 
(
	[ID_Способа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Услуги]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Услуги](
	[ID_Услуги] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [varchar](255) NOT NULL,
	[Описание] [text] NULL,
	[Стоимость] [decimal](10, 2) NOT NULL,
	[Тип] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Услуги__C62AED9B09C78EAB] PRIMARY KEY CLUSTERED 
(
	[ID_Услуги] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Заявки_на_Платные_Услуги]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заявки_на_Платные_Услуги](
	[ID_Заявки] [int] IDENTITY(1,1) NOT NULL,
	[ID_Услуги] [int] NOT NULL,
	[ФИО_Заказчика] [varchar](255) NOT NULL,
	[КонтактныйТелефон] [varchar](15) NULL,
	[Дата_Подачи] [date] NOT NULL,
	[Статус] [varchar](50) NOT NULL,
	[ID_Ответственного] [int] NOT NULL,
 CONSTRAINT [PK__Заявки_н__78768B7807CE3AE2] PRIMARY KEY CLUSTERED 
(
	[ID_Заявки] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Финансовые_Операции]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Финансовые_Операции](
	[ID_Операции] [int] IDENTITY(1,1) NOT NULL,
	[ID_Заявки] [int] NOT NULL,
	[Сумма] [decimal](10, 2) NOT NULL,
	[Тип] [varchar](50) NOT NULL,
	[Дата_Операции] [date] NOT NULL,
	[ID_Способа] [int] NOT NULL,
 CONSTRAINT [PK__Финансов__4023227C8B729031] PRIMARY KEY CLUSTERED 
(
	[ID_Операции] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Мониторинг_Финансовых_Операций]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Мониторинг_Финансовых_Операций]
AS
SELECT 
    ф.ID_Операции,
    з.Наименование AS Услуга,
    ф.Сумма,
    ф.Тип AS Тип_Операции,
    ф.Дата_Операции,
    сп.Наименование AS Способ_Оплаты,
    с.ФИО AS ФИО_Ответственного
FROM 
    [dbo].[Финансовые_Операции] ф
JOIN 
    [dbo].[Заявки_на_Платные_Услуги] зф ON ф.ID_Заявки = зф.ID_Заявки
JOIN 
    [dbo].[Услуги] з ON зф.ID_Услуги = з.ID_Услуги
JOIN 
    [dbo].[Способ_Оплаты] сп ON ф.ID_Способа = сп.ID_Способа
LEFT JOIN 
    [dbo].[Сотрудники] с ON зф.ID_Ответственного = с.ID_Сотрудника;
GO
/****** Object:  Table [dbo].[Журнал_Обращений]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Журнал_Обращений](
	[ID_Записи] [int] IDENTITY(1,1) NOT NULL,
	[ФИО_Обратившегося] [varchar](255) NOT NULL,
	[КонтактныйТелефон] [varchar](15) NULL,
	[СвязьСУмершим] [varchar](100) NULL,
	[Дата_Обращения] [date] NOT NULL,
	[Тип_Обращения] [varchar](50) NOT NULL,
	[Описание] [text] NULL,
	[ID_Ответственного] [int] NOT NULL,
 CONSTRAINT [PK__Журнал_О__F0CD26FD05A1A392] PRIMARY KEY CLUSTERED 
(
	[ID_Записи] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Журнал_Температур]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Журнал_Температур](
	[ID_Записи] [int] IDENTITY(1,1) NOT NULL,
	[ID_Камеры] [int] NOT NULL,
	[Дата_Измерения] [datetime] NOT NULL,
	[Температура] [decimal](5, 2) NOT NULL,
	[ID_Ответственного] [int] NOT NULL,
 CONSTRAINT [PK__Журнал_Т__F0CD26FD2839D40D] PRIMARY KEY CLUSTERED 
(
	[ID_Записи] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Инвентарь]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Инвентарь](
	[ID_Инвентаря] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [varchar](255) NOT NULL,
	[Количество] [int] NOT NULL,
	[Единица_Измерения] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Инвентар__600C9B5264EE98CC] PRIMARY KEY CLUSTERED 
(
	[ID_Инвентаря] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Использование_Инвентаря]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Использование_Инвентаря](
	[ID_Использования] [int] IDENTITY(1,1) NOT NULL,
	[ID_Исследования] [int] NOT NULL,
	[ID_Инвентаря] [int] NOT NULL,
	[КоличествоИспользовано] [int] NOT NULL,
	[ID_Ответственного] [int] NOT NULL,
 CONSTRAINT [PK__Использо__8E1CF29FDA075913] PRIMARY KEY CLUSTERED 
(
	[ID_Использования] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Использование_Образцов]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Использование_Образцов](
	[ID_Использования] [int] IDENTITY(1,1) NOT NULL,
	[ID_Образца] [int] NOT NULL,
	[ID_Исследования] [int] NOT NULL,
	[Количество_Использовано] [decimal](10, 2) NOT NULL,
	[ID_Ответственного] [int] NOT NULL,
 CONSTRAINT [PK__Использо__8E1CF29F671ADEC9] PRIMARY KEY CLUSTERED 
(
	[ID_Использования] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Камеры_Хранения]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Камеры_Хранения](
	[ID_Камеры] [int] IDENTITY(1,1) NOT NULL,
	[Номер_Камеры] [int] NOT NULL,
	[Температура] [decimal](5, 2) NOT NULL,
	[Вместимость] [int] NOT NULL,
 CONSTRAINT [PK__Камеры_Х__FAB239C7C517C881] PRIMARY KEY CLUSTERED 
(
	[ID_Камеры] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Места_В_Камерах]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Места_В_Камерах](
	[ID_Места] [int] IDENTITY(1,1) NOT NULL,
	[ID_Камеры] [int] NOT NULL,
	[ID_Умершего] [int] NOT NULL,
	[Дата_Размещения] [date] NOT NULL,
	[Дата_Извлечения] [date] NULL,
 CONSTRAINT [PK__Места_В___62E6D9A9E1BFA7CF] PRIMARY KEY CLUSTERED 
(
	[ID_Места] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Образцы]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Образцы](
	[ID_Образца] [int] IDENTITY(1,1) NOT NULL,
	[ID_Умершего] [int] NOT NULL,
	[Тип_Образца] [varchar](50) NOT NULL,
	[Дата_Взятия] [date] NOT NULL,
	[Условия_Хранения] [varchar](255) NULL,
	[ID_Ответственного] [int] NOT NULL,
 CONSTRAINT [PK__Образцы__A4EF0C4331536E02] PRIMARY KEY CLUSTERED 
(
	[ID_Образца] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Платные_Исследования]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Платные_Исследования](
	[ID_Платного_Исследования] [int] IDENTITY(1,1) NOT NULL,
	[ID_Заявки] [int] NOT NULL,
	[Тип_Исследования] [varchar](255) NOT NULL,
	[Дата_Проведения] [date] NOT NULL,
	[Описание] [text] NULL,
	[Результаты] [text] NULL,
	[ID_Исполнителя] [int] NOT NULL,
 CONSTRAINT [PK__Платные___F9A1D29FDF83D36F] PRIMARY KEY CLUSTERED 
(
	[ID_Платного_Исследования] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Журнал_Обращений] ON 

INSERT [dbo].[Журнал_Обращений] ([ID_Записи], [ФИО_Обратившегося], [КонтактныйТелефон], [СвязьСУмершим], [Дата_Обращения], [Тип_Обращения], [Описание], [ID_Ответственного]) VALUES (1, N'Иванова Мария Петровна', N'+79001234501', N'Дочь', CAST(N'2023-10-01' AS Date), N'Обращение', N'Запрос информации о состоянии исследований', 1)
INSERT [dbo].[Журнал_Обращений] ([ID_Записи], [ФИО_Обратившегося], [КонтактныйТелефон], [СвязьСУмершим], [Дата_Обращения], [Тип_Обращения], [Описание], [ID_Ответственного]) VALUES (2, N'Петров Сергей Иванович', N'+79001234502', N'Сын', CAST(N'2023-10-02' AS Date), N'Жалоба', N'Претензия по срокам проведения исследований', 2)
INSERT [dbo].[Журнал_Обращений] ([ID_Записи], [ФИО_Обратившегося], [КонтактныйТелефон], [СвязьСУмершим], [Дата_Обращения], [Тип_Обращения], [Описание], [ID_Ответственного]) VALUES (3, N'Сидорова Анна Владимировна', N'+79001234503', N'Супруга', CAST(N'2023-10-03' AS Date), N'Обращение', N'Запрос копии медицинского заключения', 3)
INSERT [dbo].[Журнал_Обращений] ([ID_Записи], [ФИО_Обратившегося], [КонтактныйТелефон], [СвязьСУмершим], [Дата_Обращения], [Тип_Обращения], [Описание], [ID_Ответственного]) VALUES (4, N'Кузнецов Дмитрий Сергеевич', N'+79001234504', N'Брат', CAST(N'2023-10-04' AS Date), N'Жалоба', N'Недостаточная информация в отчете', 1)
INSERT [dbo].[Журнал_Обращений] ([ID_Записи], [ФИО_Обратившегося], [КонтактныйТелефон], [СвязьСУмершим], [Дата_Обращения], [Тип_Обращения], [Описание], [ID_Ответственного]) VALUES (5, N'Михайлова Елена Андреевна', N'+79001234505', N'Мать', CAST(N'2023-10-05' AS Date), N'Обращение', N'Запрос даты выдачи тела', 2)
INSERT [dbo].[Журнал_Обращений] ([ID_Записи], [ФИО_Обратившегося], [КонтактныйТелефон], [СвязьСУмершим], [Дата_Обращения], [Тип_Обращения], [Описание], [ID_Ответственного]) VALUES (6, N'Федоров Андрей Сергеевич', N'+79001234506', N'Отец', CAST(N'2023-10-06' AS Date), N'Жалоба', N'Претензия по качеству обслуживания', 3)
INSERT [dbo].[Журнал_Обращений] ([ID_Записи], [ФИО_Обратившегося], [КонтактныйТелефон], [СвязьСУмершим], [Дата_Обращения], [Тип_Обращения], [Описание], [ID_Ответственного]) VALUES (7, N'Николаева Ирина Викторовна', N'+79001234507', N'Сестра', CAST(N'2023-10-07' AS Date), N'Обращение', N'Запрос результатов исследований', 1)
INSERT [dbo].[Журнал_Обращений] ([ID_Записи], [ФИО_Обратившегося], [КонтактныйТелефон], [СвязьСУмершим], [Дата_Обращения], [Тип_Обращения], [Описание], [ID_Ответственного]) VALUES (8, N'Ковалев Николай Николаевич', N'+79001234508', N'Сын', CAST(N'2023-10-08' AS Date), N'Жалоба', N'Неудовлетворенность условиями хранения', 2)
INSERT [dbo].[Журнал_Обращений] ([ID_Записи], [ФИО_Обратившегося], [КонтактныйТелефон], [СвязьСУмершим], [Дата_Обращения], [Тип_Обращения], [Описание], [ID_Ответственного]) VALUES (9, N'Смирнова Ольга Петровна', N'+79001234509', N'Дочь', CAST(N'2023-10-09' AS Date), N'Обращение', N'Запрос дополнительной информации', 3)
INSERT [dbo].[Журнал_Обращений] ([ID_Записи], [ФИО_Обратившегося], [КонтактныйТелефон], [СвязьСУмершим], [Дата_Обращения], [Тип_Обращения], [Описание], [ID_Ответственного]) VALUES (10, N'Морозов Александр Александрович', N'+79001234510', N'Сын', CAST(N'2023-10-10' AS Date), N'Жалоба', N'Претензия по срокам выдачи тела', 1)
SET IDENTITY_INSERT [dbo].[Журнал_Обращений] OFF
GO
SET IDENTITY_INSERT [dbo].[Журнал_Температур] ON 

INSERT [dbo].[Журнал_Температур] ([ID_Записи], [ID_Камеры], [Дата_Измерения], [Температура], [ID_Ответственного]) VALUES (1, 1, CAST(N'2023-01-10T08:00:00.000' AS DateTime), CAST(-4.50 AS Decimal(5, 2)), 1)
INSERT [dbo].[Журнал_Температур] ([ID_Записи], [ID_Камеры], [Дата_Измерения], [Температура], [ID_Ответственного]) VALUES (2, 2, CAST(N'2023-01-10T08:05:00.000' AS DateTime), CAST(-5.00 AS Decimal(5, 2)), 2)
INSERT [dbo].[Журнал_Температур] ([ID_Записи], [ID_Камеры], [Дата_Измерения], [Температура], [ID_Ответственного]) VALUES (3, 3, CAST(N'2023-01-10T08:10:00.000' AS DateTime), CAST(-4.80 AS Decimal(5, 2)), 3)
INSERT [dbo].[Журнал_Температур] ([ID_Записи], [ID_Камеры], [Дата_Измерения], [Температура], [ID_Ответственного]) VALUES (4, 4, CAST(N'2023-01-10T08:15:00.000' AS DateTime), CAST(-5.20 AS Decimal(5, 2)), 1)
INSERT [dbo].[Журнал_Температур] ([ID_Записи], [ID_Камеры], [Дата_Измерения], [Температура], [ID_Ответственного]) VALUES (5, 5, CAST(N'2023-01-10T08:20:00.000' AS DateTime), CAST(-4.70 AS Decimal(5, 2)), 2)
INSERT [dbo].[Журнал_Температур] ([ID_Записи], [ID_Камеры], [Дата_Измерения], [Температура], [ID_Ответственного]) VALUES (6, 6, CAST(N'2023-01-10T08:25:00.000' AS DateTime), CAST(-5.10 AS Decimal(5, 2)), 3)
INSERT [dbo].[Журнал_Температур] ([ID_Записи], [ID_Камеры], [Дата_Измерения], [Температура], [ID_Ответственного]) VALUES (7, 7, CAST(N'2023-01-10T08:30:00.000' AS DateTime), CAST(-4.90 AS Decimal(5, 2)), 1)
INSERT [dbo].[Журнал_Температур] ([ID_Записи], [ID_Камеры], [Дата_Измерения], [Температура], [ID_Ответственного]) VALUES (8, 8, CAST(N'2023-01-10T08:35:00.000' AS DateTime), CAST(-5.30 AS Decimal(5, 2)), 2)
INSERT [dbo].[Журнал_Температур] ([ID_Записи], [ID_Камеры], [Дата_Измерения], [Температура], [ID_Ответственного]) VALUES (9, 9, CAST(N'2023-01-10T08:40:00.000' AS DateTime), CAST(-4.60 AS Decimal(5, 2)), 3)
INSERT [dbo].[Журнал_Температур] ([ID_Записи], [ID_Камеры], [Дата_Измерения], [Температура], [ID_Ответственного]) VALUES (10, 10, CAST(N'2023-01-10T08:45:00.000' AS DateTime), CAST(-5.00 AS Decimal(5, 2)), 1)
SET IDENTITY_INSERT [dbo].[Журнал_Температур] OFF
GO
SET IDENTITY_INSERT [dbo].[Заявки_на_Платные_Услуги] ON 

INSERT [dbo].[Заявки_на_Платные_Услуги] ([ID_Заявки], [ID_Услуги], [ФИО_Заказчика], [КонтактныйТелефон], [Дата_Подачи], [Статус], [ID_Ответственного]) VALUES (1, 1, N'Иванов Петр Сергеевич', N'+79001234567', CAST(N'2023-10-01' AS Date), N'Завершена', 1)
INSERT [dbo].[Заявки_на_Платные_Услуги] ([ID_Заявки], [ID_Услуги], [ФИО_Заказчика], [КонтактныйТелефон], [Дата_Подачи], [Статус], [ID_Ответственного]) VALUES (2, 2, N'Петрова Мария Ивановна', N'+79001234568', CAST(N'2023-10-02' AS Date), N'В работе', 2)
INSERT [dbo].[Заявки_на_Платные_Услуги] ([ID_Заявки], [ID_Услуги], [ФИО_Заказчика], [КонтактныйТелефон], [Дата_Подачи], [Статус], [ID_Ответственного]) VALUES (3, 3, N'Сидоров Алексей Владимирович', N'+79001234569', CAST(N'2023-10-03' AS Date), N'Новая', 3)
INSERT [dbo].[Заявки_на_Платные_Услуги] ([ID_Заявки], [ID_Услуги], [ФИО_Заказчика], [КонтактныйТелефон], [Дата_Подачи], [Статус], [ID_Ответственного]) VALUES (4, 4, N'Кузнецова Елена Петровна', N'+79001234570', CAST(N'2023-10-04' AS Date), N'Завершена', 1)
INSERT [dbo].[Заявки_на_Платные_Услуги] ([ID_Заявки], [ID_Услуги], [ФИО_Заказчика], [КонтактныйТелефон], [Дата_Подачи], [Статус], [ID_Ответственного]) VALUES (5, 5, N'Михайлов Дмитрий Андреевич', N'+79001234571', CAST(N'2023-10-05' AS Date), N'В работе', 2)
INSERT [dbo].[Заявки_на_Платные_Услуги] ([ID_Заявки], [ID_Услуги], [ФИО_Заказчика], [КонтактныйТелефон], [Дата_Подачи], [Статус], [ID_Ответственного]) VALUES (6, 6, N'Федорова Анна Сергеевна', N'+79001234572', CAST(N'2023-10-06' AS Date), N'Новая', 3)
INSERT [dbo].[Заявки_на_Платные_Услуги] ([ID_Заявки], [ID_Услуги], [ФИО_Заказчика], [КонтактныйТелефон], [Дата_Подачи], [Статус], [ID_Ответственного]) VALUES (7, 7, N'Николаев Игорь Викторович', N'+79001234573', CAST(N'2023-10-07' AS Date), N'Завершена', 1)
INSERT [dbo].[Заявки_на_Платные_Услуги] ([ID_Заявки], [ID_Услуги], [ФИО_Заказчика], [КонтактныйТелефон], [Дата_Подачи], [Статус], [ID_Ответственного]) VALUES (8, 8, N'Ковалева Ольга Николаевна', N'+79001234574', CAST(N'2023-10-08' AS Date), N'В работе', 2)
INSERT [dbo].[Заявки_на_Платные_Услуги] ([ID_Заявки], [ID_Услуги], [ФИО_Заказчика], [КонтактныйТелефон], [Дата_Подачи], [Статус], [ID_Ответственного]) VALUES (9, 9, N'Смирнов Владимир Петрович', N'+79001234575', CAST(N'2023-10-09' AS Date), N'Новая', 3)
INSERT [dbo].[Заявки_на_Платные_Услуги] ([ID_Заявки], [ID_Услуги], [ФИО_Заказчика], [КонтактныйТелефон], [Дата_Подачи], [Статус], [ID_Ответственного]) VALUES (10, 10, N'Морозова Татьяна Александровна', N'+79001234576', CAST(N'2023-10-10' AS Date), N'Завершена', 1)
SET IDENTITY_INSERT [dbo].[Заявки_на_Платные_Услуги] OFF
GO
SET IDENTITY_INSERT [dbo].[Инвентарь] ON 

INSERT [dbo].[Инвентарь] ([ID_Инвентаря], [Наименование], [Количество], [Единица_Измерения]) VALUES (1, N'Шприц', 50, N'шт')
INSERT [dbo].[Инвентарь] ([ID_Инвентаря], [Наименование], [Количество], [Единица_Измерения]) VALUES (2, N'Пробирка', 100, N'шт')
INSERT [dbo].[Инвентарь] ([ID_Инвентаря], [Наименование], [Количество], [Единица_Измерения]) VALUES (3, N'Микроскоп', 5, N'шт')
INSERT [dbo].[Инвентарь] ([ID_Инвентаря], [Наименование], [Количество], [Единица_Измерения]) VALUES (4, N'Лабораторный стол', 10, N'шт')
INSERT [dbo].[Инвентарь] ([ID_Инвентаря], [Наименование], [Количество], [Единица_Измерения]) VALUES (5, N'Холодильник', 3, N'шт')
INSERT [dbo].[Инвентарь] ([ID_Инвентаря], [Наименование], [Количество], [Единица_Измерения]) VALUES (6, N'Перчатки', 200, N'пар')
INSERT [dbo].[Инвентарь] ([ID_Инвентаря], [Наименование], [Количество], [Единица_Измерения]) VALUES (7, N'Маска', 150, N'шт')
INSERT [dbo].[Инвентарь] ([ID_Инвентаря], [Наименование], [Количество], [Единица_Измерения]) VALUES (8, N'Скальпель', 30, N'шт')
INSERT [dbo].[Инвентарь] ([ID_Инвентаря], [Наименование], [Количество], [Единица_Измерения]) VALUES (9, N'Пинцет', 20, N'шт')
INSERT [dbo].[Инвентарь] ([ID_Инвентаря], [Наименование], [Количество], [Единица_Измерения]) VALUES (10, N'Стекло для микроскопа', 200, N'шт')
SET IDENTITY_INSERT [dbo].[Инвентарь] OFF
GO
SET IDENTITY_INSERT [dbo].[Использование_Инвентаря] ON 

INSERT [dbo].[Использование_Инвентаря] ([ID_Использования], [ID_Исследования], [ID_Инвентаря], [КоличествоИспользовано], [ID_Ответственного]) VALUES (1, 1, 1, 2, 1)
INSERT [dbo].[Использование_Инвентаря] ([ID_Использования], [ID_Исследования], [ID_Инвентаря], [КоличествоИспользовано], [ID_Ответственного]) VALUES (2, 2, 2, 5, 2)
INSERT [dbo].[Использование_Инвентаря] ([ID_Использования], [ID_Исследования], [ID_Инвентаря], [КоличествоИспользовано], [ID_Ответственного]) VALUES (3, 3, 3, 1, 3)
INSERT [dbo].[Использование_Инвентаря] ([ID_Использования], [ID_Исследования], [ID_Инвентаря], [КоличествоИспользовано], [ID_Ответственного]) VALUES (4, 4, 4, 1, 1)
INSERT [dbo].[Использование_Инвентаря] ([ID_Использования], [ID_Исследования], [ID_Инвентаря], [КоличествоИспользовано], [ID_Ответственного]) VALUES (5, 5, 5, 1, 2)
INSERT [dbo].[Использование_Инвентаря] ([ID_Использования], [ID_Исследования], [ID_Инвентаря], [КоличествоИспользовано], [ID_Ответственного]) VALUES (6, 6, 6, 10, 3)
INSERT [dbo].[Использование_Инвентаря] ([ID_Использования], [ID_Исследования], [ID_Инвентаря], [КоличествоИспользовано], [ID_Ответственного]) VALUES (7, 7, 7, 3, 1)
INSERT [dbo].[Использование_Инвентаря] ([ID_Использования], [ID_Исследования], [ID_Инвентаря], [КоличествоИспользовано], [ID_Ответственного]) VALUES (8, 8, 8, 2, 2)
INSERT [dbo].[Использование_Инвентаря] ([ID_Использования], [ID_Исследования], [ID_Инвентаря], [КоличествоИспользовано], [ID_Ответственного]) VALUES (9, 9, 9, 1, 3)
INSERT [dbo].[Использование_Инвентаря] ([ID_Использования], [ID_Исследования], [ID_Инвентаря], [КоличествоИспользовано], [ID_Ответственного]) VALUES (10, 10, 10, 5, 1)
SET IDENTITY_INSERT [dbo].[Использование_Инвентаря] OFF
GO
SET IDENTITY_INSERT [dbo].[Использование_Образцов] ON 

INSERT [dbo].[Использование_Образцов] ([ID_Использования], [ID_Образца], [ID_Исследования], [Количество_Использовано], [ID_Ответственного]) VALUES (1, 1, 1, CAST(5.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Использование_Образцов] ([ID_Использования], [ID_Образца], [ID_Исследования], [Количество_Использовано], [ID_Ответственного]) VALUES (2, 2, 2, CAST(3.00 AS Decimal(10, 2)), 2)
INSERT [dbo].[Использование_Образцов] ([ID_Использования], [ID_Образца], [ID_Исследования], [Количество_Использовано], [ID_Ответственного]) VALUES (3, 3, 3, CAST(10.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[Использование_Образцов] ([ID_Использования], [ID_Образца], [ID_Исследования], [Количество_Использовано], [ID_Ответственного]) VALUES (4, 4, 4, CAST(2.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Использование_Образцов] ([ID_Использования], [ID_Образца], [ID_Исследования], [Количество_Использовано], [ID_Ответственного]) VALUES (5, 5, 5, CAST(7.00 AS Decimal(10, 2)), 2)
INSERT [dbo].[Использование_Образцов] ([ID_Использования], [ID_Образца], [ID_Исследования], [Количество_Использовано], [ID_Ответственного]) VALUES (6, 6, 6, CAST(4.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[Использование_Образцов] ([ID_Использования], [ID_Образца], [ID_Исследования], [Количество_Использовано], [ID_Ответственного]) VALUES (7, 7, 7, CAST(8.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Использование_Образцов] ([ID_Использования], [ID_Образца], [ID_Исследования], [Количество_Использовано], [ID_Ответственного]) VALUES (8, 8, 8, CAST(6.00 AS Decimal(10, 2)), 2)
INSERT [dbo].[Использование_Образцов] ([ID_Использования], [ID_Образца], [ID_Исследования], [Количество_Использовано], [ID_Ответственного]) VALUES (9, 9, 9, CAST(9.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[Использование_Образцов] ([ID_Использования], [ID_Образца], [ID_Исследования], [Количество_Использовано], [ID_Ответственного]) VALUES (10, 10, 10, CAST(5.00 AS Decimal(10, 2)), 1)
SET IDENTITY_INSERT [dbo].[Использование_Образцов] OFF
GO
SET IDENTITY_INSERT [dbo].[Исследования] ON 

INSERT [dbo].[Исследования] ([ID_Исследования], [ID_Умершего], [Тип_Исследования], [Дата_Проведения], [Описание], [Результаты], [ID_Исполнителя]) VALUES (1, 1, N'Гистологическое', CAST(N'2023-09-03' AS Date), N'Анализ тканей головного мозга', N'Обнаружены признаки кровоизлияния', 2)
INSERT [dbo].[Исследования] ([ID_Исследования], [ID_Умершего], [Тип_Исследования], [Дата_Проведения], [Описание], [Результаты], [ID_Исполнителя]) VALUES (2, 2, N'Цитологическое', CAST(N'2023-09-04' AS Date), N'Исследование клеток сердца', N'Признаки инфаркта миокарда', 3)
INSERT [dbo].[Исследования] ([ID_Исследования], [ID_Умершего], [Тип_Исследования], [Дата_Проведения], [Описание], [Результаты], [ID_Исполнителя]) VALUES (3, 3, N'Молекулярное', CAST(N'2023-09-05' AS Date), N'Анализ ДНК на мутации', N'Мутации не обнаружены', 1)
INSERT [dbo].[Исследования] ([ID_Исследования], [ID_Умершего], [Тип_Исследования], [Дата_Проведения], [Описание], [Результаты], [ID_Исполнителя]) VALUES (4, 4, N'Иммуногистохимическое', CAST(N'2023-09-06' AS Date), N'Определение HER2-статуса', N'HER2-негативный', 2)
INSERT [dbo].[Исследования] ([ID_Исследования], [ID_Умершего], [Тип_Исследования], [Дата_Проведения], [Описание], [Результаты], [ID_Исполнителя]) VALUES (5, 5, N'Гистологическое', CAST(N'2023-09-07' AS Date), N'Анализ тканей легких', N'Признаки хронического воспаления', 3)
INSERT [dbo].[Исследования] ([ID_Исследования], [ID_Умершего], [Тип_Исследования], [Дата_Проведения], [Описание], [Результаты], [ID_Исполнителя]) VALUES (6, 6, N'Цитологическое', CAST(N'2023-09-08' AS Date), N'Исследование клеток крови', N'Признаки инфекции', 1)
INSERT [dbo].[Исследования] ([ID_Исследования], [ID_Умершего], [Тип_Исследования], [Дата_Проведения], [Описание], [Результаты], [ID_Исполнителя]) VALUES (7, 7, N'Молекулярное', CAST(N'2023-09-09' AS Date), N'Анализ ДНК на мутации', N'Мутации не обнаружены', 2)
INSERT [dbo].[Исследования] ([ID_Исследования], [ID_Умершего], [Тип_Исследования], [Дата_Проведения], [Описание], [Результаты], [ID_Исполнителя]) VALUES (8, 8, N'Иммуногистохимическое', CAST(N'2023-09-10' AS Date), N'Определение HER2-статуса', N'HER2-позитивный', 3)
INSERT [dbo].[Исследования] ([ID_Исследования], [ID_Умершего], [Тип_Исследования], [Дата_Проведения], [Описание], [Результаты], [ID_Исполнителя]) VALUES (9, 9, N'Гистологическое', CAST(N'2023-09-11' AS Date), N'Анализ тканей печени', N'Обнаружены признаки цирроза', 1)
INSERT [dbo].[Исследования] ([ID_Исследования], [ID_Умершего], [Тип_Исследования], [Дата_Проведения], [Описание], [Результаты], [ID_Исполнителя]) VALUES (10, 10, N'Цитологическое', CAST(N'2023-09-12' AS Date), N'Исследование клеток почек', N'Признаки острой недостаточности', 2)
SET IDENTITY_INSERT [dbo].[Исследования] OFF
GO
SET IDENTITY_INSERT [dbo].[Камеры_Хранения] ON 

INSERT [dbo].[Камеры_Хранения] ([ID_Камеры], [Номер_Камеры], [Температура], [Вместимость]) VALUES (1, 1, CAST(-4.50 AS Decimal(5, 2)), 10)
INSERT [dbo].[Камеры_Хранения] ([ID_Камеры], [Номер_Камеры], [Температура], [Вместимость]) VALUES (2, 2, CAST(-5.00 AS Decimal(5, 2)), 12)
INSERT [dbo].[Камеры_Хранения] ([ID_Камеры], [Номер_Камеры], [Температура], [Вместимость]) VALUES (3, 3, CAST(-4.80 AS Decimal(5, 2)), 8)
INSERT [dbo].[Камеры_Хранения] ([ID_Камеры], [Номер_Камеры], [Температура], [Вместимость]) VALUES (4, 4, CAST(-5.20 AS Decimal(5, 2)), 15)
INSERT [dbo].[Камеры_Хранения] ([ID_Камеры], [Номер_Камеры], [Температура], [Вместимость]) VALUES (5, 5, CAST(-4.70 AS Decimal(5, 2)), 10)
INSERT [dbo].[Камеры_Хранения] ([ID_Камеры], [Номер_Камеры], [Температура], [Вместимость]) VALUES (6, 6, CAST(-5.10 AS Decimal(5, 2)), 12)
INSERT [dbo].[Камеры_Хранения] ([ID_Камеры], [Номер_Камеры], [Температура], [Вместимость]) VALUES (7, 7, CAST(-4.90 AS Decimal(5, 2)), 8)
INSERT [dbo].[Камеры_Хранения] ([ID_Камеры], [Номер_Камеры], [Температура], [Вместимость]) VALUES (8, 8, CAST(-5.30 AS Decimal(5, 2)), 15)
INSERT [dbo].[Камеры_Хранения] ([ID_Камеры], [Номер_Камеры], [Температура], [Вместимость]) VALUES (9, 9, CAST(-4.60 AS Decimal(5, 2)), 10)
INSERT [dbo].[Камеры_Хранения] ([ID_Камеры], [Номер_Камеры], [Температура], [Вместимость]) VALUES (10, 10, CAST(-5.00 AS Decimal(5, 2)), 12)
SET IDENTITY_INSERT [dbo].[Камеры_Хранения] OFF
GO
SET IDENTITY_INSERT [dbo].[Места_В_Камерах] ON 

INSERT [dbo].[Места_В_Камерах] ([ID_Места], [ID_Камеры], [ID_Умершего], [Дата_Размещения], [Дата_Извлечения]) VALUES (1, 1, 1, CAST(N'2023-09-02' AS Date), CAST(N'2023-09-05' AS Date))
INSERT [dbo].[Места_В_Камерах] ([ID_Места], [ID_Камеры], [ID_Умершего], [Дата_Размещения], [Дата_Извлечения]) VALUES (2, 2, 2, CAST(N'2023-09-04' AS Date), NULL)
INSERT [dbo].[Места_В_Камерах] ([ID_Места], [ID_Камеры], [ID_Умершего], [Дата_Размещения], [Дата_Извлечения]) VALUES (3, 3, 3, CAST(N'2023-09-06' AS Date), CAST(N'2023-09-08' AS Date))
INSERT [dbo].[Места_В_Камерах] ([ID_Места], [ID_Камеры], [ID_Умершего], [Дата_Размещения], [Дата_Извлечения]) VALUES (4, 4, 4, CAST(N'2023-09-08' AS Date), NULL)
INSERT [dbo].[Места_В_Камерах] ([ID_Места], [ID_Камеры], [ID_Умершего], [Дата_Размещения], [Дата_Извлечения]) VALUES (5, 5, 5, CAST(N'2023-09-10' AS Date), CAST(N'2023-09-12' AS Date))
INSERT [dbo].[Места_В_Камерах] ([ID_Места], [ID_Камеры], [ID_Умершего], [Дата_Размещения], [Дата_Извлечения]) VALUES (6, 6, 6, CAST(N'2023-09-12' AS Date), NULL)
INSERT [dbo].[Места_В_Камерах] ([ID_Места], [ID_Камеры], [ID_Умершего], [Дата_Размещения], [Дата_Извлечения]) VALUES (7, 7, 7, CAST(N'2023-09-14' AS Date), CAST(N'2023-09-16' AS Date))
INSERT [dbo].[Места_В_Камерах] ([ID_Места], [ID_Камеры], [ID_Умершего], [Дата_Размещения], [Дата_Извлечения]) VALUES (8, 8, 8, CAST(N'2023-09-16' AS Date), NULL)
INSERT [dbo].[Места_В_Камерах] ([ID_Места], [ID_Камеры], [ID_Умершего], [Дата_Размещения], [Дата_Извлечения]) VALUES (9, 9, 9, CAST(N'2023-09-18' AS Date), CAST(N'2023-09-20' AS Date))
INSERT [dbo].[Места_В_Камерах] ([ID_Места], [ID_Камеры], [ID_Умершего], [Дата_Размещения], [Дата_Извлечения]) VALUES (10, 10, 10, CAST(N'2023-09-20' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Места_В_Камерах] OFF
GO
SET IDENTITY_INSERT [dbo].[Образцы] ON 

INSERT [dbo].[Образцы] ([ID_Образца], [ID_Умершего], [Тип_Образца], [Дата_Взятия], [Условия_Хранения], [ID_Ответственного]) VALUES (1, 1, N'Ткань', CAST(N'2023-09-02' AS Date), N'-20°C', 1)
INSERT [dbo].[Образцы] ([ID_Образца], [ID_Умершего], [Тип_Образца], [Дата_Взятия], [Условия_Хранения], [ID_Ответственного]) VALUES (2, 2, N'Кровь', CAST(N'2023-09-03' AS Date), N'+4°C', 2)
INSERT [dbo].[Образцы] ([ID_Образца], [ID_Умершего], [Тип_Образца], [Дата_Взятия], [Условия_Хранения], [ID_Ответственного]) VALUES (3, 3, N'Ткань', CAST(N'2023-09-04' AS Date), N'-80°C', 3)
INSERT [dbo].[Образцы] ([ID_Образца], [ID_Умершего], [Тип_Образца], [Дата_Взятия], [Условия_Хранения], [ID_Ответственного]) VALUES (4, 4, N'Кровь', CAST(N'2023-09-05' AS Date), N'+4°C', 1)
INSERT [dbo].[Образцы] ([ID_Образца], [ID_Умершего], [Тип_Образца], [Дата_Взятия], [Условия_Хранения], [ID_Ответственного]) VALUES (5, 5, N'Ткань', CAST(N'2023-09-06' AS Date), N'-20°C', 2)
INSERT [dbo].[Образцы] ([ID_Образца], [ID_Умершего], [Тип_Образца], [Дата_Взятия], [Условия_Хранения], [ID_Ответственного]) VALUES (6, 6, N'Кровь', CAST(N'2023-09-07' AS Date), N'+4°C', 3)
INSERT [dbo].[Образцы] ([ID_Образца], [ID_Умершего], [Тип_Образца], [Дата_Взятия], [Условия_Хранения], [ID_Ответственного]) VALUES (7, 7, N'Ткань', CAST(N'2023-09-08' AS Date), N'-80°C', 1)
INSERT [dbo].[Образцы] ([ID_Образца], [ID_Умершего], [Тип_Образца], [Дата_Взятия], [Условия_Хранения], [ID_Ответственного]) VALUES (8, 8, N'Кровь', CAST(N'2023-09-09' AS Date), N'+4°C', 2)
INSERT [dbo].[Образцы] ([ID_Образца], [ID_Умершего], [Тип_Образца], [Дата_Взятия], [Условия_Хранения], [ID_Ответственного]) VALUES (9, 9, N'Ткань', CAST(N'2023-09-10' AS Date), N'-20°C', 3)
INSERT [dbo].[Образцы] ([ID_Образца], [ID_Умершего], [Тип_Образца], [Дата_Взятия], [Условия_Хранения], [ID_Ответственного]) VALUES (10, 10, N'Кровь', CAST(N'2023-09-11' AS Date), N'+4°C', 1)
SET IDENTITY_INSERT [dbo].[Образцы] OFF
GO
SET IDENTITY_INSERT [dbo].[Сотрудники] ON 

INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (1, N'admin', N'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', N'Иванов Иван Иванович', N'Администратор', N'+79001234567', N'admin@example.com')
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (2, N'pathologist1', N'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', N'Петров Петр Сергеевич', N'Патологоанатом', N'+79001234568', N'petrov@example.com')
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (3, N'lab_technician1', N'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', N'Сидорова Мария Александровна', N'Лаборант', N'+79001234569', NULL)
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (4, N'manager1', N'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', N'Кузнецов Андрей Владимирович', N'Руководство', N'+79001234570', N'kuznetsov@example.com')
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (5, N'pathologist2', N'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', N'Михайлова Елена Дмитриевна', N'Патологоанатом', N'+79001234571', N'mikhailova@example.com')
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (6, N'lab_technician2', N'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', N'Федоров Сергей Николаевич', N'Лаборант', N'+79001234572', N'fedorov@example.com')
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (7, N'manager2', N'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', N'Николаева Анна Викторовна', N'Руководство', N'+79001234573', NULL)
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (8, N'pathologist3', N'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', N'Ковалев Дмитрий Петрович', N'Патологоанатом', N'+79001234574', N'kovalev@example.com')
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (9, N'lab_technician3', N'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', N'Смирнова Ольга Игоревна', N'Лаборант', N'+79001234575', N'smirnova@example.com')
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (10, N'admin2', N'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', N'Морозов Иван Александрович', N'Администратор', N'+79001234576', N'morozov@example.com')
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (1021, N'head_admin', N'oVfKc3wGdgNYZr2i9BHOLDbT+2BWIzNueFUhfO7usrQ=', N'Топазов Артём Григорьевич', N'Администратор', N'+79804368641', N'efrem3839@gmail.com')
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (1022, N'general_manager', N'UuA4LzcpmVNeKJ2pbiUGANFqKIAq86WQTbFwCsmhoj0=', N'Бурцев Никифор Аркадьевич', N'Руководство', N'+79733088076', N'nikifor11121984@mail.ru')
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (1023, N'deputy_head', N'ZPQfV/Gcpaa8EWUOfxkpO1ivg3JfbOQtp0EMyjV1S/g=', N'Цекало Роман Никитьевич', N'Руководство', N'+79254473867', N'roman18111961@hotmail.com')
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (1024, N'head_pathologist', N'dv8U7QKPPCCPkviQOUMNRSJJeYAe46R6w8tY0+fxhsc=', N'Саян Никифор Ефремович', N'Патологоанатом', N'+79506656822', N'nikifor14@outlook.com')
INSERT [dbo].[Сотрудники] ([ID_Сотрудника], [Логин], [ПарольHash], [ФИО], [Должность], [КонтактныйТелефон], [Email]) VALUES (1025, N'head_assistant', N'XWFOHeuQAza1ZlzM+F0fRwSuB5W7uLJE6cPIfynuHQw=', N'Шурыгина Афанасия Григорьевна', N'Лаборант', N'+79881479931', N'afanasiya23031960@ya.ru')
SET IDENTITY_INSERT [dbo].[Сотрудники] OFF
GO
SET IDENTITY_INSERT [dbo].[Способ_Оплаты] ON 

INSERT [dbo].[Способ_Оплаты] ([ID_Способа], [Наименование]) VALUES (1, N'Наличные')
INSERT [dbo].[Способ_Оплаты] ([ID_Способа], [Наименование]) VALUES (2, N'Безналичный расчет')
INSERT [dbo].[Способ_Оплаты] ([ID_Способа], [Наименование]) VALUES (3, N'Кредитная карта')
INSERT [dbo].[Способ_Оплаты] ([ID_Способа], [Наименование]) VALUES (4, N'Электронный кошелек')
INSERT [dbo].[Способ_Оплаты] ([ID_Способа], [Наименование]) VALUES (5, N'Банковский перевод')
SET IDENTITY_INSERT [dbo].[Способ_Оплаты] OFF
GO
SET IDENTITY_INSERT [dbo].[Транспортировка] ON 

INSERT [dbo].[Транспортировка] ([ID_Транспортировки], [ID_Умершего], [Тип_Перемещения], [Дата_Время], [Место_Отправления], [Место_Назначения], [ID_Ответственного]) VALUES (1, 1, N'Поступление', CAST(N'2023-02-09T08:00:00.000' AS DateTime), N'Городская больница №1', N'Камера хранения №1', 1)
INSERT [dbo].[Транспортировка] ([ID_Транспортировки], [ID_Умершего], [Тип_Перемещения], [Дата_Время], [Место_Отправления], [Место_Назначения], [ID_Ответственного]) VALUES (2, 2, N'Внутреннее', CAST(N'2023-03-09T09:00:00.000' AS DateTime), N'Камера хранения №1', N'Лаборатория', 2)
INSERT [dbo].[Транспортировка] ([ID_Транспортировки], [ID_Умершего], [Тип_Перемещения], [Дата_Время], [Место_Отправления], [Место_Назначения], [ID_Ответственного]) VALUES (3, 3, N'Выдача', CAST(N'2023-04-09T10:00:00.000' AS DateTime), N'Камера хранения №2', N'Родственники', 3)
INSERT [dbo].[Транспортировка] ([ID_Транспортировки], [ID_Умершего], [Тип_Перемещения], [Дата_Время], [Место_Отправления], [Место_Назначения], [ID_Ответственного]) VALUES (4, 4, N'Поступление', CAST(N'2023-05-09T08:30:00.000' AS DateTime), N'Автокатастрофа', N'Камера хранения №3', 1)
INSERT [dbo].[Транспортировка] ([ID_Транспортировки], [ID_Умершего], [Тип_Перемещения], [Дата_Время], [Место_Отправления], [Место_Назначения], [ID_Ответственного]) VALUES (5, 5, N'Внутреннее', CAST(N'2023-06-09T09:30:00.000' AS DateTime), N'Камера хранения №3', N'Лаборатория', 2)
INSERT [dbo].[Транспортировка] ([ID_Транспортировки], [ID_Умершего], [Тип_Перемещения], [Дата_Время], [Место_Отправления], [Место_Назначения], [ID_Ответственного]) VALUES (6, 6, N'Выдача', CAST(N'2023-07-09T10:30:00.000' AS DateTime), N'Камера хранения №4', N'Родственники', 3)
INSERT [dbo].[Транспортировка] ([ID_Транспортировки], [ID_Умершего], [Тип_Перемещения], [Дата_Время], [Место_Отправления], [Место_Назначения], [ID_Ответственного]) VALUES (7, 7, N'Поступление', CAST(N'2023-08-09T08:15:00.000' AS DateTime), N'Домашний адрес', N'Камера хранения №5', 1)
INSERT [dbo].[Транспортировка] ([ID_Транспортировки], [ID_Умершего], [Тип_Перемещения], [Дата_Время], [Место_Отправления], [Место_Назначения], [ID_Ответственного]) VALUES (8, 8, N'Внутреннее', CAST(N'2023-09-09T09:15:00.000' AS DateTime), N'Камера хранения №5', N'Лаборатория', 2)
INSERT [dbo].[Транспортировка] ([ID_Транспортировки], [ID_Умершего], [Тип_Перемещения], [Дата_Время], [Место_Отправления], [Место_Назначения], [ID_Ответственного]) VALUES (9, 9, N'Выдача', CAST(N'2023-10-09T10:15:00.000' AS DateTime), N'Камера хранения №6', N'Родственники', 3)
INSERT [dbo].[Транспортировка] ([ID_Транспортировки], [ID_Умершего], [Тип_Перемещения], [Дата_Время], [Место_Отправления], [Место_Назначения], [ID_Ответственного]) VALUES (10, 10, N'Поступление', CAST(N'2023-11-09T08:45:00.000' AS DateTime), N'Городская больница №4', N'Камера хранения №7', 1)
SET IDENTITY_INSERT [dbo].[Транспортировка] OFF
GO
SET IDENTITY_INSERT [dbo].[Умершие] ON 

INSERT [dbo].[Умершие] ([ID_Умершего], [ФИО], [Дата_Смерти], [Место_Смерти], [Причина_Смерти], [Дата_Поступления]) VALUES (1, N'Иванов Иван Иванович', CAST(N'2023-09-01' AS Date), N'Городская больница №1', N'Инсульт', CAST(N'2023-09-02' AS Date))
INSERT [dbo].[Умершие] ([ID_Умершего], [ФИО], [Дата_Смерти], [Место_Смерти], [Причина_Смерти], [Дата_Поступления]) VALUES (2, N'Петрова Мария Сергеевна', CAST(N'2023-09-03' AS Date), N'Домашний адрес', N'Инфаркт', CAST(N'2023-09-04' AS Date))
INSERT [dbo].[Умершие] ([ID_Умершего], [ФИО], [Дата_Смерти], [Место_Смерти], [Причина_Смерти], [Дата_Поступления]) VALUES (3, N'Сидоров Алексей Петрович', CAST(N'2023-09-05' AS Date), N'Городская больница №2', N'Онкология', CAST(N'2023-09-06' AS Date))
INSERT [dbo].[Умершие] ([ID_Умершего], [ФИО], [Дата_Смерти], [Место_Смерти], [Причина_Смерти], [Дата_Поступления]) VALUES (4, N'Кузнецова Елена Дмитриевна', CAST(N'2023-09-07' AS Date), N'Автокатастрофа', N'Травмы, несовместимые с жизнью', CAST(N'2023-09-08' AS Date))
INSERT [dbo].[Умершие] ([ID_Умершего], [ФИО], [Дата_Смерти], [Место_Смерти], [Причина_Смерти], [Дата_Поступления]) VALUES (5, N'Михайлов Дмитрий Андреевич', CAST(N'2023-09-09' AS Date), N'Дом престарелых', N'Естественные причины', CAST(N'2023-09-10' AS Date))
INSERT [dbo].[Умершие] ([ID_Умершего], [ФИО], [Дата_Смерти], [Место_Смерти], [Причина_Смерти], [Дата_Поступления]) VALUES (6, N'Федорова Анна Сергеевна', CAST(N'2023-09-11' AS Date), N'Городская больница №3', N'Сепсис', CAST(N'2023-09-12' AS Date))
INSERT [dbo].[Умершие] ([ID_Умершего], [ФИО], [Дата_Смерти], [Место_Смерти], [Причина_Смерти], [Дата_Поступления]) VALUES (7, N'Николаев Игорь Викторович', CAST(N'2023-09-13' AS Date), N'Домашний адрес', N'Отравление', CAST(N'2023-09-14' AS Date))
INSERT [dbo].[Умершие] ([ID_Умершего], [ФИО], [Дата_Смерти], [Место_Смерти], [Причина_Смерти], [Дата_Поступления]) VALUES (8, N'Ковалева Ольга Николаевна', CAST(N'2023-09-15' AS Date), N'Автокатастрофа', N'Травмы, несовместимые с жизнью', CAST(N'2023-09-16' AS Date))
INSERT [dbo].[Умершие] ([ID_Умершего], [ФИО], [Дата_Смерти], [Место_Смерти], [Причина_Смерти], [Дата_Поступления]) VALUES (9, N'Смирнов Владимир Петрович', CAST(N'2023-09-17' AS Date), N'Городская больница №4', N'Острая сердечная недостаточность', CAST(N'2023-09-18' AS Date))
INSERT [dbo].[Умершие] ([ID_Умершего], [ФИО], [Дата_Смерти], [Место_Смерти], [Причина_Смерти], [Дата_Поступления]) VALUES (10, N'Морозова Татьяна Александровна', CAST(N'2023-09-19' AS Date), N'Домашний адрес', N'Инсульт', CAST(N'2023-09-20' AS Date))
SET IDENTITY_INSERT [dbo].[Умершие] OFF
GO
SET IDENTITY_INSERT [dbo].[Услуги] ON 

INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (1, N'Гистологическое исследование', N'Анализ тканей под микроскопом', CAST(5000.00 AS Decimal(10, 2)), N'Стандартная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (2, N'Цитологическое исследование', N'Исследование клеток', CAST(3000.00 AS Decimal(10, 2)), N'Стандартная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (3, N'Молекулярное исследование', N'Анализ ДНК/РНК', CAST(10000.00 AS Decimal(10, 2)), N'Срочная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (4, N'Иммуногистохимическое исследование', N'Определение маркеров в тканях', CAST(8000.00 AS Decimal(10, 2)), N'Стандартная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (5, N'Биопсия', N'Забор образца ткани', CAST(2000.00 AS Decimal(10, 2)), N'Стандартная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (6, N'Экспресс-анализ', N'Срочный анализ биоматериала', CAST(12000.00 AS Decimal(10, 2)), N'Срочная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (7, N'Токсикологический анализ', N'Определение токсинов в организме', CAST(7000.00 AS Decimal(10, 2)), N'Стандартная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (8, N'Патоморфологическое исследование', N'Оценка структуры тканей', CAST(6000.00 AS Decimal(10, 2)), N'Стандартная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (9, N'Генетическое тестирование', N'Анализ генетических мутаций', CAST(15000.00 AS Decimal(10, 2)), N'Срочная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (10, N'Исследование на онкомаркеры', N'Определение раковых маркеров', CAST(9000.00 AS Decimal(10, 2)), N'Стандартная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (30, N'Новая', N'Новая', CAST(123456.00 AS Decimal(10, 2)), N'Стандартная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (31, N'Newest', N'newest', CAST(789456.00 AS Decimal(10, 2)), N'Стандартная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (32, N'Curios', N'Curios', CAST(202020.00 AS Decimal(10, 2)), N'Стандартная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (40, N'Ещё новаяфывфывфывфыв', N'Да опятьыфвфывфывфы', CAST(4500.00 AS Decimal(10, 2)), N'Срочная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (41, N'Curios', N'Curios', CAST(202020.00 AS Decimal(10, 2)), N'Стандартная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (42, N'Ещё одна новая', N'Та самая', CAST(777.00 AS Decimal(10, 2)), N'Срочная')
INSERT [dbo].[Услуги] ([ID_Услуги], [Наименование], [Описание], [Стоимость], [Тип]) VALUES (43, N'One more', N'More one', CAST(888.00 AS Decimal(10, 2)), N'Срочная')
SET IDENTITY_INSERT [dbo].[Услуги] OFF
GO
SET IDENTITY_INSERT [dbo].[Финансовые_Операции] ON 

INSERT [dbo].[Финансовые_Операции] ([ID_Операции], [ID_Заявки], [Сумма], [Тип], [Дата_Операции], [ID_Способа]) VALUES (3, 1, CAST(5000.00 AS Decimal(10, 2)), N'Оплата', CAST(N'2023-10-01' AS Date), 1)
INSERT [dbo].[Финансовые_Операции] ([ID_Операции], [ID_Заявки], [Сумма], [Тип], [Дата_Операции], [ID_Способа]) VALUES (4, 2, CAST(3000.00 AS Decimal(10, 2)), N'Оплата', CAST(N'2023-10-02' AS Date), 2)
INSERT [dbo].[Финансовые_Операции] ([ID_Операции], [ID_Заявки], [Сумма], [Тип], [Дата_Операции], [ID_Способа]) VALUES (5, 3, CAST(10000.00 AS Decimal(10, 2)), N'Оплата', CAST(N'2023-10-03' AS Date), 3)
INSERT [dbo].[Финансовые_Операции] ([ID_Операции], [ID_Заявки], [Сумма], [Тип], [Дата_Операции], [ID_Способа]) VALUES (6, 4, CAST(8000.00 AS Decimal(10, 2)), N'Возврат', CAST(N'2023-10-04' AS Date), 4)
INSERT [dbo].[Финансовые_Операции] ([ID_Операции], [ID_Заявки], [Сумма], [Тип], [Дата_Операции], [ID_Способа]) VALUES (7, 5, CAST(2000.00 AS Decimal(10, 2)), N'Оплата', CAST(N'2023-10-05' AS Date), 5)
SET IDENTITY_INSERT [dbo].[Финансовые_Операции] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Сотрудни__BC2217D30B65ACD9]    Script Date: 10.04.2025 23:00:21 ******/
ALTER TABLE [dbo].[Сотрудники] ADD  CONSTRAINT [UQ__Сотрудни__BC2217D30B65ACD9] UNIQUE NONCLUSTERED 
(
	[Логин] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Журнал_Обращений]  WITH CHECK ADD  CONSTRAINT [FK_Журнал_Обращений_Сотрудники] FOREIGN KEY([ID_Ответственного])
REFERENCES [dbo].[Сотрудники] ([ID_Сотрудника])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Журнал_Обращений] CHECK CONSTRAINT [FK_Журнал_Обращений_Сотрудники]
GO
ALTER TABLE [dbo].[Журнал_Температур]  WITH CHECK ADD  CONSTRAINT [FK_Журнал_Температур_Камеры_Хранения] FOREIGN KEY([ID_Камеры])
REFERENCES [dbo].[Камеры_Хранения] ([ID_Камеры])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Журнал_Температур] CHECK CONSTRAINT [FK_Журнал_Температур_Камеры_Хранения]
GO
ALTER TABLE [dbo].[Журнал_Температур]  WITH CHECK ADD  CONSTRAINT [FK_Журнал_Температур_Сотрудники] FOREIGN KEY([ID_Ответственного])
REFERENCES [dbo].[Сотрудники] ([ID_Сотрудника])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Журнал_Температур] CHECK CONSTRAINT [FK_Журнал_Температур_Сотрудники]
GO
ALTER TABLE [dbo].[Заявки_на_Платные_Услуги]  WITH CHECK ADD  CONSTRAINT [FK_Заявки_на_Платные_Услуги_Сотрудники] FOREIGN KEY([ID_Ответственного])
REFERENCES [dbo].[Сотрудники] ([ID_Сотрудника])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Заявки_на_Платные_Услуги] CHECK CONSTRAINT [FK_Заявки_на_Платные_Услуги_Сотрудники]
GO
ALTER TABLE [dbo].[Заявки_на_Платные_Услуги]  WITH CHECK ADD  CONSTRAINT [FK_Заявки_на_Платные_Услуги_Услуги] FOREIGN KEY([ID_Услуги])
REFERENCES [dbo].[Услуги] ([ID_Услуги])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Заявки_на_Платные_Услуги] CHECK CONSTRAINT [FK_Заявки_на_Платные_Услуги_Услуги]
GO
ALTER TABLE [dbo].[Использование_Инвентаря]  WITH CHECK ADD  CONSTRAINT [FK_Использование_Инвентаря_Инвентарь] FOREIGN KEY([ID_Инвентаря])
REFERENCES [dbo].[Инвентарь] ([ID_Инвентаря])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Использование_Инвентаря] CHECK CONSTRAINT [FK_Использование_Инвентаря_Инвентарь]
GO
ALTER TABLE [dbo].[Использование_Инвентаря]  WITH CHECK ADD  CONSTRAINT [FK_Использование_Инвентаря_Исследования] FOREIGN KEY([ID_Исследования])
REFERENCES [dbo].[Исследования] ([ID_Исследования])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Использование_Инвентаря] CHECK CONSTRAINT [FK_Использование_Инвентаря_Исследования]
GO
ALTER TABLE [dbo].[Использование_Инвентаря]  WITH CHECK ADD  CONSTRAINT [FK_Использование_Инвентаря_Сотрудники] FOREIGN KEY([ID_Ответственного])
REFERENCES [dbo].[Сотрудники] ([ID_Сотрудника])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Использование_Инвентаря] CHECK CONSTRAINT [FK_Использование_Инвентаря_Сотрудники]
GO
ALTER TABLE [dbo].[Использование_Образцов]  WITH CHECK ADD  CONSTRAINT [FK_Использование_Образцов_Исследования] FOREIGN KEY([ID_Исследования])
REFERENCES [dbo].[Исследования] ([ID_Исследования])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Использование_Образцов] CHECK CONSTRAINT [FK_Использование_Образцов_Исследования]
GO
ALTER TABLE [dbo].[Использование_Образцов]  WITH CHECK ADD  CONSTRAINT [FK_Использование_Образцов_Образцы] FOREIGN KEY([ID_Образца])
REFERENCES [dbo].[Образцы] ([ID_Образца])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Использование_Образцов] CHECK CONSTRAINT [FK_Использование_Образцов_Образцы]
GO
ALTER TABLE [dbo].[Использование_Образцов]  WITH CHECK ADD  CONSTRAINT [FK_Использование_Образцов_Сотрудники] FOREIGN KEY([ID_Ответственного])
REFERENCES [dbo].[Сотрудники] ([ID_Сотрудника])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Использование_Образцов] CHECK CONSTRAINT [FK_Использование_Образцов_Сотрудники]
GO
ALTER TABLE [dbo].[Исследования]  WITH CHECK ADD  CONSTRAINT [FK_Исследования_Сотрудники] FOREIGN KEY([ID_Исполнителя])
REFERENCES [dbo].[Сотрудники] ([ID_Сотрудника])
GO
ALTER TABLE [dbo].[Исследования] CHECK CONSTRAINT [FK_Исследования_Сотрудники]
GO
ALTER TABLE [dbo].[Исследования]  WITH CHECK ADD  CONSTRAINT [FK_Исследования_Умершие] FOREIGN KEY([ID_Умершего])
REFERENCES [dbo].[Умершие] ([ID_Умершего])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Исследования] CHECK CONSTRAINT [FK_Исследования_Умершие]
GO
ALTER TABLE [dbo].[Места_В_Камерах]  WITH CHECK ADD  CONSTRAINT [FK_Места_В_Камерах_Камеры_Хранения] FOREIGN KEY([ID_Камеры])
REFERENCES [dbo].[Камеры_Хранения] ([ID_Камеры])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Места_В_Камерах] CHECK CONSTRAINT [FK_Места_В_Камерах_Камеры_Хранения]
GO
ALTER TABLE [dbo].[Места_В_Камерах]  WITH CHECK ADD  CONSTRAINT [FK_Места_В_Камерах_Умершие] FOREIGN KEY([ID_Умершего])
REFERENCES [dbo].[Умершие] ([ID_Умершего])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Места_В_Камерах] CHECK CONSTRAINT [FK_Места_В_Камерах_Умершие]
GO
ALTER TABLE [dbo].[Образцы]  WITH CHECK ADD  CONSTRAINT [FK_Образцы_Сотрудники] FOREIGN KEY([ID_Ответственного])
REFERENCES [dbo].[Сотрудники] ([ID_Сотрудника])
GO
ALTER TABLE [dbo].[Образцы] CHECK CONSTRAINT [FK_Образцы_Сотрудники]
GO
ALTER TABLE [dbo].[Образцы]  WITH CHECK ADD  CONSTRAINT [FK_Образцы_Умершие] FOREIGN KEY([ID_Умершего])
REFERENCES [dbo].[Умершие] ([ID_Умершего])
GO
ALTER TABLE [dbo].[Образцы] CHECK CONSTRAINT [FK_Образцы_Умершие]
GO
ALTER TABLE [dbo].[Платные_Исследования]  WITH CHECK ADD  CONSTRAINT [FK_Платные_Исследования_Заявки_на_Платные_Услуги] FOREIGN KEY([ID_Заявки])
REFERENCES [dbo].[Заявки_на_Платные_Услуги] ([ID_Заявки])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Платные_Исследования] CHECK CONSTRAINT [FK_Платные_Исследования_Заявки_на_Платные_Услуги]
GO
ALTER TABLE [dbo].[Платные_Исследования]  WITH CHECK ADD  CONSTRAINT [FK_Платные_Исследования_Сотрудники] FOREIGN KEY([ID_Исполнителя])
REFERENCES [dbo].[Сотрудники] ([ID_Сотрудника])
GO
ALTER TABLE [dbo].[Платные_Исследования] CHECK CONSTRAINT [FK_Платные_Исследования_Сотрудники]
GO
ALTER TABLE [dbo].[Транспортировка]  WITH CHECK ADD  CONSTRAINT [FK_Транспортировка_Сотрудники] FOREIGN KEY([ID_Ответственного])
REFERENCES [dbo].[Сотрудники] ([ID_Сотрудника])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Транспортировка] CHECK CONSTRAINT [FK_Транспортировка_Сотрудники]
GO
ALTER TABLE [dbo].[Транспортировка]  WITH CHECK ADD  CONSTRAINT [FK_Транспортировка_Умершие] FOREIGN KEY([ID_Умершего])
REFERENCES [dbo].[Умершие] ([ID_Умершего])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Транспортировка] CHECK CONSTRAINT [FK_Транспортировка_Умершие]
GO
ALTER TABLE [dbo].[Финансовые_Операции]  WITH CHECK ADD  CONSTRAINT [FK_Финансовые_Операции_Заявки] FOREIGN KEY([ID_Заявки])
REFERENCES [dbo].[Заявки_на_Платные_Услуги] ([ID_Заявки])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Финансовые_Операции] CHECK CONSTRAINT [FK_Финансовые_Операции_Заявки]
GO
ALTER TABLE [dbo].[Финансовые_Операции]  WITH CHECK ADD  CONSTRAINT [FK_Финансовые_Операции_Способ_Оплаты] FOREIGN KEY([ID_Способа])
REFERENCES [dbo].[Способ_Оплаты] ([ID_Способа])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Финансовые_Операции] CHECK CONSTRAINT [FK_Финансовые_Операции_Способ_Оплаты]
GO
ALTER TABLE [dbo].[Журнал_Обращений]  WITH CHECK ADD  CONSTRAINT [CK__Журнал_Об__Тип_О__6D0D32F4] CHECK  (([Тип_Обращения]='Жалоба' OR [Тип_Обращения]='Обращение'))
GO
ALTER TABLE [dbo].[Журнал_Обращений] CHECK CONSTRAINT [CK__Журнал_Об__Тип_О__6D0D32F4]
GO
ALTER TABLE [dbo].[Заявки_на_Платные_Услуги]  WITH CHECK ADD  CONSTRAINT [CK__Заявки_на__Стату__412EB0B6] CHECK  (([Статус]='Завершена' OR [Статус]='В работе' OR [Статус]='Новая'))
GO
ALTER TABLE [dbo].[Заявки_на_Платные_Услуги] CHECK CONSTRAINT [CK__Заявки_на__Стату__412EB0B6]
GO
ALTER TABLE [dbo].[Инвентарь]  WITH CHECK ADD  CONSTRAINT [CK__Инвентарь__Колич__6477ECF3] CHECK  (([Количество]>=(0)))
GO
ALTER TABLE [dbo].[Инвентарь] CHECK CONSTRAINT [CK__Инвентарь__Колич__6477ECF3]
GO
ALTER TABLE [dbo].[Использование_Инвентаря]  WITH CHECK ADD  CONSTRAINT [CK__Использов__Колич__693CA210] CHECK  (([КоличествоИспользовано]>=(0)))
GO
ALTER TABLE [dbo].[Использование_Инвентаря] CHECK CONSTRAINT [CK__Использов__Колич__693CA210]
GO
ALTER TABLE [dbo].[Использование_Образцов]  WITH CHECK ADD  CONSTRAINT [CK__Использов__Колич__60A75C0F] CHECK  (([Количество_Использовано]>=(0)))
GO
ALTER TABLE [dbo].[Использование_Образцов] CHECK CONSTRAINT [CK__Использов__Колич__60A75C0F]
GO
ALTER TABLE [dbo].[Исследования]  WITH CHECK ADD  CONSTRAINT [CK__Исследова__Тип_И__5629CD9C] CHECK  (([Тип_Исследования]='Иммуногистохимическое' OR [Тип_Исследования]='Молекулярное' OR [Тип_Исследования]='Цитологическое' OR [Тип_Исследования]='Гистологическое'))
GO
ALTER TABLE [dbo].[Исследования] CHECK CONSTRAINT [CK__Исследова__Тип_И__5629CD9C]
GO
ALTER TABLE [dbo].[Камеры_Хранения]  WITH CHECK ADD  CONSTRAINT [CK__Камеры_Хр__Вмест__4AB81AF0] CHECK  (([Вместимость]>(0)))
GO
ALTER TABLE [dbo].[Камеры_Хранения] CHECK CONSTRAINT [CK__Камеры_Хр__Вмест__4AB81AF0]
GO
ALTER TABLE [dbo].[Образцы]  WITH CHECK ADD  CONSTRAINT [CK__Образцы__Тип_Обр__5AEE82B9] CHECK  (([Тип_Образца]='Другое' OR [Тип_Образца]='Кровь' OR [Тип_Образца]='Ткань'))
GO
ALTER TABLE [dbo].[Образцы] CHECK CONSTRAINT [CK__Образцы__Тип_Обр__5AEE82B9]
GO
ALTER TABLE [dbo].[Транспортировка]  WITH CHECK ADD  CONSTRAINT [CK__Транспорт__Тип_П__71D1E811] CHECK  (([Тип_Перемещения]='Выдача' OR [Тип_Перемещения]='Внутреннее' OR [Тип_Перемещения]='Поступление'))
GO
ALTER TABLE [dbo].[Транспортировка] CHECK CONSTRAINT [CK__Транспорт__Тип_П__71D1E811]
GO
ALTER TABLE [dbo].[Услуги]  WITH CHECK ADD  CONSTRAINT [CK__Услуги__Стоимост__3C69FB99] CHECK  (([Стоимость]>=(0)))
GO
ALTER TABLE [dbo].[Услуги] CHECK CONSTRAINT [CK__Услуги__Стоимост__3C69FB99]
GO
ALTER TABLE [dbo].[Услуги]  WITH CHECK ADD  CONSTRAINT [CK__Услуги__Тип__3D5E1FD2] CHECK  (([Тип]='Срочная' OR [Тип]='Стандартная'))
GO
ALTER TABLE [dbo].[Услуги] CHECK CONSTRAINT [CK__Услуги__Тип__3D5E1FD2]
GO
ALTER TABLE [dbo].[Финансовые_Операции]  WITH CHECK ADD  CONSTRAINT [CK__Финансовы__Сумма__75A278F5] CHECK  (([Сумма]>=(0)))
GO
ALTER TABLE [dbo].[Финансовые_Операции] CHECK CONSTRAINT [CK__Финансовы__Сумма__75A278F5]
GO
ALTER TABLE [dbo].[Финансовые_Операции]  WITH CHECK ADD  CONSTRAINT [CK__Финансовые___Тип__76969D2E] CHECK  (([Тип]='Возврат' OR [Тип]='Оплата'))
GO
ALTER TABLE [dbo].[Финансовые_Операции] CHECK CONSTRAINT [CK__Финансовые___Тип__76969D2E]
GO
/****** Object:  StoredProcedure [dbo].[AddInventory]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[AddInventory]
    @Наименование NVARCHAR(255),
    @Количество DECIMAL(10, 2),
    @Единица_Измерения NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ID_Инвентаря INT;

    -- Проверяем, существует ли уже такой инвентарь
    SELECT @ID_Инвентаря = ID_Инвентаря
    FROM Инвентарь
    WHERE Наименование = @Наименование AND Единица_Измерения = @Единица_Измерения;

    IF @ID_Инвентаря IS NOT NULL
    BEGIN
        -- Если инвентарь уже существует, увеличиваем его количество
        UPDATE Инвентарь
        SET Количество = Количество + @Количество
        WHERE ID_Инвентаря = @ID_Инвентаря;
    END
    ELSE
    BEGIN
        -- Если инвентарь новый, добавляем новую запись
        INSERT INTO Инвентарь (Наименование, Количество, Единица_Измерения)
        VALUES (@Наименование, @Количество, @Единица_Измерения);

        -- Получаем ID только что добавленного инвентаря
        SET @ID_Инвентаря = SCOPE_IDENTITY();
    END

    -- Возвращаем ID обновленного или добавленного инвентаря
    SELECT @ID_Инвентаря AS ID_Инвентаря;
END;


GO
/****** Object:  Trigger [dbo].[trg_DecreaseInventory]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_DecreaseInventory]
ON [dbo].[Использование_Инвентаря]
AFTER INSERT
AS
BEGIN
    -- Уменьшаем количество инвентаря на основе вставленной записи
    UPDATE Инвентарь
    SET Количество = Количество - i.КоличествоИспользовано
    FROM Инвентарь inv
    INNER JOIN inserted i ON inv.ID_Инвентаря = i.ID_Инвентаря;

    -- Проверка на отрицательное количество (опционально)
    IF EXISTS (SELECT 1 FROM Инвентарь WHERE Количество < 0)
    BEGIN
        RAISERROR ('Ошибка: Количество инвентаря не может быть отрицательным.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;


GO
ALTER TABLE [dbo].[Использование_Инвентаря] ENABLE TRIGGER [trg_DecreaseInventory]
GO
/****** Object:  Trigger [dbo].[trg_DeletePaidResearchEmployee]    Script Date: 10.04.2025 23:00:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Триггер для Платные_Исследования
CREATE TRIGGER [dbo].[trg_DeletePaidResearchEmployee]
ON [dbo].[Сотрудники]
FOR DELETE
AS
BEGIN
    -- Удаление связанных записей в таблице Платные_Исследования
    DELETE FROM [dbo].[Платные_Исследования]
    WHERE ID_Исполнителя IN (SELECT ID_Сотрудника FROM deleted)
END
GO
ALTER TABLE [dbo].[Сотрудники] ENABLE TRIGGER [trg_DeletePaidResearchEmployee]
GO
/****** Object:  Trigger [dbo].[trg_DeleteResearchEmployee]    Script Date: 10.04.2025 23:00:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Триггер для Исследования
CREATE TRIGGER [dbo].[trg_DeleteResearchEmployee]
ON [dbo].[Сотрудники]
FOR DELETE
AS
BEGIN
    -- Удаление связанных записей в таблице Исследования
    DELETE FROM [dbo].[Исследования]
    WHERE ID_Исполнителя IN (SELECT ID_Сотрудника FROM deleted)
END
GO
ALTER TABLE [dbo].[Сотрудники] ENABLE TRIGGER [trg_DeleteResearchEmployee]
GO
/****** Object:  Trigger [dbo].[trg_DeleteSampleEmployee]    Script Date: 10.04.2025 23:00:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Триггер для Образцы
CREATE TRIGGER [dbo].[trg_DeleteSampleEmployee]
ON [dbo].[Сотрудники]
FOR DELETE
AS
BEGIN
    -- Удаление связанных записей в таблице Образцы
    DELETE FROM [dbo].[Образцы]
    WHERE ID_Ответственного IN (SELECT ID_Сотрудника FROM deleted)
END
GO
ALTER TABLE [dbo].[Сотрудники] ENABLE TRIGGER [trg_DeleteSampleEmployee]
GO
/****** Object:  Trigger [dbo].[trg_DeleteUmershiy]    Script Date: 10.04.2025 23:00:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Создаем триггер для реализации каскадного удаления
CREATE TRIGGER [dbo].[trg_DeleteUmershiy]
ON [dbo].[Умершие]
FOR DELETE
AS
BEGIN
    -- Удаляем связанные записи в таблице Образцы
    DELETE FROM [dbo].[Образцы]
    WHERE ID_Умершего IN (SELECT ID_Умершего FROM deleted)
END
GO
ALTER TABLE [dbo].[Умершие] ENABLE TRIGGER [trg_DeleteUmershiy]
GO
/****** Object:  Trigger [dbo].[trg_АвтоЗаполнение_Суммы]    Script Date: 10.04.2025 23:00:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_АвтоЗаполнение_Суммы]
ON [dbo].[Финансовые_Операции]
AFTER INSERT
AS
BEGIN
    -- Обновляем поле "Сумма" в таблице "Финансовые_Операции"
    UPDATE ФО
    SET ФО.Сумма = У.Стоимость
    FROM Финансовые_Операции AS ФО
    INNER JOIN inserted AS i ON ФО.ID_Заявки = i.ID_Заявки
    INNER JOIN Заявки_на_Платные_Услуги AS ЗПУ ON i.ID_Заявки = ЗПУ.ID_Заявки
    INNER JOIN Услуги AS У ON ЗПУ.ID_Услуги = У.ID_Услуги;
END;



GO
ALTER TABLE [dbo].[Финансовые_Операции] ENABLE TRIGGER [trg_АвтоЗаполнение_Суммы]
GO
USE [master]
GO
ALTER DATABASE [BDA_pat_otd] SET  READ_WRITE 
GO
