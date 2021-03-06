USE [master]
GO
/****** Object:  Database [cargo_transportation]    Script Date: 12.05.2022 10:17:04 ******/
CREATE DATABASE [cargo_transportation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cargo_transportation', FILENAME = N'C:\Users\db\cargo_transportation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cargo_transportation_log', FILENAME = N'C:\Users\db\cargo_transportation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [cargo_transportation] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cargo_transportation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cargo_transportation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cargo_transportation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cargo_transportation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cargo_transportation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cargo_transportation] SET ARITHABORT OFF 
GO
ALTER DATABASE [cargo_transportation] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [cargo_transportation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cargo_transportation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cargo_transportation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cargo_transportation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cargo_transportation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cargo_transportation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cargo_transportation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cargo_transportation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cargo_transportation] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cargo_transportation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cargo_transportation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cargo_transportation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cargo_transportation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cargo_transportation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cargo_transportation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cargo_transportation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cargo_transportation] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [cargo_transportation] SET  MULTI_USER 
GO
ALTER DATABASE [cargo_transportation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cargo_transportation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cargo_transportation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cargo_transportation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cargo_transportation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [cargo_transportation] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [cargo_transportation] SET QUERY_STORE = OFF
GO
USE [cargo_transportation]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fio] [nvarchar](300) NULL,
	[phone] [nvarchar](13) NOT NULL,
	[password] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NOT NULL,
	[price] [int] NOT NULL,
	[car] [int] NOT NULL,
	[user] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UsersOrders]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[UsersOrders]
as
select "User".fio as UserFIO, "User".phone as Contact,
"Order".car as Car,"Order".price as Price, "Order".date as Date
from "User" inner join "Order" on "User".id = "Order"."user"
GO
/****** Object:  Table [dbo].[Transport]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transport](
	[StateNum] [nvarchar](10) NOT NULL,
	[automodel] [nvarchar](50) NOT NULL,
	[fuel] [int] NOT NULL,
	[capacity] [int] NOT NULL,
	[length] [int] NOT NULL,
	[busy] [tinyint] NOT NULL,
	[kind] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Transport] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarType]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CarType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CarsKind]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[CarsKind]
as
select Statenum as CarNumber, CarType."name" as Type
from Transport inner join CarType on Transport.kind = CarType.id
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[id] [int] NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Arend]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arend](
	[id] [int] NOT NULL,
	[start] [datetime] NOT NULL,
	[end] [datetime] NOT NULL,
 CONSTRAINT [PK_Arend] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cargoType]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cargoType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_cargoType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drivers](
	[id] [int] NOT NULL,
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Moving]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moving](
	[id] [int] NOT NULL,
	[import] [nvarchar](300) NOT NULL,
	[export] [nvarchar](300) NOT NULL,
	[loader] [smallint] NULL,
	[furniture] [tinyint] NULL,
	[pack] [tinyint] NULL,
	[driver] [int] NULL,
 CONSTRAINT [PK_Moving] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transportation]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transportation](
	[id] [int] NOT NULL,
	[import] [nvarchar](300) NOT NULL,
	[export] [nvarchar](300) NOT NULL,
	[amount] [int] NOT NULL,
	[loader] [smallint] NULL,
	[driver] [int] NULL,
	[cargoType] [int] NOT NULL,
 CONSTRAINT [PK_Transportation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Admins]  WITH CHECK ADD  CONSTRAINT [FK_Admins_User] FOREIGN KEY([id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Admins] CHECK CONSTRAINT [FK_Admins_User]
GO
ALTER TABLE [dbo].[Arend]  WITH CHECK ADD  CONSTRAINT [FK_Arend_Order] FOREIGN KEY([id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Arend] CHECK CONSTRAINT [FK_Arend_Order]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_User] FOREIGN KEY([id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_User]
GO
ALTER TABLE [dbo].[Drivers]  WITH CHECK ADD  CONSTRAINT [FK_Drivers_User] FOREIGN KEY([id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Drivers] CHECK CONSTRAINT [FK_Drivers_User]
GO
ALTER TABLE [dbo].[Moving]  WITH CHECK ADD  CONSTRAINT [FK_Moving_Drivers] FOREIGN KEY([driver])
REFERENCES [dbo].[Drivers] ([id])
GO
ALTER TABLE [dbo].[Moving] CHECK CONSTRAINT [FK_Moving_Drivers]
GO
ALTER TABLE [dbo].[Moving]  WITH CHECK ADD  CONSTRAINT [FK_Moving_Order] FOREIGN KEY([id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Moving] CHECK CONSTRAINT [FK_Moving_Order]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client] FOREIGN KEY([user])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Client]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Transport] FOREIGN KEY([car])
REFERENCES [dbo].[Transport] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Transport]
GO
ALTER TABLE [dbo].[Transport]  WITH CHECK ADD  CONSTRAINT [FK_Transport_CarType] FOREIGN KEY([kind])
REFERENCES [dbo].[CarType] ([id])
GO
ALTER TABLE [dbo].[Transport] CHECK CONSTRAINT [FK_Transport_CarType]
GO
ALTER TABLE [dbo].[Transportation]  WITH CHECK ADD  CONSTRAINT [FK_Transportation_cargoType] FOREIGN KEY([cargoType])
REFERENCES [dbo].[cargoType] ([id])
GO
ALTER TABLE [dbo].[Transportation] CHECK CONSTRAINT [FK_Transportation_cargoType]
GO
ALTER TABLE [dbo].[Transportation]  WITH CHECK ADD  CONSTRAINT [FK_Transportation_Drivers] FOREIGN KEY([driver])
REFERENCES [dbo].[Drivers] ([id])
GO
ALTER TABLE [dbo].[Transportation] CHECK CONSTRAINT [FK_Transportation_Drivers]
GO
ALTER TABLE [dbo].[Transportation]  WITH CHECK ADD  CONSTRAINT [FK_Transportation_Order] FOREIGN KEY([id])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[Transportation] CHECK CONSTRAINT [FK_Transportation_Order]
GO
/****** Object:  StoredProcedure [dbo].[ResetAllCars]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ResetAllCars] as
begin
update Transport set busy = 0 
end;
GO
/****** Object:  StoredProcedure [dbo].[TotalSum]    Script Date: 12.05.2022 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[TotalSum] as
begin
declare @summa int

set @summa = (select SUM(price) from "Order")

print @summa * 0.20

end;
GO
USE [master]
GO
ALTER DATABASE [cargo_transportation] SET  READ_WRITE 
GO
