USE [GD2C2019]
GO


/* Limpiar todo */

-- Eliminar FKs
DECLARE @SQL varchar(4000)=''
SELECT @SQL = 
@SQL + 'ALTER TABLE ' + s.name +'.'+ t.name + ' DROP CONSTRAINT [' + RTRIM(f.name) +'];' + CHAR(13)
FROM sys.Tables t
INNER JOIN sys.foreign_keys f ON f.parent_object_id = t.object_id
INNER JOIN sys.schemas     s ON s.schema_id = f.schema_id
EXEC (@SQL)

-- Drop tablas
IF OBJECT_ID('[Cupones2C2019].Cupon', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Cupon];
IF OBJECT_ID('[Cupones2C2019].Compra', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Compra];
IF OBJECT_ID('[Cupones2C2019].Entrega', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Entrega];
IF OBJECT_ID('[Cupones2C2019].Oferta', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Oferta];
IF OBJECT_ID('[Cupones2C2019].Datos_Tarjeta', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Datos_Tarjeta];
IF OBJECT_ID('[Cupones2C2019].Carga', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Carga];
IF OBJECT_ID('[Cupones2C2019].Tipo_Pago', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Tipo_Pago];
IF OBJECT_ID('[Cupones2C2019].Facturacion', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Facturacion];
IF OBJECT_ID('[Cupones2C2019].Proveedor', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Proveedor];
IF OBJECT_ID('[Cupones2C2019].Cliente', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Cliente];
IF OBJECT_ID('[Cupones2C2019].Rol_Usuario', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Rol_Usuario];
IF OBJECT_ID('[Cupones2C2019].Rol_Funcionalidad', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Rol_Funcionalidad];
IF OBJECT_ID('[Cupones2C2019].Funcionalidad', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Funcionalidad];
IF OBJECT_ID('[Cupones2C2019].Rol', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Rol];
IF OBJECT_ID('[Cupones2C2019].Usuario', 'U') IS NOT NULL DROP TABLE [Cupones2C2019].[Usuario];


/* Esquema */

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Cupones2C2019')
BEGIN
	EXEC ('CREATE SCHEMA [Cupones2C2019] AUTHORIZATION gdCupon2019')
END
GO


/* Creacion tablas */

CREATE TABLE [Cupones2C2019].[Funcionalidad](
    [id] [numeric](18, 0) IDENTITY,
	[descripcion] [varchar](255) NOT NULL,
    PRIMARY KEY (id)
)
GO

CREATE TABLE [Cupones2C2019].[Rol](
    [id] [numeric](18,0) IDENTITY,
    [nombre] [varchar](255) NOT NULL,
    habilitado [bit] NOT NULL DEFAULT 1,
    PRIMARY KEY (id)
)
GO

CREATE TABLE [Cupones2C2019].[Rol_Funcionalidad](
    [id_rol] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Rol(id),
    [id_func] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Funcionalidad(id),
    PRIMARY KEY (id_func, id_rol)
)
GO

CREATE TABLE [Cupones2C2019].[Usuario](
    [id] [numeric](18,0) IDENTITY,
    [username] [varchar](255) UNIQUE NOT NULL,
    [password] [varchar](255) NOT NULL,
    [intentos_fallidos] [tinyint] NOT NULL DEFAULT 0,
    [habilitado] [bit] NOT NULL DEFAULT 1,
    PRIMARY KEY (id),
)
GO

CREATE TABLE [Cupones2C2019].[Rol_Usuario](
    [id_rol] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Rol(id),
    [id_usuario] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Usuario(id),
    PRIMARY KEY (id_rol, id_usuario),
)
GO

CREATE TABLE [Cupones2C2019].[Cliente](
    [id] [numeric](18,0) IDENTITY,
    [id_usuario] [numeric](18,0) FOREIGN KEY REFERENCES [Cupones2C2019].Usuario(id),
    [nombre] [varchar](255) NOT NULL,
    [apellido] [varchar](255) NOT NULL,
    [dni] [numeric](18,0) UNIQUE NOT NULL,
    [telefono] [numeric](18,0) NOT NULL,
    [mail] [varchar](255) NOT NULL, -- hay mails repetidos.
    [direccion] [varchar](255) NOT NULL,
    [ciudad] [varchar](255) NOT NULL,
    [cod_postal] [smallint],
    [fecha_nac] [datetime] NOT NULL,
    [saldo] [numeric](18,2) NOT NULL DEFAULT 0,
    [habilitado] [bit] NOT NULL DEFAULT 1, -- 1 habilitado, 0 inhabilitado
    PRIMARY KEY (id)
)
GO

