USE [master]
GO
/****** Object:  Database [MyCompany]    Script Date: 12/11/2020 11:47:52 PM ******/
CREATE DATABASE [MyCompany]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyCompany', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MyCompany.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MyCompany_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MyCompany_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MyCompany] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyCompany].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyCompany] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyCompany] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyCompany] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyCompany] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyCompany] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyCompany] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyCompany] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyCompany] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyCompany] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyCompany] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyCompany] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyCompany] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyCompany] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyCompany] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyCompany] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyCompany] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyCompany] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyCompany] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyCompany] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyCompany] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyCompany] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyCompany] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyCompany] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyCompany] SET  MULTI_USER 
GO
ALTER DATABASE [MyCompany] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyCompany] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyCompany] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyCompany] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MyCompany] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MyCompany]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/11/2020 11:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NULL,
	[Tel] [ntext] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([ID], [Fullname], [Tel]) VALUES (1, N'Nguyễn Văn Hải', N'111-111-111')
INSERT [dbo].[Customer] ([ID], [Fullname], [Tel]) VALUES (2, N'Trà Mỹ Phương', N'222-222-222')
INSERT [dbo].[Customer] ([ID], [Fullname], [Tel]) VALUES (3, N'Lưu Oanh', N'333-333-333')
INSERT [dbo].[Customer] ([ID], [Fullname], [Tel]) VALUES (4, N'Yên Triệu Kim', N'444-444-444')
INSERT [dbo].[Customer] ([ID], [Fullname], [Tel]) VALUES (5, N'Mã Song Trinh', N'555-555-555')
INSERT [dbo].[Customer] ([ID], [Fullname], [Tel]) VALUES (6, N'Giang Mộng Đường', N'666-666-666')
INSERT [dbo].[Customer] ([ID], [Fullname], [Tel]) VALUES (7, N'Tiêu Nghiêm', N'777-777-777')
INSERT [dbo].[Customer] ([ID], [Fullname], [Tel]) VALUES (8, N'Nghiêm Ngọc Thống', N'888-888-888')
INSERT [dbo].[Customer] ([ID], [Fullname], [Tel]) VALUES (9, N'Lỡ Ân', N'999-999-999')
INSERT [dbo].[Customer] ([ID], [Fullname], [Tel]) VALUES (10, N'Lý Bửu Tuấn', N'000-000-000')
SET IDENTITY_INSERT [dbo].[Customer] OFF
USE [master]
GO
ALTER DATABASE [MyCompany] SET  READ_WRITE 
GO
