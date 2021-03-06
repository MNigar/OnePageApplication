/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [Escanor]    Script Date: 4/6/2021 7:07:13 PM ******/
CREATE DATABASE [Escanor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Escanor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Escanor.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Escanor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Escanor_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Escanor] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Escanor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Escanor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Escanor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Escanor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Escanor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Escanor] SET ARITHABORT OFF 
GO
ALTER DATABASE [Escanor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Escanor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Escanor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Escanor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Escanor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Escanor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Escanor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Escanor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Escanor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Escanor] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Escanor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Escanor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Escanor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Escanor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Escanor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Escanor] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Escanor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Escanor] SET RECOVERY FULL 
GO
ALTER DATABASE [Escanor] SET  MULTI_USER 
GO
ALTER DATABASE [Escanor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Escanor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Escanor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Escanor] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Escanor] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Escanor', N'ON'
GO
ALTER DATABASE [Escanor] SET QUERY_STORE = OFF
GO
USE [Escanor]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Escanor]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 4/6/2021 7:07:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Abouts]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abouts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[PreTitle] [nvarchar](50) NULL,
	[Text] [nvarchar](100) NULL,
	[Signature] [nvarchar](255) NULL,
 CONSTRAINT [PK_dbo.Abouts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderBy] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facts]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Point] [int] NOT NULL,
	[Icon] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Facts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Features]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Features](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Icon] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Features] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Holder] [nvarchar](max) NULL,
	[Position] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Feedbacks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Icons]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Icons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Icons] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Icons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsVisible] [bit] NOT NULL,
	[Orderby] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Menus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packages]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[PacketPrice] [decimal](18, 2) NOT NULL,
	[PriceId] [int] NOT NULL,
	[DiskSpace] [int] NOT NULL,
	[DomainCount] [int] NOT NULL,
	[EmailCount] [int] NOT NULL,
	[Support] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Packages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Date] [datetime] NULL,
	[Photo] [nvarchar](max) NULL,
	[Tag] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prices]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Prices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Photo] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceComponents]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceComponents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Icon] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[ServiceId] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ServiceComponents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[SubTitle] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Logo] [nvarchar](200) NULL,
	[Title] [nvarchar](max) NULL,
	[SubTitle] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[SubFooterText] [nvarchar](max) NULL,
	[IntroPhoto] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Point] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Skills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialMedias]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialMedias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[SettingId] [int] NOT NULL,
	[IconId] [int] NOT NULL,
	[Link] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.SocialMedias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/6/2021 7:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_PriceId]    Script Date: 4/6/2021 7:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_PriceId] ON [dbo].[Packages]
(
	[PriceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryId]    Script Date: 4/6/2021 7:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[Projects]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ServiceId]    Script Date: 4/6/2021 7:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ServiceId] ON [dbo].[ServiceComponents]
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_IconId]    Script Date: 4/6/2021 7:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_IconId] ON [dbo].[SocialMedias]
(
	[IconId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SettingId]    Script Date: 4/6/2021 7:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_SettingId] ON [dbo].[SocialMedias]
(
	[SettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Packages] ADD  DEFAULT ((0)) FOR [PacketPrice]
GO
ALTER TABLE [dbo].[Packages] ADD  DEFAULT ((0)) FOR [PriceId]
GO
ALTER TABLE [dbo].[Packages] ADD  DEFAULT ((0)) FOR [DiskSpace]
GO
ALTER TABLE [dbo].[Packages] ADD  DEFAULT ((0)) FOR [DomainCount]
GO
ALTER TABLE [dbo].[Packages] ADD  DEFAULT ((0)) FOR [EmailCount]
GO
ALTER TABLE [dbo].[SocialMedias] ADD  DEFAULT ((0)) FOR [SettingId]
GO
ALTER TABLE [dbo].[SocialMedias] ADD  DEFAULT ((0)) FOR [IconId]
GO
ALTER TABLE [dbo].[Packages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Packages_dbo.Prices_PriceId] FOREIGN KEY([PriceId])
REFERENCES [dbo].[Prices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Packages] CHECK CONSTRAINT [FK_dbo.Packages_dbo.Prices_PriceId]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Projects_dbo.Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_dbo.Projects_dbo.Categories_CategoryId]
GO
ALTER TABLE [dbo].[ServiceComponents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ServiceComponents_dbo.Services_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ServiceComponents] CHECK CONSTRAINT [FK_dbo.ServiceComponents_dbo.Services_ServiceId]
GO
ALTER TABLE [dbo].[SocialMedias]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SocialMedias_dbo.Icons_IconId] FOREIGN KEY([IconId])
REFERENCES [dbo].[Icons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SocialMedias] CHECK CONSTRAINT [FK_dbo.SocialMedias_dbo.Icons_IconId]
GO
ALTER TABLE [dbo].[SocialMedias]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SocialMedias_dbo.Settings_SettingId] FOREIGN KEY([SettingId])
REFERENCES [dbo].[Settings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SocialMedias] CHECK CONSTRAINT [FK_dbo.SocialMedias_dbo.Settings_SettingId]
GO
USE [master]
GO
ALTER DATABASE [Escanor] SET  READ_WRITE 
GO
