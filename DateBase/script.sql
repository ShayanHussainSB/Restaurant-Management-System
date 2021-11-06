USE [master]
GO
/****** Object:  Database [Restaurant_Management_System]    Script Date: 23/05/2019 11:34:50 PM ******/
CREATE DATABASE [Restaurant_Management_System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Restaurant_Management_System', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Restaurant_Management_System.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Restaurant_Management_System_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Restaurant_Management_System_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Restaurant_Management_System] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Restaurant_Management_System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Restaurant_Management_System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Restaurant_Management_System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Restaurant_Management_System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Restaurant_Management_System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Restaurant_Management_System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET RECOVERY FULL 
GO
ALTER DATABASE [Restaurant_Management_System] SET  MULTI_USER 
GO
ALTER DATABASE [Restaurant_Management_System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Restaurant_Management_System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Restaurant_Management_System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Restaurant_Management_System] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Restaurant_Management_System] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Restaurant_Management_System', N'ON'
GO
USE [Restaurant_Management_System]
GO
/****** Object:  Table [dbo].[Day_Details]    Script Date: 23/05/2019 11:34:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Day_Details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Todays_Selling] [varchar](50) NOT NULL,
	[Generated_Recipt] [varchar](50) NOT NULL,
	[Date] [varchar](50) NOT NULL,
	[Time_of_reset] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee_signup]    Script Date: 23/05/2019 11:34:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee_signup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Date_Of_Birth] [datetime] NOT NULL,
	[Passward] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[User_Type] [varchar](50) NOT NULL,
	[Contact] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Employee_signup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 23/05/2019 11:34:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Product_Id] [int] IDENTITY(1,1) NOT NULL,
	[Product_Name] [varchar](50) NOT NULL,
	[Product_Price] [int] NOT NULL,
	[Product_Category] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recipts]    Script Date: 23/05/2019 11:34:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recipts](
	[Recipt_Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Name] [varchar](50) NOT NULL,
	[Total_Price] [int] NOT NULL,
	[Recipt_Date] [varchar](50) NOT NULL,
	[Recipt_Time] [varchar](50) NOT NULL,
	[Recipt] [varchar](1000) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [Restaurant_Management_System] SET  READ_WRITE 
GO
