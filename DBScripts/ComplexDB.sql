USE [master]
GO
/****** Object:  Database [ComplexDB]    Script Date: 12/12/2020 12:26:11 AM ******/
CREATE DATABASE [ComplexDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ComplexDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ComplexDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ComplexDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ComplexDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ComplexDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComplexDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComplexDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComplexDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComplexDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComplexDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComplexDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComplexDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ComplexDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComplexDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComplexDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComplexDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComplexDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComplexDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComplexDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComplexDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComplexDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ComplexDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComplexDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComplexDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComplexDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComplexDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComplexDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ComplexDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComplexDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ComplexDB] SET  MULTI_USER 
GO
ALTER DATABASE [ComplexDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComplexDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComplexDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComplexDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ComplexDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ComplexDB]
GO
/****** Object:  Table [dbo].[BOMON]    Script Date: 12/12/2020 12:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BOMON](
	[mabm] [varchar](10) NOT NULL,
	[tenbm] [nvarchar](20) NULL,
	[phong] [varchar](10) NULL,
	[dienthoai] [varchar](12) NULL,
	[truongbm] [varchar](10) NULL,
	[makhoa] [varchar](10) NULL,
	[ngaynhanchuc] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[mabm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHUDE]    Script Date: 12/12/2020 12:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHUDE](
	[macd] [varchar](10) NOT NULL,
	[tencd] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[macd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CONGVIEC]    Script Date: 12/12/2020 12:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CONGVIEC](
	[madt] [varchar](10) NOT NULL,
	[sott] [int] NOT NULL,
	[tencv] [nvarchar](50) NULL,
	[ngaybd] [date] NULL,
	[ngaykt] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[madt] ASC,
	[sott] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DETAI]    Script Date: 12/12/2020 12:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DETAI](
	[madt] [varchar](10) NOT NULL,
	[tendt] [nvarchar](50) NULL,
	[capql] [nvarchar](10) NULL,
	[kinhphi] [money] NULL,
	[ngaybd] [date] NULL,
	[ngaykt] [date] NULL,
	[macd] [varchar](10) NULL,
	[gvcndt] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[madt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GIAOVIEN]    Script Date: 12/12/2020 12:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GIAOVIEN](
	[magv] [varchar](10) NOT NULL,
	[hoten] [nvarchar](50) NULL,
	[luong] [money] NULL,
	[phai] [varchar](5) NULL,
	[ngsinh] [date] NULL,
	[diachi] [nvarchar](50) NULL,
	[gvqlcm] [varchar](10) NULL,
	[mabm] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[magv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GV_DT]    Script Date: 12/12/2020 12:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GV_DT](
	[magv] [varchar](10) NULL,
	[dienthoai] [varchar](12) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHOA]    Script Date: 12/12/2020 12:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHOA](
	[makhoa] [varchar](10) NOT NULL,
	[tenkhoa] [nvarchar](20) NULL,
	[namtl] [date] NULL,
	[phong] [varchar](10) NULL,
	[dienthoai] [varchar](12) NULL,
	[truongkhoa] [varchar](10) NULL,
	[ngaynhanchuc] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[makhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NGUOITHAN]    Script Date: 12/12/2020 12:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NGUOITHAN](
	[magv] [varchar](10) NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
	[ngsinh] [date] NULL,
	[phai] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[magv] ASC,
	[ten] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[THAMGIADT]    Script Date: 12/12/2020 12:26:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[THAMGIADT](
	[magv] [varchar](10) NOT NULL,
	[madt] [varchar](10) NOT NULL,
	[stt] [int] NOT NULL,
	[phucap] [money] NULL,
	[ketqua] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[magv] ASC,
	[madt] ASC,
	[stt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[BOMON] ([mabm], [tenbm], [phong], [dienthoai], [truongbm], [makhoa], [ngaynhanchuc]) VALUES (N'CNTT', N'Công nghệ tri thức', N'B15', N'0838126126', NULL, N'CNTT', NULL)
INSERT [dbo].[BOMON] ([mabm], [tenbm], [phong], [dienthoai], [truongbm], [makhoa], [ngaynhanchuc]) VALUES (N'HHC', N'Hóa hữu co', N'B44', N'838222222', NULL, N'HH', NULL)
INSERT [dbo].[BOMON] ([mabm], [tenbm], [phong], [dienthoai], [truongbm], [makhoa], [ngaynhanchuc]) VALUES (N'HL', N'Hóa lý', N'B42', N'0838878787', NULL, N'HH', NULL)
INSERT [dbo].[BOMON] ([mabm], [tenbm], [phong], [dienthoai], [truongbm], [makhoa], [ngaynhanchuc]) VALUES (N'HPT', N'Hóa phân tích', N'B43', N'0838777777', N'007', N'HH', CAST(N'2007-10-15' AS Date))
INSERT [dbo].[BOMON] ([mabm], [tenbm], [phong], [dienthoai], [truongbm], [makhoa], [ngaynhanchuc]) VALUES (N'HTTT', N'Hệ thống thông tin', N'B13', N'0838125125', N'002', N'CNTT', CAST(N'2004-09-20' AS Date))
INSERT [dbo].[BOMON] ([mabm], [tenbm], [phong], [dienthoai], [truongbm], [makhoa], [ngaynhanchuc]) VALUES (N'MMT', N'Mạng máy tinh', N'B16', N'0838676767', N'001', N'CNTT', CAST(N'2005-05-15' AS Date))
INSERT [dbo].[BOMON] ([mabm], [tenbm], [phong], [dienthoai], [truongbm], [makhoa], [ngaynhanchuc]) VALUES (N'SH', N'Sinh hóa', N'B33', N'0838898989', NULL, N'SH', NULL)
INSERT [dbo].[BOMON] ([mabm], [tenbm], [phong], [dienthoai], [truongbm], [makhoa], [ngaynhanchuc]) VALUES (N'VLUD', N'Vật lý ứng dụng', N'B24', N'0838454545', N'005', N'VL', CAST(N'2006-02-18' AS Date))
INSERT [dbo].[BOMON] ([mabm], [tenbm], [phong], [dienthoai], [truongbm], [makhoa], [ngaynhanchuc]) VALUES (N'VLÐT', N'Vật lý điện tử', N'B23', N'0838234234', NULL, N'VL', NULL)
INSERT [dbo].[BOMON] ([mabm], [tenbm], [phong], [dienthoai], [truongbm], [makhoa], [ngaynhanchuc]) VALUES (N'VS', N'Vi sinh', N'B32', N'0838909090', N'004', N'SH', CAST(N'2007-01-01' AS Date))
INSERT [dbo].[CHUDE] ([macd], [tencd]) VALUES (N'NCPT', N'nghiên cứu phát triển')
INSERT [dbo].[CHUDE] ([macd], [tencd]) VALUES (N'QLGD', N'quản lý giáo dục')
INSERT [dbo].[CHUDE] ([macd], [tencd]) VALUES (N'UDCN', N'ứng dụng công nghệ')
INSERT [dbo].[CONGVIEC] ([madt], [sott], [tencv], [ngaybd], [ngaykt]) VALUES (N'001', 1, N'Khỏi tạo và Lập kế	hoạch', CAST(N'2007-10-20' AS Date), CAST(N'2008-12-20' AS Date))
INSERT [dbo].[CONGVIEC] ([madt], [sott], [tencv], [ngaybd], [ngaykt]) VALUES (N'001', 2, N'Xác định yêu cầu', CAST(N'2008-12-21' AS Date), CAST(N'2008-03-21' AS Date))
INSERT [dbo].[CONGVIEC] ([madt], [sott], [tencv], [ngaybd], [ngaykt]) VALUES (N'001', 3, N'Phân tích hệ thống', CAST(N'2008-03-22' AS Date), CAST(N'2008-05-22' AS Date))
INSERT [dbo].[CONGVIEC] ([madt], [sott], [tencv], [ngaybd], [ngaykt]) VALUES (N'001', 4, N'Thiết kế hệ thống', CAST(N'2008-05-23' AS Date), CAST(N'2008-06-23' AS Date))
INSERT [dbo].[CONGVIEC] ([madt], [sott], [tencv], [ngaybd], [ngaykt]) VALUES (N'001', 5, N'Cài đặt thử nghiệm', CAST(N'2008-06-24' AS Date), CAST(N'2008-10-20' AS Date))
INSERT [dbo].[CONGVIEC] ([madt], [sott], [tencv], [ngaybd], [ngaykt]) VALUES (N'002', 1, N'Khỏi tạo và Lập kế	hoạch', CAST(N'2009-05-10' AS Date), CAST(N'2009-07-10' AS Date))
INSERT [dbo].[CONGVIEC] ([madt], [sott], [tencv], [ngaybd], [ngaykt]) VALUES (N'002', 2, N'Xác định yêu cẩu', CAST(N'2009-07-11' AS Date), CAST(N'2009-10-11' AS Date))
INSERT [dbo].[CONGVIEC] ([madt], [sott], [tencv], [ngaybd], [ngaykt]) VALUES (N'002', 3, N'Phân tích hệ thống', CAST(N'2009-10-12' AS Date), CAST(N'2009-12-20' AS Date))
INSERT [dbo].[CONGVIEC] ([madt], [sott], [tencv], [ngaybd], [ngaykt]) VALUES (N'002', 4, N'Thiết kế hệ thống', CAST(N'2009-12-21' AS Date), CAST(N'2010-03-22' AS Date))
INSERT [dbo].[CONGVIEC] ([madt], [sott], [tencv], [ngaybd], [ngaykt]) VALUES (N'002', 5, N'cài đặt thử nghiệm', CAST(N'2010-03-23' AS Date), CAST(N'2010-05-10' AS Date))
INSERT [dbo].[CONGVIEC] ([madt], [sott], [tencv], [ngaybd], [ngaykt]) VALUES (N'006', 1, N'Lấy mẫu', CAST(N'2006-10-20' AS Date), CAST(N'2007-02-20' AS Date))
INSERT [dbo].[CONGVIEC] ([madt], [sott], [tencv], [ngaybd], [ngaykt]) VALUES (N'006', 2, N'Nuôi cấy', CAST(N'2007-02-21' AS Date), CAST(N'2008-08-21' AS Date))
INSERT [dbo].[DETAI] ([madt], [tendt], [capql], [kinhphi], [ngaybd], [ngaykt], [macd], [gvcndt]) VALUES (N'001', N'HTTT quản lý các trường ĐH', N'ÐHQG', 20.0000, CAST(N'2007-10-20' AS Date), CAST(N'2008-10-20' AS Date), N'QLGD', N'002')
INSERT [dbo].[DETAI] ([madt], [tendt], [capql], [kinhphi], [ngaybd], [ngaykt], [macd], [gvcndt]) VALUES (N'002', N'HTTT quản lý giáo vụ cho một Khoa', N'Trường', 20.0000, CAST(N'2000-10-12' AS Date), CAST(N'2001-10-12' AS Date), N'QLGD', N'002')
INSERT [dbo].[DETAI] ([madt], [tendt], [capql], [kinhphi], [ngaybd], [ngaykt], [macd], [gvcndt]) VALUES (N'003', N'Nghiên cứu chế tạo sợi Nanô Platin', N'ÐHQG', 300.0000, CAST(N'2008-05-15' AS Date), CAST(N'2010-05-15' AS Date), N'NCPT', N'005')
INSERT [dbo].[DETAI] ([madt], [tendt], [capql], [kinhphi], [ngaybd], [ngaykt], [macd], [gvcndt]) VALUES (N'004', N'Tạo vật liệu sinh học bằng màng ối người', N'Nhà nước', 100.0000, CAST(N'2007-01-01' AS Date), CAST(N'2009-12-31' AS Date), N'NCPT', N'004')
INSERT [dbo].[DETAI] ([madt], [tendt], [capql], [kinhphi], [ngaybd], [ngaykt], [macd], [gvcndt]) VALUES (N'005', N'Úng dụng hóa học xanh', N'Trường', 200.0000, CAST(N'2003-10-10' AS Date), CAST(N'2004-12-10' AS Date), N'UDCN', N'007')
INSERT [dbo].[DETAI] ([madt], [tendt], [capql], [kinhphi], [ngaybd], [ngaykt], [macd], [gvcndt]) VALUES (N'006', N'Nghiên cứu tế bào gốc', N'Nhà nước', 4000.0000, CAST(N'2006-10-20' AS Date), CAST(N'2009-10-20' AS Date), N'NCPT', N'004')
INSERT [dbo].[DETAI] ([madt], [tendt], [capql], [kinhphi], [ngaybd], [ngaykt], [macd], [gvcndt]) VALUES (N'007', N'HTTT quản lý thư viện ở các trưòng ĐH', N'Trường', 20.0000, CAST(N'2009-05-10' AS Date), CAST(N'2010-05-10' AS Date), N'QLGD', N'001')
INSERT [dbo].[GIAOVIEN] ([magv], [hoten], [luong], [phai], [ngsinh], [diachi], [gvqlcm], [mabm]) VALUES (N'001', N'Nguyễn Hoài An', 2000.0000, N'Nam', CAST(N'1973-02-15' AS Date), N'25/3 Lạc Long Quân, Q.10, TP HCM', NULL, N'MMT')
INSERT [dbo].[GIAOVIEN] ([magv], [hoten], [luong], [phai], [ngsinh], [diachi], [gvqlcm], [mabm]) VALUES (N'002', N'Trần Trà Hương', 2500.0000, N'Nu', CAST(N'1960-06-20' AS Date), N'125 Trần Hưng Đạo, Q.1,TP HCM', NULL, N'HTTT')
INSERT [dbo].[GIAOVIEN] ([magv], [hoten], [luong], [phai], [ngsinh], [diachi], [gvqlcm], [mabm]) VALUES (N'003', N'Nguyễn Ngọc Ánh', 2200.0000, N'Nu', CAST(N'1975-05-11' AS Date), N'12/21 Võ Văn Ngân Thủ Đức, TP HCM', N'002', N'HTTT')
INSERT [dbo].[GIAOVIEN] ([magv], [hoten], [luong], [phai], [ngsinh], [diachi], [gvqlcm], [mabm]) VALUES (N'004', N'Trương Nam Sơn', 2300.0000, N'Nam', CAST(N'1959-06-20' AS Date), N'215 Lý Thường Kiệt,TP Biên Hòa', NULL, N'VS')
INSERT [dbo].[GIAOVIEN] ([magv], [hoten], [luong], [phai], [ngsinh], [diachi], [gvqlcm], [mabm]) VALUES (N'005', N'Lý Hoàng Hà', 2500.0000, N'Nam', CAST(N'1954-10-23' AS Date), N'22/5 Nguyễn xi, Q.Bình Thạnh, TP HCM', NULL, N'VLÐT')
INSERT [dbo].[GIAOVIEN] ([magv], [hoten], [luong], [phai], [ngsinh], [diachi], [gvqlcm], [mabm]) VALUES (N'006', N'Trần Bạch Tuyết', 1500.0000, N'Nu', CAST(N'1980-05-20' AS Date), N'127 Hùng Vương, TP Mỹ Tho', N'004', N'VS')
INSERT [dbo].[GIAOVIEN] ([magv], [hoten], [luong], [phai], [ngsinh], [diachi], [gvqlcm], [mabm]) VALUES (N'007', N'Nguyễn An Trung', 2100.0000, N'Nam', CAST(N'1976-06-05' AS Date), N'234 3/2, TP Biên Hòa', NULL, N'HPT')
INSERT [dbo].[GIAOVIEN] ([magv], [hoten], [luong], [phai], [ngsinh], [diachi], [gvqlcm], [mabm]) VALUES (N'008', N'Trần Trung Hiếu', 1800.0000, N'Nam', CAST(N'1977-08-06' AS Date), N'22/11 Lý Thường Kiệt, TP Mỹ Tho', N'007', N'HPT')
INSERT [dbo].[GIAOVIEN] ([magv], [hoten], [luong], [phai], [ngsinh], [diachi], [gvqlcm], [mabm]) VALUES (N'009', N'Trần Hoàng Nam', 2000.0000, N'Nam', CAST(N'1975-11-22' AS Date), N'234 Trấn Não, An Phú,TP HCM', N'001', N'MMT')
INSERT [dbo].[GIAOVIEN] ([magv], [hoten], [luong], [phai], [ngsinh], [diachi], [gvqlcm], [mabm]) VALUES (N'010', N'Phạm Nam Thanh', 1500.0000, N'Nam', CAST(N'1980-12-12' AS Date), N'221 Hùng Vương, Q.5, TP HCM', N'007', N'HPT')
INSERT [dbo].[GV_DT] ([magv], [dienthoai]) VALUES (N'001', N'0838912112')
INSERT [dbo].[GV_DT] ([magv], [dienthoai]) VALUES (N'001', N'0903123123')
INSERT [dbo].[GV_DT] ([magv], [dienthoai]) VALUES (N'002', N'0913454545')
INSERT [dbo].[GV_DT] ([magv], [dienthoai]) VALUES (N'003', N'0838121212')
INSERT [dbo].[GV_DT] ([magv], [dienthoai]) VALUES (N'003', N'0903656565')
INSERT [dbo].[GV_DT] ([magv], [dienthoai]) VALUES (N'003', N'0937125125')
INSERT [dbo].[GV_DT] ([magv], [dienthoai]) VALUES (N'006', N'0937888888')
INSERT [dbo].[GV_DT] ([magv], [dienthoai]) VALUES (N'008', N'0653717171')
INSERT [dbo].[GV_DT] ([magv], [dienthoai]) VALUES (N'008', N'0913232323')
INSERT [dbo].[KHOA] ([makhoa], [tenkhoa], [namtl], [phong], [dienthoai], [truongkhoa], [ngaynhanchuc]) VALUES (N'CNTT', N'Công nghệ thông tin', CAST(N'1995-01-01' AS Date), N'Bll', N'0838123456', N'002', CAST(N'2005-02-20' AS Date))
INSERT [dbo].[KHOA] ([makhoa], [tenkhoa], [namtl], [phong], [dienthoai], [truongkhoa], [ngaynhanchuc]) VALUES (N'HH', N'Hóa học', CAST(N'1980-01-01' AS Date), N'B41', N'0838456456', N'007', CAST(N'2001-10-15' AS Date))
INSERT [dbo].[KHOA] ([makhoa], [tenkhoa], [namtl], [phong], [dienthoai], [truongkhoa], [ngaynhanchuc]) VALUES (N'SH', N'Sinh học', CAST(N'1980-01-01' AS Date), N'B31', N'0838454545', N'004', CAST(N'2000-10-11' AS Date))
INSERT [dbo].[KHOA] ([makhoa], [tenkhoa], [namtl], [phong], [dienthoai], [truongkhoa], [ngaynhanchuc]) VALUES (N'VL', N'Vật lý', CAST(N'1976-01-01' AS Date), N'B21', N'0838223223', N'005', CAST(N'2003-09-18' AS Date))
INSERT [dbo].[NGUOITHAN] ([magv], [ten], [ngsinh], [phai]) VALUES (N'001', N'Hùng', CAST(N'1990-01-14' AS Date), N'Nam')
INSERT [dbo].[NGUOITHAN] ([magv], [ten], [ngsinh], [phai]) VALUES (N'001', N'Thủy', CAST(N'1994-12-08' AS Date), N'Nu')
INSERT [dbo].[NGUOITHAN] ([magv], [ten], [ngsinh], [phai]) VALUES (N'003', N'Hà', CAST(N'1998-09-03' AS Date), N'Nu')
INSERT [dbo].[NGUOITHAN] ([magv], [ten], [ngsinh], [phai]) VALUES (N'003', N'Thu', CAST(N'1998-09-03' AS Date), N'Nu')
INSERT [dbo].[NGUOITHAN] ([magv], [ten], [ngsinh], [phai]) VALUES (N'007', N'Mai', CAST(N'2003-03-26' AS Date), N'Nu')
INSERT [dbo].[NGUOITHAN] ([magv], [ten], [ngsinh], [phai]) VALUES (N'007', N'Vy', CAST(N'2000-02-14' AS Date), N'Nu')
INSERT [dbo].[NGUOITHAN] ([magv], [ten], [ngsinh], [phai]) VALUES (N'008', N'Nam', CAST(N'1991-05-06' AS Date), N'Nam')
INSERT [dbo].[NGUOITHAN] ([magv], [ten], [ngsinh], [phai]) VALUES (N'009', N'An', CAST(N'1996-08-19' AS Date), N'Nam')
INSERT [dbo].[NGUOITHAN] ([magv], [ten], [ngsinh], [phai]) VALUES (N'010', N'Nguyệt', CAST(N'2006-01-14' AS Date), N'Nu')
INSERT [dbo].[THAMGIADT] ([magv], [madt], [stt], [phucap], [ketqua]) VALUES (N'001', N'002', 1, 0.0000, NULL)
INSERT [dbo].[THAMGIADT] ([magv], [madt], [stt], [phucap], [ketqua]) VALUES (N'001', N'002', 2, 2.0000, NULL)
INSERT [dbo].[THAMGIADT] ([magv], [madt], [stt], [phucap], [ketqua]) VALUES (N'002', N'001', 4, 2.0000, N'Dat')
INSERT [dbo].[THAMGIADT] ([magv], [madt], [stt], [phucap], [ketqua]) VALUES (N'003', N'001', 1, 1.0000, N'Dat')
INSERT [dbo].[THAMGIADT] ([magv], [madt], [stt], [phucap], [ketqua]) VALUES (N'003', N'001', 2, 1.0000, N'Dat')
INSERT [dbo].[THAMGIADT] ([magv], [madt], [stt], [phucap], [ketqua]) VALUES (N'003', N'001', 4, 1.0000, N'Dat')
INSERT [dbo].[THAMGIADT] ([magv], [madt], [stt], [phucap], [ketqua]) VALUES (N'003', N'002', 2, 0.0000, NULL)
INSERT [dbo].[THAMGIADT] ([magv], [madt], [stt], [phucap], [ketqua]) VALUES (N'004', N'006', 1, 0.0000, N'Dat')
INSERT [dbo].[THAMGIADT] ([magv], [madt], [stt], [phucap], [ketqua]) VALUES (N'004', N'006', 2, 1.0000, N'Dat')
INSERT [dbo].[THAMGIADT] ([magv], [madt], [stt], [phucap], [ketqua]) VALUES (N'006', N'006', 2, 1.5000, N'Dat')
INSERT [dbo].[THAMGIADT] ([magv], [madt], [stt], [phucap], [ketqua]) VALUES (N'009', N'002', 3, 0.5000, NULL)
INSERT [dbo].[THAMGIADT] ([magv], [madt], [stt], [phucap], [ketqua]) VALUES (N'009', N'002', 4, 1.5000, NULL)
ALTER TABLE [dbo].[BOMON]  WITH CHECK ADD  CONSTRAINT [FK_bomon_giaovien] FOREIGN KEY([truongbm])
REFERENCES [dbo].[GIAOVIEN] ([magv])
GO
ALTER TABLE [dbo].[BOMON] CHECK CONSTRAINT [FK_bomon_giaovien]
GO
ALTER TABLE [dbo].[BOMON]  WITH CHECK ADD  CONSTRAINT [FK_bomon_khoa] FOREIGN KEY([makhoa])
REFERENCES [dbo].[KHOA] ([makhoa])
GO
ALTER TABLE [dbo].[BOMON] CHECK CONSTRAINT [FK_bomon_khoa]
GO
ALTER TABLE [dbo].[CONGVIEC]  WITH CHECK ADD  CONSTRAINT [FK_congviec_detai] FOREIGN KEY([madt])
REFERENCES [dbo].[DETAI] ([madt])
GO
ALTER TABLE [dbo].[CONGVIEC] CHECK CONSTRAINT [FK_congviec_detai]
GO
ALTER TABLE [dbo].[DETAI]  WITH CHECK ADD  CONSTRAINT [FK_detai_chude] FOREIGN KEY([macd])
REFERENCES [dbo].[CHUDE] ([macd])
GO
ALTER TABLE [dbo].[DETAI] CHECK CONSTRAINT [FK_detai_chude]
GO
ALTER TABLE [dbo].[DETAI]  WITH CHECK ADD  CONSTRAINT [FK_detai_giaovien] FOREIGN KEY([gvcndt])
REFERENCES [dbo].[GIAOVIEN] ([magv])
GO
ALTER TABLE [dbo].[DETAI] CHECK CONSTRAINT [FK_detai_giaovien]
GO
ALTER TABLE [dbo].[GIAOVIEN]  WITH CHECK ADD  CONSTRAINT [FK_giaovien_bomon] FOREIGN KEY([mabm])
REFERENCES [dbo].[BOMON] ([mabm])
GO
ALTER TABLE [dbo].[GIAOVIEN] CHECK CONSTRAINT [FK_giaovien_bomon]
GO
ALTER TABLE [dbo].[GIAOVIEN]  WITH CHECK ADD  CONSTRAINT [FK_giaovien_giaovien] FOREIGN KEY([gvqlcm])
REFERENCES [dbo].[GIAOVIEN] ([magv])
GO
ALTER TABLE [dbo].[GIAOVIEN] CHECK CONSTRAINT [FK_giaovien_giaovien]
GO
ALTER TABLE [dbo].[GV_DT]  WITH CHECK ADD  CONSTRAINT [FK_GV_DT_GIAOVIEN] FOREIGN KEY([magv])
REFERENCES [dbo].[GIAOVIEN] ([magv])
GO
ALTER TABLE [dbo].[GV_DT] CHECK CONSTRAINT [FK_GV_DT_GIAOVIEN]
GO
ALTER TABLE [dbo].[KHOA]  WITH CHECK ADD  CONSTRAINT [FK_khoa_giaovien] FOREIGN KEY([truongkhoa])
REFERENCES [dbo].[GIAOVIEN] ([magv])
GO
ALTER TABLE [dbo].[KHOA] CHECK CONSTRAINT [FK_khoa_giaovien]
GO
ALTER TABLE [dbo].[NGUOITHAN]  WITH CHECK ADD  CONSTRAINT [FK_nguoithan_giaovien] FOREIGN KEY([magv])
REFERENCES [dbo].[GIAOVIEN] ([magv])
GO
ALTER TABLE [dbo].[NGUOITHAN] CHECK CONSTRAINT [FK_nguoithan_giaovien]
GO
ALTER TABLE [dbo].[THAMGIADT]  WITH CHECK ADD  CONSTRAINT [FK_thamgiadt_congviec] FOREIGN KEY([madt], [stt])
REFERENCES [dbo].[CONGVIEC] ([madt], [sott])
GO
ALTER TABLE [dbo].[THAMGIADT] CHECK CONSTRAINT [FK_thamgiadt_congviec]
GO
ALTER TABLE [dbo].[THAMGIADT]  WITH CHECK ADD  CONSTRAINT [FK_thamgiadt_giaovien] FOREIGN KEY([magv])
REFERENCES [dbo].[GIAOVIEN] ([magv])
GO
ALTER TABLE [dbo].[THAMGIADT] CHECK CONSTRAINT [FK_thamgiadt_giaovien]
GO
USE [master]
GO
ALTER DATABASE [ComplexDB] SET  READ_WRITE 
GO