CREATE TABLE [Cupones2C2019].[Proveedor](
    [cuit] [char](13),
    [razon_soc] [varchar](255) UNIQUE NOT NULL,
    [id_usuario] [numeric](18,0) FOREIGN KEY REFERENCES [Cupones2C2019].Usuario(id),
    [nombre_contacto] [varchar](255), -- no hay información en tabla maestra. Queda como NULL si es migrado, pero verificar en FE.
    [rubro] [varchar](255) NOT NULL,
    [telefono] [numeric](18,0) NOT NULL,
    [mail] [varchar](255), -- no hay información en tabla maestra. Queda como NULL si es migrado, pero verificar en FE.
    [direccion] [varchar](255) NOT NULL,
    [ciudad] [varchar](255) NOT NULL,
    [cod_postal] [smallint], -- no hay información en tabla maestra. Queda como NULL si es migrado, pero verificar en FE.
    [habilitado] [bit] NOT NULL DEFAULT 1, -- 1 habilitado, 0 inhabilitado
    PRIMARY KEY (cuit)
)
GO

CREATE TABLE [Cupones2C2019].[Facturacion](
    [numero_factura] [numeric](18,0),
    [fecha_desde] [datetime] NOT NULL,
    [fecha_hasta] [datetime] NOT NULL,
    [cuit_proveedor] [char](13) NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Proveedor(cuit),
    [total] [numeric](18,2) NOT NULL,
    PRIMARY KEY (numero_factura)
)
GO

CREATE TABLE [Cupones2C2019].[Tipo_Pago](
    [id] [tinyint] IDENTITY,
    [descripcion] [varchar](255) NOT NULL,
    PRIMARY KEY (id)
)
GO

CREATE TABLE [Cupones2C2019].[Carga](
    [id] [numeric](18,0) IDENTITY,
    [id_cliente] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Cliente(id),
    [id_tipoPago] [tinyint] NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Tipo_Pago(id),
    [fecha] [datetime] NOT NULL,
    [monto] [numeric](18,2) NOT NULL,
    PRIMARY KEY (id)
)
GO


CREATE TABLE [Cupones2C2019].[Datos_Tarjeta](
    [id] [numeric](18,0) IDENTITY,
    [id_tipoPago] [tinyint] NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Tipo_Pago(id),
    [numero] [numeric](18,0) NOT NULL,
    [nombre] [varchar](255) NOT NULL,
    PRIMARY KEY (id)
)
GO

CREATE TABLE [Cupones2C2019].[Oferta](
    [id] [numeric](18,0) IDENTITY,
    [cuit_prov] [char](13) NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Proveedor(cuit),
    [codigo] [varchar](255) NOT NULL,
    [descripcion] [varchar](255) NOT NULL,
    [fec_public] [datetime] NOT NULL,
    [fec_venc] [datetime] NOT NULL,
    [precio_oferta] [numeric](18,2) NOT NULL,
    [precio_lista] [numeric](18,2) NOT NULL,
    [cantidad_disponible] [int] NOT NULL,
    [max_por_cliente] [int] NOT NULL,
    PRIMARY KEY (id)
)
GO

CREATE TABLE [Cupones2C2019].[Cupon](
    [codigo_cupon] [numeric](18,0),
    [id_oferta] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Oferta(id),
    [cod_compra] [numeric](18,0) NOT NULL,
    [id_entrega] [numeric](18,0), -- puede haber cupon sin entregar aun
    [fecha_vencimiento] [datetime] NOT NULL,
    [cantidad] [int] NOT NULL,
    PRIMARY KEY (codigo_cupon)
)
GO

CREATE TABLE [Cupones2C2019].[Entrega](
    [id] [numeric](18,0) IDENTITY,
    [fecha_consumo] [datetime] NOT NULL,
    [cupon] [numeric](18,0) UNIQUE NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Cupon(codigo_cupon),
    [id_cliente] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Cliente(id),
    PRIMARY KEY (id)
)
GO

CREATE TABLE [Cupones2C2019].[Compra](
    [codigo_compra] [numeric](18,0) IDENTITY,
    [id_cliente_compra] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Cliente(id),
    [cod_cupon] [numeric](18,0) UNIQUE NOT NULL FOREIGN KEY REFERENCES [Cupones2C2019].Cupon(codigo_cupon),
    [fecha_compra] [datetime] NOT NULL,
    PRIMARY KEY (codigo_compra)
)
GO




