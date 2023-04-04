/****** Object:  Database [Quan_Ly_Kinh_Doanh_Trang_Suc]    Script Date: 4/4/2023 11:22:34 PM ******/
CREATE DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Quan_Ly_Kinh_Doanh_Trang_Suc', FILENAME = N'E:\Database\Quan_Ly_Kinh_Doanh_Trang_Suc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Quan_Ly_Kinh_Doanh_Trang_Suc_log', FILENAME = N'E:\Database\Quan_Ly_Kinh_Doanh_Trang_Suc_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Quan_Ly_Kinh_Doanh_Trang_Suc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET ARITHABORT OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET RECOVERY FULL 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET  MULTI_USER 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Quan_Ly_Kinh_Doanh_Trang_Suc', N'ON'
GO
ALTER DATABASE [Quan_Ly_Kinh_Doanh_Trang_Suc] SET  READ_WRITE 
GO
