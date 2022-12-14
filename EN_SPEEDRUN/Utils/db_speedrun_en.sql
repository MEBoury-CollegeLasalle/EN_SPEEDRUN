
USE [master];
DECLARE @kill varchar(8000) = '';  
SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'  
FROM sys.dm_exec_sessions
WHERE database_id  = db_id('db_speedrun_en')
EXEC(@kill);

USE [db_speedrun_en]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT IF EXISTS [FK_Users_Statuses]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT IF EXISTS [FK_Users_Clinics]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Patients]') AND type in (N'U'))
ALTER TABLE [dbo].[Patients] DROP CONSTRAINT IF EXISTS [FK_Patients_Statuses]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Doctors]') AND type in (N'U'))
ALTER TABLE [dbo].[Doctors] DROP CONSTRAINT IF EXISTS [FK_Doctors_Statuses]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clinics]') AND type in (N'U'))
ALTER TABLE [dbo].[Clinics] DROP CONSTRAINT IF EXISTS [FK_Clinics_Addresses]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClinicDoctors]') AND type in (N'U'))
ALTER TABLE [dbo].[ClinicDoctors] DROP CONSTRAINT IF EXISTS [FK_ClinicDoctors_Doctors]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClinicDoctors]') AND type in (N'U'))
ALTER TABLE [dbo].[ClinicDoctors] DROP CONSTRAINT IF EXISTS [FK_ClinicDoctors_Clinics]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Appointments]') AND type in (N'U'))
ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT IF EXISTS [FK_Appointments_Statuses]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Appointments]') AND type in (N'U'))
ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT IF EXISTS [FK_Appointments_Patients]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Appointments]') AND type in (N'U'))
ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT IF EXISTS [FK_Appointments_Doctors]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Appointments]') AND type in (N'U'))
ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT IF EXISTS [FK_Appointments_Clinics]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Appointments]') AND type in (N'U'))
ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT IF EXISTS [FK_Appointments_AppointmentTimes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT IF EXISTS [DF_Users_DateCreated]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Patients]') AND type in (N'U'))
ALTER TABLE [dbo].[Patients] DROP CONSTRAINT IF EXISTS [DF_Patients_DateCreated]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Doctors]') AND type in (N'U'))
ALTER TABLE [dbo].[Doctors] DROP CONSTRAINT IF EXISTS [DF_Doctors_DateCreated]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clinics]') AND type in (N'U'))
ALTER TABLE [dbo].[Clinics] DROP CONSTRAINT IF EXISTS [DF_Clinics_DateCreated]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Appointments]') AND type in (N'U'))
ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT IF EXISTS [DF_Appointments_DateCreated]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Addresses]') AND type in (N'U'))
ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT IF EXISTS [DF_Addresses_DateCreated]
GO
/****** Object:  Index [IX_ClinicDoctors]    Script Date: 12/2/2022 4:22:36 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClinicDoctors]') AND type in (N'U'))
ALTER TABLE [dbo].[ClinicDoctors] DROP CONSTRAINT IF EXISTS [IX_ClinicDoctors]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/2/2022 4:22:36 PM ******/
DROP TABLE IF EXISTS [dbo].[Users]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 12/2/2022 4:22:36 PM ******/
DROP TABLE IF EXISTS [dbo].[Statuses]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 12/2/2022 4:22:36 PM ******/
DROP TABLE IF EXISTS [dbo].[Patients]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 12/2/2022 4:22:36 PM ******/
DROP TABLE IF EXISTS [dbo].[Doctors]
GO
/****** Object:  Table [dbo].[Clinics]    Script Date: 12/2/2022 4:22:36 PM ******/
DROP TABLE IF EXISTS [dbo].[Clinics]
GO
/****** Object:  Table [dbo].[ClinicDoctors]    Script Date: 12/2/2022 4:22:36 PM ******/
DROP TABLE IF EXISTS [dbo].[ClinicDoctors]
GO
/****** Object:  Table [dbo].[AppointmentTimes]    Script Date: 12/2/2022 4:22:36 PM ******/
DROP TABLE IF EXISTS [dbo].[AppointmentTimes]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 12/2/2022 4:22:36 PM ******/
DROP TABLE IF EXISTS [dbo].[Appointments]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 12/2/2022 4:22:36 PM ******/
DROP TABLE IF EXISTS [dbo].[Addresses]
GO
USE [master]
GO
/****** Object:  Database [db_speedrun_en]    Script Date: 12/2/2022 4:22:36 PM ******/
DROP DATABASE IF EXISTS [db_speedrun_en]
GO
/****** Object:  Database [db_speedrun_en]    Script Date: 12/2/2022 4:22:36 PM ******/
CREATE DATABASE [db_speedrun_en]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_speedrun_en', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019EXPRESS\MSSQL\DATA\db_speedrun_en.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_speedrun_en_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019EXPRESS\MSSQL\DATA\db_speedrun_en_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_speedrun_en] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_speedrun_en].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_speedrun_en] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_speedrun_en] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_speedrun_en] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_speedrun_en] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_speedrun_en] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_speedrun_en] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_speedrun_en] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_speedrun_en] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_speedrun_en] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_speedrun_en] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_speedrun_en] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_speedrun_en] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_speedrun_en] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_speedrun_en] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_speedrun_en] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_speedrun_en] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_speedrun_en] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_speedrun_en] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_speedrun_en] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_speedrun_en] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_speedrun_en] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_speedrun_en] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_speedrun_en] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_speedrun_en] SET  MULTI_USER 
GO
ALTER DATABASE [db_speedrun_en] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_speedrun_en] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_speedrun_en] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_speedrun_en] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_speedrun_en] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_speedrun_en] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [db_speedrun_en] SET QUERY_STORE = OFF
GO
USE [db_speedrun_en]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 12/2/2022 4:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StreetNumber] [int] NOT NULL,
	[Street] [nvarchar](128) NOT NULL,
	[StreetExtension] [nvarchar](32) NULL,
	[City] [nvarchar](64) NOT NULL,
	[PostalCode] [nvarchar](16) NOT NULL,
	[Region] [nvarchar](64) NOT NULL,
	[Country] [nvarchar](64) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 12/2/2022 4:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[PatientId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[ClinicId] [int] NOT NULL,
	[AppointmentTimeId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppointmentTimes]    Script Date: 12/2/2022 4:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentTimes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Hours] [int] NOT NULL,
	[Minutes] [int] NOT NULL,
 CONSTRAINT [PK_AppointmentTimes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClinicDoctors]    Script Date: 12/2/2022 4:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClinicDoctors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DoctorId] [int] NOT NULL,
	[ClinicId] [int] NOT NULL,
 CONSTRAINT [PK_ClinicDoctors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clinics]    Script Date: 12/2/2022 4:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clinics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[AddressId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Clinics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 12/2/2022 4:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [int] NOT NULL,
	[FirstName] [nvarchar](48) NOT NULL,
	[LastName] [nvarchar](48) NOT NULL,
	[LicenseNo] [nvarchar](32) NOT NULL,
	[DateHired] [date] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 12/2/2022 4:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [int] NOT NULL,
	[FirstName] [nvarchar](48) NOT NULL,
	[LastName] [nvarchar](48) NOT NULL,
	[HealthCardNumber] [nvarchar](12) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 12/2/2022 4:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusCode] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/2/2022 4:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [int] NOT NULL,
	[ClinicId] [int] NOT NULL,
	[Username] [nvarchar](32) NOT NULL,
	[PasswordHash] [nvarchar](128) NOT NULL,
	[LastLogin] [datetime] NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([Id], [StreetNumber], [Street], [StreetExtension], [City], [PostalCode], [Region], [Country], [DateCreated]) VALUES (1, 555, N'De l''Hopital', NULL, N'Montreal', N'H0H 0H0', N'Quebec', N'Canada', CAST(N'2022-12-01T14:40:58.383' AS DateTime))