-- Agregar FK faltantes de Cupon (no se puede al crear la tabla porque no existen las otras tablas)
ALTER TABLE [Cupones2C2019].Cupon ADD FOREIGN KEY (cod_compra) REFERENCES [Cupones2C2019].Compra(codigo_compra) 
ALTER TABLE [Cupones2C2019].Cupon ADD FOREIGN KEY (id_entrega) REFERENCES [Cupones2C2019].Entrega(id)


/* Migracion */

-- Roles
INSERT INTO [Cupones2C2019].Rol(nombre)
VALUES ('Administrador'), ('Cliente'), ('Proveedor')
GO

-- Funcionalidades
INSERT INTO [Cupones2C2019].Funcionalidad(descripcion)
VALUES ('ABM_Rol'), ('ABM_Cliente'), ('ABM_Proveedor'), ('Carga_Credito'), ('Confeccionar_Oferta'), ('Comprar_Oferta'), ('Consumir_Oferta'), ('Facturacion') 
GO

-- Funcionalidades por Rol
-- Administrador puede: todo
INSERT INTO [Cupones2C2019].Rol_Funcionalidad(id_rol, id_func)
SELECT 1, id FROM [Cupones2C2019].Funcionalidad 
GO
-- Cliente puede: cargar credito y comprar oferta
INSERT INTO [Cupones2C2019].Rol_Funcionalidad(id_rol, id_func)
SELECT 2, id FROM [Cupones2C2019].Funcionalidad
WHERE descripcion IN ('Carga_Credito', 'Comprar_Oferta')
GO
-- Proveedor puede:
INSERT INTO [Cupones2C2019].Rol_Funcionalidad(id_rol, id_func)
SELECT 3, id FROM [Cupones2C2019].Funcionalidad
WHERE descripcion IN ('Confeccionar_Oferta', 'Consumir_Oferta', 'Facturacion')
GO

-- Usuarios
INSERT INTO [Cupones2C2019].Usuario(username, password)
VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'))
GO

-- Rol por Usuario
INSERT INTO [Cupones2C2019].Rol_Usuario(id_rol, id_usuario)
VALUES ((SELECT id FROM [Cupones2C2019].Rol WHERE nombre = 'Administrador'), (SELECT id FROM [Cupones2C2019].Usuario WHERE username = 'admin'))
GO


-- Migrar Clientes. El CP NULL indicará que es un dato migrado (controlar en FE) ya que no es un dato en tabla maestra.
INSERT INTO [Cupones2C2019].Cliente(
    nombre,
    apellido,
    dni,
    telefono,
    mail,
    direccion,
    ciudad,
    fecha_nac
) 
SELECT DISTINCT
    Cli_Nombre,
	Cli_Apellido,
    Cli_Dni,
    Cli_Telefono,
    Cli_Mail,
    Cli_Direccion,
    Cli_Ciudad,
    Cli_Fecha_Nac
FROM GD2C2019.gd_esquema.Maestra
GO


-- Migrar Proveedores. nombre_contacto, mail y codigo postal vacios en tabla maestra.
INSERT INTO [Cupones2C2019].Proveedor(
    cuit,
    razon_soc,
    rubro,
    telefono,
    direccion,
    ciudad
)
SELECT DISTINCT 
    Provee_CUIT,
    Provee_RS,
    Provee_Rubro,
    Provee_Telefono,
    Provee_Dom,
    Provee_Ciudad 
FROM gd_esquema.Maestra
WHERE Provee_CUIT IS NOT NULL
GO

-- Cargar Tipo de Pagos
INSERT INTO [Cupones2C2019].Tipo_Pago(descripcion)
VALUES ('Débito'), ('Crédito'), ('Efectivo')
GO

-- Migrar Cargas (Todas las hizo el mismo cliente)
INSERT INTO [Cupones2C2019].Carga(
    id_cliente,
    fecha,
    monto,
    id_tipoPago
) SELECT 
    (SELECT id FROM [Cupones2C2019].Cliente WHERE dni = (SELECT DISTINCT Cli_Dni FROM gd_esquema.Maestra WHERE Carga_Credito IS NOT NULL)) AS id_cliente,
    Carga_Fecha,
    Carga_Credito,
    (SELECT id FROM [Cupones2C2019].Tipo_Pago WHERE descripcion = Tipo_Pago_Desc) AS id_tipoPago
FROM gd_esquema.Maestra
WHERE Carga_Credito IS NOT NULL
GO



-- Actualizar saldo del unico cliente que realizo cargas - VER

-- Migrar Facturación

-- Migrar Entregas








-- Stored Procedures / Triggers / Funciones
