USE [GD2C2019]
GO
/****** Object:  Table [gd_esquema].[Maestra]    Script Date: 09/09/2019 1:43:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Maestra](
	[Cli_Nombre] [nvarchar](255) NULL,
	[Cli_Apellido] [nvarchar](255) NULL,
	[Cli_Dni] [numeric](18, 0) NULL,
	[Cli_Direccion] [nvarchar](255) NULL,
	[Cli_Telefono] [numeric](18, 0) NULL,
	[Cli_Mail] [nvarchar](255) NULL,
	[Cli_Fecha_Nac] [datetime] NULL,
	[Cli_Ciudad] [nvarchar](255) NULL,
	[Carga_Credito] [numeric](18, 2) NULL,
	[Carga_Fecha] [datetime] NULL,
	[Tipo_Pago_Desc] [nvarchar](100) NULL,
	[Cli_Dest_Nombre] [nvarchar](255) NULL,
	[Cli_Dest_Apellido] [nvarchar](255) NULL,
	[Cli_Dest_Dni] [numeric](18, 0) NULL,
	[Cli_Dest_Direccion] [nvarchar](255) NULL,
	[Cli_Dest_Telefono] [numeric](18, 0) NULL,
	[Cli_Dest_Mail] [nvarchar](255) NULL,
	[Cli_Dest_Fecha_Nac] [datetime] NULL,
	[Cli_Dest_Ciudad] [nvarchar](255) NULL,
	[Provee_RS] [nvarchar](100) NULL,
	[Provee_Dom] [nvarchar](100) NULL,
	[Provee_Ciudad] [nvarchar](255) NULL,
	[Provee_Telefono] [numeric](18, 0) NULL,
	[Provee_CUIT] [nvarchar](20) NULL,
	[Provee_Rubro] [nvarchar](100) NULL,
	[Oferta_Precio] [numeric](18, 2) NULL,
	[Oferta_Precio_Ficticio] [numeric](18, 2) NULL,
	[Oferta_Fecha] [datetime] NULL,
	[Oferta_Fecha_Venc] [datetime] NULL,
	[Oferta_Cantidad] [numeric](18, 0) NULL,
	[Oferta_Descripcion] [nvarchar](255) NULL,
	[Oferta_Fecha_Compra] [datetime] NULL,
	[Oferta_Codigo] [nvarchar](50) NULL,
	[Oferta_Entregado_Fecha] [datetime] NULL,
	[Factura_Nro] [numeric](18, 0) NULL,
	[Factura_Fecha] [datetime] NULL
) ON [PRIMARY]

GO