SET IDENTITY_INSERT [dbo].[Addresses] OFF
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([Id], [StatusId], [Date], [PatientId], [DoctorId], [ClinicId], [AppointmentTimeId], [DateCreated]) VALUES (2, 2, CAST(N'2022-12-01' AS Date), 1, 2, 1, 1, CAST(N'2022-12-01T14:49:04.007' AS DateTime))
INSERT [dbo].[Appointments] ([Id], [StatusId], [Date], [PatientId], [DoctorId], [ClinicId], [AppointmentTimeId], [DateCreated]) VALUES (3, 2, CAST(N'2022-12-02' AS Date), 1, 2, 1, 1, CAST(N'2022-12-01T14:49:22.397' AS DateTime))
INSERT [dbo].[Appointments] ([Id], [StatusId], [Date], [PatientId], [DoctorId], [ClinicId], [AppointmentTimeId], [DateCreated]) VALUES (4, 2, CAST(N'2022-12-04' AS Date), 1, 2, 1, 1, CAST(N'2022-12-01T14:49:36.590' AS DateTime))
INSERT [dbo].[Appointments] ([Id], [StatusId], [Date], [PatientId], [DoctorId], [ClinicId], [AppointmentTimeId], [DateCreated]) VALUES (5, 2, CAST(N'2022-12-06' AS Date), 1, 2, 1, 1, CAST(N'2022-12-01T14:49:53.470' AS DateTime))
INSERT [dbo].[Appointments] ([Id], [StatusId], [Date], [PatientId], [DoctorId], [ClinicId], [AppointmentTimeId], [DateCreated]) VALUES (6, 2, CAST(N'2022-12-03' AS Date), 2, 3, 1, 1, CAST(N'2022-12-01T14:50:09.720' AS DateTime))
INSERT [dbo].[Appointments] ([Id], [StatusId], [Date], [PatientId], [DoctorId], [ClinicId], [AppointmentTimeId], [DateCreated]) VALUES (7, 2, CAST(N'2022-12-05' AS Date), 2, 3, 1, 1, CAST(N'2022-12-01T14:50:22.923' AS DateTime))
INSERT [dbo].[Appointments] ([Id], [StatusId], [Date], [PatientId], [DoctorId], [ClinicId], [AppointmentTimeId], [DateCreated]) VALUES (8, 2, CAST(N'2022-12-07' AS Date), 2, 3, 1, 1, CAST(N'2022-12-01T14:50:42.407' AS DateTime))
INSERT [dbo].[Appointments] ([Id], [StatusId], [Date], [PatientId], [DoctorId], [ClinicId], [AppointmentTimeId], [DateCreated]) VALUES (10, 2, CAST(N'2022-12-08' AS Date), 2, 3, 1, 1, CAST(N'2022-12-01T14:51:00.173' AS DateTime))
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[AppointmentTimes] ON 

