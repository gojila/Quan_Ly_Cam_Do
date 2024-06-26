USE [master]
GO
/****** Object:  Database [PhanMemCanXeTai]    Script Date: 16/02/2020 11:39:42 SA ******/
CREATE DATABASE [PhanMemCanXeTai] ON  PRIMARY 
( NAME = N'PhanMemCanXeTai', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\PhanMemCanXeTai.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PhanMemCanXeTai_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\PhanMemCanXeTai_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhanMemCanXeTai].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PhanMemCanXeTai] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhanMemCanXeTai] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhanMemCanXeTai] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PhanMemCanXeTai] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhanMemCanXeTai] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhanMemCanXeTai] SET RECOVERY FULL 
GO
ALTER DATABASE [PhanMemCanXeTai] SET  MULTI_USER 
GO
ALTER DATABASE [PhanMemCanXeTai] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhanMemCanXeTai] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PhanMemCanXeTai', N'ON'
GO
USE [PhanMemCanXeTai]
GO
/****** Object:  Table [dbo].[PhieuCan]    Script Date: 16/02/2020 11:39:42 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuCan](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SoPhieu] [nvarchar](250) NULL,
	[Ngay] [date] NULL,
	[SoXe] [nvarchar](250) NULL,
	[KhachHang] [nvarchar](250) NULL,
	[Loaihang] [nvarchar](250) NULL,
	[NgayCan1] [datetime] NULL,
	[NgayCan2] [datetime] NULL,
	[TrongLuongCan1] [money] NULL,
	[TrongLuongCan2] [money] NULL,
	[TrongLuongHang] [money] NULL,
	[XuatNhap] [nvarchar](250) NULL,
	[GhiChu] [nvarchar](250) NULL,
	[Status] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedUser] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpatedUser] [int] NULL,
 CONSTRAINT [PK__PhieuCan__3214EC07DC36C96D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PhieuCan] ON 

INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (1, N'CAN000001', CAST(N'2020-01-29' AS Date), N'123', N'khách hàng 1', N'123', CAST(N'2020-01-29T00:12:51.103' AS DateTime), CAST(N'2020-01-29T00:12:51.103' AS DateTime), 0.0000, 0.0000, 0.0000, N'Nhập', N'123', 1, 0, CAST(N'2020-01-29T00:13:36.367' AS DateTime), 1, CAST(N'2020-01-29T01:46:22.363' AS DateTime), 1)
INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (2, N'CAN000002', CAST(N'2020-01-29' AS Date), N'asdf', N'dsf', N'adfas', CAST(N'2020-01-29T00:30:37.243' AS DateTime), CAST(N'2020-01-29T00:30:37.243' AS DateTime), 0.0000, 0.0000, 0.0000, N'Nhập', N'asdfasdf', 1, 0, CAST(N'2020-01-29T00:31:52.823' AS DateTime), 1, CAST(N'2020-01-29T01:41:49.783' AS DateTime), 1)
INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (3, N'CAN000003', CAST(N'2020-01-29' AS Date), N'ff', N'fff', N'fff', CAST(N'2020-01-29T00:34:59.927' AS DateTime), CAST(N'2020-01-29T00:34:59.927' AS DateTime), 0.0000, 0.0000, 0.0000, N'Nhập', N'fff', 1, 0, CAST(N'2020-01-29T00:35:12.077' AS DateTime), 1, CAST(N'2020-01-29T00:35:12.077' AS DateTime), 1)
INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (4, N'CAN000004', CAST(N'2020-01-29' AS Date), N'sdf', N'sdf', N'sdf', CAST(N'2020-01-29T00:35:13.690' AS DateTime), CAST(N'2020-01-29T00:35:13.690' AS DateTime), 0.0000, 0.0000, 0.0000, N'Xuất', N'sdf', 1, 0, CAST(N'2020-01-29T00:35:19.153' AS DateTime), 1, CAST(N'2020-01-29T01:46:18.853' AS DateTime), 1)
INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (5, N'CAN000005', CAST(N'2020-02-08' AS Date), N'ss', N'ssss', N'Lúa', CAST(N'2020-02-08T20:24:46.737' AS DateTime), CAST(N'2020-02-08T23:59:29.427' AS DateTime), 0.0000, 123456.0000, 0.0000, N'Nhập', N'', 1, 0, CAST(N'2020-02-08T20:26:11.333' AS DateTime), 1, CAST(N'2020-02-09T00:00:02.543' AS DateTime), 1)
INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (6, N'CAN000006', CAST(N'2020-02-08' AS Date), N'hhhh', N'hhh', N'hhh', CAST(N'2020-02-15T10:03:00.000' AS DateTime), CAST(N'2020-02-08T20:28:12.353' AS DateTime), 9999.0000, 9999.0000, 0.0000, N'Nhập', N'', 1, 0, CAST(N'2020-02-08T20:32:39.107' AS DateTime), 1, CAST(N'2020-02-15T15:04:34.100' AS DateTime), 1)
INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (7, N'CAN000007', CAST(N'2020-02-09' AS Date), N'12323123', N'asdfasdf', N'sasdfasdf', CAST(N'2020-02-09T00:12:41.827' AS DateTime), CAST(N'2020-02-09T00:12:41.827' AS DateTime), 44.0000, 44.0000, 0.0000, N'Nhập', N'', 1, 0, CAST(N'2020-02-09T00:12:40.300' AS DateTime), 1, CAST(N'2020-02-15T15:04:41.803' AS DateTime), 1)
INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (8, N'CAN000007', CAST(N'2020-02-09' AS Date), N'12323123', N'asdfasdf', N'sasdfasdf', CAST(N'2020-02-09T00:00:00.000' AS DateTime), CAST(N'2020-02-09T00:00:00.000' AS DateTime), 888.0000, 888.0000, 0.0000, N'Nhập', N'', 1, 0, CAST(N'2020-02-09T01:47:16.343' AS DateTime), 1, CAST(N'2020-02-15T15:04:48.260' AS DateTime), 1)
INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (9, N'CAN000007', CAST(N'2020-02-09' AS Date), N'12323123', N'asdfasdf', N'sasdfasdf', CAST(N'2020-02-09T00:00:00.000' AS DateTime), CAST(N'2020-02-09T00:00:00.000' AS DateTime), 0.0000, 0.0000, 0.0000, N'Nhập', N'', 1, 0, CAST(N'2020-02-09T01:47:39.990' AS DateTime), 1, CAST(N'2020-02-15T20:37:48.953' AS DateTime), 1)
INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (10, N'CAN000008', CAST(N'2020-02-09' AS Date), N'123456', N'Xe ba gác', N'Lúa', CAST(N'2020-02-09T13:17:53.917' AS DateTime), CAST(N'2020-02-09T13:27:38.180' AS DateTime), 22.0000, 88.0000, 66.0000, N'Nhập', N'', 1, 0, CAST(N'2020-02-09T13:27:35.153' AS DateTime), 1, CAST(N'2020-02-15T15:04:26.983' AS DateTime), 1)
INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (11, N'CAN000008', CAST(N'2020-02-09' AS Date), N'123456', N'Xe ba gác', N'', CAST(N'2020-02-15T15:04:58.293' AS DateTime), CAST(N'2020-02-09T00:00:00.000' AS DateTime), 0.0000, 0.0000, 0.0000, N'Nhập', N'', 1, 0, CAST(N'2020-02-09T13:28:33.557' AS DateTime), 1, CAST(N'2020-02-15T15:05:14.340' AS DateTime), 1)
INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (12, N'CAN000009', CAST(N'2020-02-15' AS Date), N'sss', N'ss', N'Lúa', CAST(N'2020-02-15T12:40:00.000' AS DateTime), CAST(N'2020-02-15T07:52:14.800' AS DateTime), 6666.0000, 6666.0000, 0.0000, N'Nhập', N'', 1, 0, CAST(N'2020-02-15T07:52:45.887' AS DateTime), 1, CAST(N'2020-02-15T15:05:23.173' AS DateTime), 1)
INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (13, N'CAN000010', CAST(N'2020-02-15' AS Date), N'd', N'ssss', N'', CAST(N'2020-02-15T15:05:24.310' AS DateTime), CAST(N'2020-02-15T15:05:24.310' AS DateTime), 0.0000, 0.0000, 0.0000, N'Nhập', N'', 1, 0, CAST(N'2020-02-15T20:38:53.483' AS DateTime), 1, CAST(N'2020-02-15T20:38:53.483' AS DateTime), 1)
INSERT [dbo].[PhieuCan] ([Id], [SoPhieu], [Ngay], [SoXe], [KhachHang], [Loaihang], [NgayCan1], [NgayCan2], [TrongLuongCan1], [TrongLuongCan2], [TrongLuongHang], [XuatNhap], [GhiChu], [Status], [IsDeleted], [CreatedDate], [CreatedUser], [UpdatedDate], [UpatedUser]) VALUES (14, N'CAN000011', CAST(N'2020-02-15' AS Date), N'd', N'd', N'', CAST(N'2020-02-15T20:43:19.193' AS DateTime), CAST(N'2020-02-15T20:43:19.193' AS DateTime), 0.0000, 88.0000, 0.0000, N'Nhập', N'', 1, 0, CAST(N'2020-02-15T20:44:17.417' AS DateTime), 1, CAST(N'2020-02-15T20:44:17.417' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[PhieuCan] OFF
USE [master]
GO
ALTER DATABASE [PhanMemCanXeTai] SET  READ_WRITE 
GO
