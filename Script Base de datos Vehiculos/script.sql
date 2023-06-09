USE [master]
GO
/****** Object:  Database [BDVehiculos]    Script Date: 17/05/2023 14:08:34 ******/
CREATE DATABASE [BDVehiculos] ON  PRIMARY 
( NAME = N'BDVehiculos', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\BDVehiculos.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BDVehiculos_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\BDVehiculos_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BDVehiculos] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDVehiculos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDVehiculos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDVehiculos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDVehiculos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDVehiculos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDVehiculos] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDVehiculos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDVehiculos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDVehiculos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDVehiculos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDVehiculos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDVehiculos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDVehiculos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDVehiculos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDVehiculos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDVehiculos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDVehiculos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDVehiculos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDVehiculos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDVehiculos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDVehiculos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDVehiculos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDVehiculos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDVehiculos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDVehiculos] SET  MULTI_USER 
GO
ALTER DATABASE [BDVehiculos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDVehiculos] SET DB_CHAINING OFF 
GO
USE [BDVehiculos]
GO
/****** Object:  Table [dbo].[Combustible]    Script Date: 17/05/2023 14:08:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Combustible](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Combustible] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 17/05/2023 14:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[id] [int] NULL,
	[idVehiculo] [int] NULL,
	[monto] [int] NULL,
	[cantidad] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Marca]    Script Date: 17/05/2023 14:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marca](
	[id] [int] NULL,
	[nombre] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Modelo]    Script Date: 17/05/2023 14:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Modelo](
	[id] [int] NULL,
	[nombre] [varchar](50) NULL,
	[idMarca] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoVehiculo]    Script Date: 17/05/2023 14:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoVehiculo](
	[id] [int] NULL,
	[nombre] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 17/05/2023 14:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[patente] [varchar](50) NULL,
	[idTipo] [int] NULL,
	[idModelo] [int] NULL,
	[combustible] [varchar](50) NULL,
	[stock] [int] NULL,
	[fecha] [date] NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 17/05/2023 14:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[id] [int] NULL,
	[fecha] [date] NULL,
	[idDetalle] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[VistaVehiculos]    Script Date: 17/05/2023 14:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VistaVehiculos]
as
select v.patente, tv.nombre as 'Tipo', m.nombre as 'Modelo', ma.nombre as 'Marca'
from vehiculo v join TipoVehiculo tv on v.idTipo = tv.id join Modelo m on v.idModelo = m.id join Marca ma on ma.id = m.idMarca

GO
/****** Object:  View [dbo].[VistaVehiculosLista]    Script Date: 17/05/2023 14:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VistaVehiculosLista]
as
select v.id, v.patente, v.idTipo, tv.nombre as 'TipoVehiculo', v.idModelo, mo.nombre as 'Modelo', ma.id as 'IdMarca', ma.nombre as 'Marca', v.combustible, v.stock, v.fecha
from Vehiculo v join TipoVehiculo tv on v.idTipo = tv.id join Modelo mo on v.idModelo = mo.id join Marca ma on mo.idMarca = ma.id

GO
SET IDENTITY_INSERT [dbo].[Combustible] ON 

INSERT [dbo].[Combustible] ([id], [nombre]) VALUES (1, N'Nafta comun')
INSERT [dbo].[Combustible] ([id], [nombre]) VALUES (2, N'Nafta super')
INSERT [dbo].[Combustible] ([id], [nombre]) VALUES (3, N'Gasoil comun')
SET IDENTITY_INSERT [dbo].[Combustible] OFF
INSERT [dbo].[DetalleVenta] ([id], [idVehiculo], [monto], [cantidad]) VALUES (1, 1, 40000, 1)
INSERT [dbo].[DetalleVenta] ([id], [idVehiculo], [monto], [cantidad]) VALUES (2, 3, 500000, 1)
INSERT [dbo].[DetalleVenta] ([id], [idVehiculo], [monto], [cantidad]) VALUES (3, 5, 90000, 1)
INSERT [dbo].[DetalleVenta] ([id], [idVehiculo], [monto], [cantidad]) VALUES (4, 3, 350000, 1)
INSERT [dbo].[DetalleVenta] ([id], [idVehiculo], [monto], [cantidad]) VALUES (5, 1, 60000, 2)
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (1, N'Chevrolet')
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (2, N'Renault')
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (3, N'Ford')
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (4, N'Peugeot')
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (5, N'Fiat')
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (6, N'VW')
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (7, N'BMW')
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (8, N'Mercedes')
INSERT [dbo].[Modelo] ([id], [nombre], [idMarca]) VALUES (1, N'Agile', 1)
INSERT [dbo].[Modelo] ([id], [nombre], [idMarca]) VALUES (2, N'Onix', 1)
INSERT [dbo].[Modelo] ([id], [nombre], [idMarca]) VALUES (3, N'Clio', 2)
INSERT [dbo].[Modelo] ([id], [nombre], [idMarca]) VALUES (4, N'Focus', 3)
INSERT [dbo].[Modelo] ([id], [nombre], [idMarca]) VALUES (5, N'307', 4)
INSERT [dbo].[Modelo] ([id], [nombre], [idMarca]) VALUES (6, N'Tracker', 1)
INSERT [dbo].[TipoVehiculo] ([id], [nombre]) VALUES (1, N'Auto')
INSERT [dbo].[TipoVehiculo] ([id], [nombre]) VALUES (2, N'Camioneta')
INSERT [dbo].[TipoVehiculo] ([id], [nombre]) VALUES (3, N'Camión')
INSERT [dbo].[TipoVehiculo] ([id], [nombre]) VALUES (4, N'Moto')
INSERT [dbo].[TipoVehiculo] ([id], [nombre]) VALUES (5, N'Avión')
SET IDENTITY_INSERT [dbo].[Vehiculo] ON 

INSERT [dbo].[Vehiculo] ([id], [patente], [idTipo], [idModelo], [combustible], [stock], [fecha]) VALUES (21, N'AAA111', 1, 1, N'Gasoil', 11, CAST(N'2021-01-11' AS Date))
INSERT [dbo].[Vehiculo] ([id], [patente], [idTipo], [idModelo], [combustible], [stock], [fecha]) VALUES (23, N'AD195BD', 2, 6, N'Nafta', 4, CAST(N'2018-06-09' AS Date))
INSERT [dbo].[Vehiculo] ([id], [patente], [idTipo], [idModelo], [combustible], [stock], [fecha]) VALUES (24, N'AE496FT', 1, 3, N'Nafta', 4, CAST(N'2023-05-11' AS Date))
INSERT [dbo].[Vehiculo] ([id], [patente], [idTipo], [idModelo], [combustible], [stock], [fecha]) VALUES (25, N'AF985MP', 2, 1, N'Gas', 68, CAST(N'2023-05-10' AS Date))
SET IDENTITY_INSERT [dbo].[Vehiculo] OFF
INSERT [dbo].[Venta] ([id], [fecha], [idDetalle]) VALUES (1, CAST(N'2022-09-20' AS Date), 1)
INSERT [dbo].[Venta] ([id], [fecha], [idDetalle]) VALUES (1, CAST(N'2022-09-20' AS Date), 2)
INSERT [dbo].[Venta] ([id], [fecha], [idDetalle]) VALUES (1, CAST(N'2022-09-20' AS Date), 3)
INSERT [dbo].[Venta] ([id], [fecha], [idDetalle]) VALUES (2, CAST(N'2022-09-18' AS Date), 4)
INSERT [dbo].[Venta] ([id], [fecha], [idDetalle]) VALUES (2, CAST(N'2022-09-18' AS Date), 5)
/****** Object:  StoredProcedure [dbo].[VehiculoPorId]    Script Date: 17/05/2023 14:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[VehiculoPorId]
@idVehiculo int
as
begin
set nocount on
select *
from vehiculo
where id = @idVehiculo
end

GO
/****** Object:  StoredProcedure [dbo].[VehiculosPorStockMenor]    Script Date: 17/05/2023 14:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[VehiculosPorStockMenor]
@StockMenor int
as
begin
set nocount on;
select *
from vehiculo
where stock < @StockMenor
end

GO
/****** Object:  StoredProcedure [dbo].[VehiculosPorTipo]    Script Date: 17/05/2023 14:08:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[VehiculosPorTipo]
@Tipo int
as
begin
set nocount on
select v.patente, tv.nombre
from Vehiculo v join TipoVehiculo tv on v.idTipo = tv.id
where v.idTipo = @Tipo
end

GO
USE [master]
GO
ALTER DATABASE [BDVehiculos] SET  READ_WRITE 
GO