INSERT [dbo].[AppointmentTimes] ([Id], [Hours], [Minutes]) VALUES (1, 9, 0)
INSERT [dbo].[AppointmentTimes] ([Id], [Hours], [Minutes]) VALUES (2, 9, 15)
INSERT [dbo].[AppointmentTimes] ([Id], [Hours], [Minutes]) VALUES (3, 9, 30)
INSERT [dbo].[AppointmentTimes] ([Id], [Hours], [Minutes]) VALUES (4, 9, 45)
INSERT [dbo].[AppointmentTimes] ([Id], [Hours], [Minutes]) VALUES (5, 10, 0)
INSERT [dbo].[AppointmentTimes] ([Id], [Hours], [Minutes]) VALUES (6, 10, 15)
INSERT [dbo].[AppointmentTimes] ([Id], [Hours], [Minutes]) VALUES (7, 10, 30)
INSERT [dbo].[AppointmentTimes] ([Id], [Hours], [Minutes]) VALUES (8, 10, 45)
INSERT [dbo].[AppointmentTimes] ([Id], [Hours], [Minutes]) VALUES (9, 11, 0)
INSERT [dbo].[AppointmentTimes] ([Id], [Hours], [Minutes]) VALUES (10, 11, 15)
INSERT [dbo].[AppointmentTimes] ([Id], [Hours], [Minutes]) VALUES (11, 11, 30)
INSERT [dbo].[AppointmentTimes] ([Id], [Hours], [Minutes]) VALUES (12, 11, 45)
SET IDENTITY_INSERT [dbo].[AppointmentTimes] OFF
GO
SET IDENTITY_INSERT [dbo].[ClinicDoctors] ON 

INSERT [dbo].[ClinicDoctors] ([Id], [DoctorId], [ClinicId]) VALUES (3, 2, 1)
INSERT [dbo].[ClinicDoctors] ([Id], [DoctorId], [ClinicId]) VALUES (4, 3, 1)
SET IDENTITY_INSERT [dbo].[ClinicDoctors] OFF
GO
SET IDENTITY_INSERT [dbo].[Clinics] ON 

INSERT [dbo].[Clinics] ([Id], [Name], [AddressId], [DateCreated]) VALUES (1, N'Clinique O'' Doooom', 1, CAST(N'2022-12-01T14:41:23.443' AS DateTime))
SET IDENTITY_INSERT [dbo].[Clinics] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctors] ON 

