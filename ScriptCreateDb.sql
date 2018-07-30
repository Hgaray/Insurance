USE [dbInsurance]
GO
/****** Object:  Table [dbo].[ClientePoliza]    Script Date: 30/07/2018 10:21:31 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientePoliza](
	[IdClientePoliza] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[IdPoliza] [int] NULL,
	[IdEstado] [int] NULL,
	[PorcentajeCobertura] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdClientePoliza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 30/07/2018 10:21:31 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](100) NULL,
	[Apellidos] [varchar](100) NULL,
	[IdTipoDocumento] [int] NULL,
	[Identificacion] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Poliza]    Script Date: 30/07/2018 10:21:31 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Poliza](
	[IdPoliza] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Descripcion] [varchar](500) NULL,
	[IdTipoCubrimiento] [int] NULL,
	[FechaInicio] [date] NULL,
	[MesesCobertura] [int] NULL,
	[ValorPoliza] [int] NULL,
	[IdTipoRiesgo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPoliza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ClientePoliza]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[ClientePoliza]  WITH CHECK ADD FOREIGN KEY([IdPoliza])
REFERENCES [dbo].[Poliza] ([IdPoliza])
GO
