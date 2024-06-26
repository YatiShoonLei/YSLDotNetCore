USE [master]
GO
/****** Object:  Database [YSLDotNetCore]    Script Date: 5/30/2024 11:21:40 PM ******/
CREATE DATABASE [YSLDotNetCore] ON  PRIMARY 
( NAME = N'YSLDotNetCore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\YSLDotNetCore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'YSLDotNetCore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\YSLDotNetCore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [YSLDotNetCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [YSLDotNetCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [YSLDotNetCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [YSLDotNetCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [YSLDotNetCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [YSLDotNetCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [YSLDotNetCore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [YSLDotNetCore] SET  MULTI_USER 
GO
ALTER DATABASE [YSLDotNetCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [YSLDotNetCore] SET DB_CHAINING OFF 
GO
USE [YSLDotNetCore]
GO
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 5/30/2024 11:21:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Blog](
	[BlogID] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [varchar](50) NOT NULL,
	[BlogAuthor] [varchar](50) NOT NULL,
	[BlogContent] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Blog] ON 

INSERT [dbo].[Tbl_Blog] ([BlogID], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1, N'Title1', N'Author1', N'Content1')
INSERT [dbo].[Tbl_Blog] ([BlogID], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2, N'Title2', N'Author2', N'Content2')
INSERT [dbo].[Tbl_Blog] ([BlogID], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (3, N'Title3', N'Author3', N'Content3')
INSERT [dbo].[Tbl_Blog] ([BlogID], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (4, N'Title4', N'Author4', N'Content4')
INSERT [dbo].[Tbl_Blog] ([BlogID], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (5, N'Title5', N'Author5', N'Content5')
INSERT [dbo].[Tbl_Blog] ([BlogID], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (6, N'Title6', N'Author6', N'Content6')
INSERT [dbo].[Tbl_Blog] ([BlogID], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (8, N'Title7', N'Author7', N'Content7')
INSERT [dbo].[Tbl_Blog] ([BlogID], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (9, N'Title8', N'Author8', N'Content8')
INSERT [dbo].[Tbl_Blog] ([BlogID], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (10, N'Title9', N'Author9', N'Content9')
SET IDENTITY_INSERT [dbo].[Tbl_Blog] OFF
GO
USE [master]
GO
ALTER DATABASE [YSLDotNetCore] SET  READ_WRITE 
GO
