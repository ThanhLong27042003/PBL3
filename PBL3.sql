USE [master]
GO
/****** Object:  Database [ppl3]    Script Date: 25/05/2023 10:23:51 SA ******/
CREATE DATABASE [ppl3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ppl3_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ppl3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ppl3_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ppl3.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ppl3] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ppl3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ppl3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ppl3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ppl3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ppl3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ppl3] SET ARITHABORT OFF 
GO
ALTER DATABASE [ppl3] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ppl3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ppl3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ppl3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ppl3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ppl3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ppl3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ppl3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ppl3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ppl3] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ppl3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ppl3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ppl3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ppl3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ppl3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ppl3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ppl3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ppl3] SET RECOVERY FULL 
GO
ALTER DATABASE [ppl3] SET  MULTI_USER 
GO
ALTER DATABASE [ppl3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ppl3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ppl3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ppl3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ppl3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ppl3] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ppl3] SET QUERY_STORE = OFF
GO
USE [ppl3]
GO
/****** Object:  Table [dbo].[BAN]    Script Date: 25/05/2023 10:23:51 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAN](
	[Mã bàn] [nvarchar](10) NOT NULL,
	[Tên bàn] [nvarchar](50) NOT NULL,
	[Mã bàn ảo] [nvarchar](10) NOT NULL,
	[Mã bàn ảo chính] [nvarchar](10) NOT NULL,
	[Trạng thái ghép] [bit] NOT NULL,
 CONSTRAINT [PK_BAN] PRIMARY KEY CLUSTERED 
(
	[Mã bàn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BANAO]    Script Date: 25/05/2023 10:23:51 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BANAO](
	[Mã bàn ảo] [nvarchar](10) NOT NULL,
	[Tên bàn ảo] [nvarchar](50) NOT NULL,
	[Trạng thái] [bit] NOT NULL,
 CONSTRAINT [PK_BANAO] PRIMARY KEY CLUSTERED 
(
	[Mã bàn ảo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETHOADON]    Script Date: 25/05/2023 10:23:51 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHOADON](
	[Mã sản phẩm] [varchar](50) NOT NULL,
	[Mã hóa đơn] [varchar](50) NOT NULL,
	[Số lượng] [int] NOT NULL,
	[Giá tiền] [float] NOT NULL,
 CONSTRAINT [PK_CHITIETHOADON] PRIMARY KEY CLUSTERED 
(
	[Mã sản phẩm] ASC,
	[Mã hóa đơn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 25/05/2023 10:23:51 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[Mã hóa đơn] [varchar](50) NOT NULL,
	[Mã tài khoản] [varchar](100) NOT NULL,
	[Mã bàn ảo] [nvarchar](10) NOT NULL,
	[Ngày tạo] [date] NOT NULL,
	[Trạng thái] [bit] NOT NULL,
	[Tổng tiền] [float] NOT NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[Mã hóa đơn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAISANPHAM]    Script Date: 25/05/2023 10:23:51 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISANPHAM](
	[Mã loại] [varchar](50) NOT NULL,
	[Tên loại] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LOAISANPHAM] PRIMARY KEY CLUSTERED 
(
	[Mã loại] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 25/05/2023 10:23:51 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[Mã sản phẩm] [varchar](50) NOT NULL,
	[Tên sản phẩm] [nvarchar](50) NOT NULL,
	[Mã loại] [varchar](50) NOT NULL,
	[Giá] [float] NOT NULL,
 CONSTRAINT [PK_SANPHAM_1] PRIMARY KEY CLUSTERED 
(
	[Mã sản phẩm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 25/05/2023 10:23:51 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[Mã tài khoản] [varchar](100) NOT NULL,
	[Tên tài khoản] [nvarchar](50) NOT NULL,
	[Mật khẩu] [nvarchar](50) NOT NULL,
	[PQ] [bit] NULL,
	[Khóa] [bit] NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[Mã tài khoản] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THONGTINTAIKHOAN]    Script Date: 25/05/2023 10:23:51 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THONGTINTAIKHOAN](
	[Mã nhân viên] [varchar](100) NOT NULL,
	[Tên nhân viên] [nvarchar](50) NOT NULL,
	[CMND] [nvarchar](50) NOT NULL,
	[SĐT] [nvarchar](50) NOT NULL,
	[Địa chỉ] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_THONGTINTAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[Mã nhân viên] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban01', N'bàn 1', N'banao01', N'banao01', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban02', N'bàn 2', N'banao02', N'banao02', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban03', N'bàn 3', N'banao03', N'banao03', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban04', N'bàn 4', N'banao04', N'banao04', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban05', N'bàn 5', N'banao05', N'banao05', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban06', N'bàn 6', N'banao06', N'banao06', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban07', N'bàn 7', N'banao07', N'banao07', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban08', N'bàn 8', N'banao08', N'banao08', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban09', N'bàn 9', N'banao09', N'banao09', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban10', N'bàn 10', N'banao10', N'banao10', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban11', N'bàn 11', N'banao11', N'banao11', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban12', N'bàn 12', N'banao12', N'banao12', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban13', N'bàn 13', N'banao13', N'banao13', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban14', N'bàn 14', N'banao14', N'banao14', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban15', N'bàn 15', N'banao15', N'banao15', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban16', N'bàn 16', N'banao16', N'banao16', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban17', N'bàn 17', N'banao17', N'banao17', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban18', N'bàn 18', N'banao18', N'banao18', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban19', N'bàn 19', N'banao19', N'banao19', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban20', N'bàn 20', N'banao20', N'banao20', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban21', N'bàn 21', N'banao21', N'banao21', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban22', N'bàn 22', N'banao22', N'banao22', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban23', N'bàn 23', N'banao23', N'banao23', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban24', N'bàn 24', N'banao24', N'banao24', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban25', N'bàn 25', N'banao25', N'banao25', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban26', N'bàn 26', N'banao26', N'banao26', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban27', N'bàn 27', N'banao27', N'banao27', 0)
INSERT [dbo].[BAN] ([Mã bàn], [Tên bàn], [Mã bàn ảo], [Mã bàn ảo chính], [Trạng thái ghép]) VALUES (N'ban28', N'bàn 28', N'banao28', N'banao28', 0)
GO
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao01', N'bàn ghép 1', 0)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao02', N'bàn ghép 2', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao03', N'bàn ghép 3', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao04', N'bàn ghép 4', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao05', N'bàn ghép 5', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao06', N'bàn ghép 6', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao07', N'bàn ghép 7', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao08', N'bàn ghép 8', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao09', N'bàn ghép 9', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao10', N'bàn ghép 10', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao11', N'bàn ghép 11', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao12', N'bàn ghép 12', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao13', N'bàn ghép 13', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao14', N'bàn ghép 14', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao15', N'bàn ghép 15', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao16', N'bàn ghép 16', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao17', N'bàn ghép 17', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao18', N'bàn ghép 18', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao19', N'bàn ghép 19', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao20', N'bàn ghép 20', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao21', N'bàn ghép 21', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao22', N'bàn ghép 22', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao23', N'bàn ghép 23', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao24', N'bàn ghép 24', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao25', N'bàn ghép 25', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao26', N'bàn ghép 26', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao27', N'bàn ghép 27', 1)
INSERT [dbo].[BANAO] ([Mã bàn ảo], [Tên bàn ảo], [Trạng thái]) VALUES (N'banao28', N'bàn ghép 28', 1)
GO
INSERT [dbo].[HOADON] ([Mã hóa đơn], [Mã tài khoản], [Mã bàn ảo], [Ngày tạo], [Trạng thái], [Tổng tiền]) VALUES (N'111', N'nhanvien01', N'banao01', CAST(N'2023-05-14' AS Date), 1, 20000)
INSERT [dbo].[HOADON] ([Mã hóa đơn], [Mã tài khoản], [Mã bàn ảo], [Ngày tạo], [Trạng thái], [Tổng tiền]) VALUES (N'112', N'nhanvien01', N'banao01', CAST(N'2023-05-25' AS Date), 0, 0)
GO
INSERT [dbo].[LOAISANPHAM] ([Mã loại], [Tên loại]) VALUES (N'201', N'Trà')
INSERT [dbo].[LOAISANPHAM] ([Mã loại], [Tên loại]) VALUES (N'202', N'Cà phê')
INSERT [dbo].[LOAISANPHAM] ([Mã loại], [Tên loại]) VALUES (N'203', N'Topping')
GO
INSERT [dbo].[SANPHAM] ([Mã sản phẩm], [Tên sản phẩm], [Mã loại], [Giá]) VALUES (N'101', N'Trà Đào', N'201', 20000)
INSERT [dbo].[SANPHAM] ([Mã sản phẩm], [Tên sản phẩm], [Mã loại], [Giá]) VALUES (N'102', N'Trà sữa', N'201', 25000)
INSERT [dbo].[SANPHAM] ([Mã sản phẩm], [Tên sản phẩm], [Mã loại], [Giá]) VALUES (N'103', N'Cà phê đen', N'202', 12000)
INSERT [dbo].[SANPHAM] ([Mã sản phẩm], [Tên sản phẩm], [Mã loại], [Giá]) VALUES (N'104', N'Capuchino', N'202', 22000)
INSERT [dbo].[SANPHAM] ([Mã sản phẩm], [Tên sản phẩm], [Mã loại], [Giá]) VALUES (N'105', N'Bánh tráng trộn', N'203', 15000)
GO
INSERT [dbo].[TAIKHOAN] ([Mã tài khoản], [Tên tài khoản], [Mật khẩu], [PQ], [Khóa]) VALUES (N'111', N'longtran', N'long27042003', 0, 0)
INSERT [dbo].[TAIKHOAN] ([Mã tài khoản], [Tên tài khoản], [Mật khẩu], [PQ], [Khóa]) VALUES (N'nhanvien01', N'quocmanh', N'manh123', 0, 0)
INSERT [dbo].[TAIKHOAN] ([Mã tài khoản], [Tên tài khoản], [Mật khẩu], [PQ], [Khóa]) VALUES (N'quanly01', N'ngocdan', N'dan123', 1, 0)
GO
INSERT [dbo].[THONGTINTAIKHOAN] ([Mã nhân viên], [Tên nhân viên], [CMND], [SĐT], [Địa chỉ]) VALUES (N'111', N'Trần Ngọc Thanh Long', N'201885768', N'0774531518', N'Hòa Xuân')
INSERT [dbo].[THONGTINTAIKHOAN] ([Mã nhân viên], [Tên nhân viên], [CMND], [SĐT], [Địa chỉ]) VALUES (N'nhanvien01', N'Lê Quốc Mạnh', N'10292222', N'493030292', N'Hòa Khánh 2')
INSERT [dbo].[THONGTINTAIKHOAN] ([Mã nhân viên], [Tên nhân viên], [CMND], [SĐT], [Địa chỉ]) VALUES (N'quanly01', N'Bùi Ngọc Dân', N'293928222', N'122232323', N'Nhơn Thọ I')
GO
ALTER TABLE [dbo].[BAN]  WITH CHECK ADD  CONSTRAINT [FK_BAN_BANAO] FOREIGN KEY([Mã bàn ảo])
REFERENCES [dbo].[BANAO] ([Mã bàn ảo])
GO
ALTER TABLE [dbo].[BAN] CHECK CONSTRAINT [FK_BAN_BANAO]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHOADON_HOADON1] FOREIGN KEY([Mã hóa đơn])
REFERENCES [dbo].[HOADON] ([Mã hóa đơn])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETHOADON_HOADON1]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHOADON_SANPHAM1] FOREIGN KEY([Mã sản phẩm])
REFERENCES [dbo].[SANPHAM] ([Mã sản phẩm])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETHOADON_SANPHAM1]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_BANAO] FOREIGN KEY([Mã bàn ảo])
REFERENCES [dbo].[BANAO] ([Mã bàn ảo])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_BANAO]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_TAIKHOAN] FOREIGN KEY([Mã tài khoản])
REFERENCES [dbo].[TAIKHOAN] ([Mã tài khoản])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_TAIKHOAN]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_LOAISANPHAM] FOREIGN KEY([Mã loại])
REFERENCES [dbo].[LOAISANPHAM] ([Mã loại])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_LOAISANPHAM]
GO
ALTER TABLE [dbo].[THONGTINTAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK_THONGTINTAIKHOAN_TAIKHOAN] FOREIGN KEY([Mã nhân viên])
REFERENCES [dbo].[TAIKHOAN] ([Mã tài khoản])
GO
ALTER TABLE [dbo].[THONGTINTAIKHOAN] CHECK CONSTRAINT [FK_THONGTINTAIKHOAN_TAIKHOAN]
GO
USE [master]
GO
ALTER DATABASE [ppl3] SET  READ_WRITE 
GO