INSERT [dbo].[Doctors] ([Id], [StatusId], [FirstName], [LastName], [LicenseNo], [DateHired], [DateCreated]) VALUES (2, 2, N'Leonard', N'Mccoy', N'00000001', CAST(N'2022-11-10' AS Date), CAST(N'2022-12-01T14:42:11.133' AS DateTime))
INSERT [dbo].[Doctors] ([Id], [StatusId], [FirstName], [LastName], [LicenseNo], [DateHired], [DateCreated]) VALUES (3, 2, N' ', N'Who', N'00000002', CAST(N'2022-11-10' AS Date), CAST(N'2022-12-01T14:43:04.420' AS DateTime))
SET IDENTITY_INSERT [dbo].[Doctors] OFF
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([Id], [StatusId], [FirstName], [LastName], [HealthCardNumber], [DateCreated]) VALUES (1, 2, N'John', N'Doe', N'DOEJ00000000', CAST(N'2022-12-01T14:43:40.950' AS DateTime))
INSERT [dbo].[Patients] ([Id], [StatusId], [FirstName], [LastName], [HealthCardNumber], [DateCreated]) VALUES (2, 2, N'Jane', N'Doe', N'DOEJ00000001', CAST(N'2022-12-01T14:43:52.733' AS DateTime))
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
SET IDENTITY_INSERT [dbo].[Statuses] ON 

INSERT [dbo].[Statuses] ([Id], [StatusCode]) VALUES (1, N'CREATED')
INSERT [dbo].[Statuses] ([Id], [StatusCode]) VALUES (2, N'ACTIVE')
INSERT [dbo].[Statuses] ([Id], [StatusCode]) VALUES (3, N'INACTIVE')
INSERT [dbo].[Statuses] ([Id], [StatusCode]) VALUES (4, N'SUSPENDED')
INSERT [dbo].[Statuses] ([Id], [StatusCode]) VALUES (5, N'DELETED')
SET IDENTITY_INSERT [dbo].[Statuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [StatusId], [ClinicId], [Username], [PasswordHash], [LastLogin], [DateCreated]) VALUES (1, 2, 1, N'userTest', N'546120414B867325EF21DFF82A32BE081945E693D4A9FC68452313B2035DD6ED:35C037A6472DE7A230B8098501C05028:100000:SHA256', CAST(N'2022-12-02T16:10:56.280' AS DateTime), CAST(N'2022-12-01T14:44:56.867' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_ClinicDoctors]    Script Date: 12/2/2022 4:22:36 PM ******/
ALTER TABLE [dbo].[ClinicDoctors] ADD  CONSTRAINT [IX_ClinicDoctors] UNIQUE NONCLUSTERED 
(
	[DoctorId] ASC,
	[ClinicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Addresses] ADD  CONSTRAINT [DF_Addresses_DateCreated]  DEFAULT (sysdatetime()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Appointments] ADD  CONSTRAINT [DF_Appointments_DateCreated]  DEFAULT (sysdatetime()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Clinics] ADD  CONSTRAINT [DF_Clinics_DateCreated]  DEFAULT (sysdatetime()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Doctors] ADD  CONSTRAINT [DF_Doctors_DateCreated]  DEFAULT (sysdatetime()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Patients] ADD  CONSTRAINT [DF_Patients_DateCreated]  DEFAULT (sysdatetime()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_DateCreated]  DEFAULT (sysdatetime()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_AppointmentTimes] FOREIGN KEY([AppointmentTimeId])
REFERENCES [dbo].[AppointmentTimes] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_AppointmentTimes]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Clinics] FOREIGN KEY([ClinicId])
REFERENCES [dbo].[Clinics] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Clinics]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Doctors] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Doctors]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Patients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Patients]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Statuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Statuses] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Statuses]
GO
ALTER TABLE [dbo].[ClinicDoctors]  WITH CHECK ADD  CONSTRAINT [FK_ClinicDoctors_Clinics] FOREIGN KEY([ClinicId])
REFERENCES [dbo].[Clinics] ([Id])
GO
ALTER TABLE [dbo].[ClinicDoctors] CHECK CONSTRAINT [FK_ClinicDoctors_Clinics]
GO
ALTER TABLE [dbo].[ClinicDoctors]  WITH CHECK ADD  CONSTRAINT [FK_ClinicDoctors_Doctors] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([Id])
GO
ALTER TABLE [dbo].[ClinicDoctors] CHECK CONSTRAINT [FK_ClinicDoctors_Doctors]
GO
ALTER TABLE [dbo].[Clinics]  WITH CHECK ADD  CONSTRAINT [FK_Clinics_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([Id])
GO
ALTER TABLE [dbo].[Clinics] CHECK CONSTRAINT [FK_Clinics_Addresses]
GO
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [FK_Doctors_Statuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Statuses] ([Id])
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_Doctors_Statuses]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Statuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Statuses] ([Id])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Statuses]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Clinics] FOREIGN KEY([ClinicId])
REFERENCES [dbo].[Clinics] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Clinics]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Statuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Statuses] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Statuses]
GO
USE [master]
GO
ALTER DATABASE [db_speedrun_en] SET  READ_WRITE 
GO
