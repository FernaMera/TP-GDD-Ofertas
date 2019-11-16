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
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Cupon', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Cupon];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Compra', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Compra];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Entrega', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Entrega];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Oferta', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Oferta];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Datos_Tarjeta', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Datos_Tarjeta];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Carga', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Carga];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Tipo_Pago', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Tipo_Pago];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Facturacion', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Facturacion];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Proveedor', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Proveedor];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Cliente', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Cliente];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Rol_Usuario', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Rol_Usuario];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Rol_Funcionalidad', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Rol_Funcionalidad];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Funcionalidad', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Funcionalidad];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Rol', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Rol];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Usuario', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Usuario];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Rubro', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Rubro];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].Detalle_Facturacion', 'U') IS NOT NULL DROP TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Detalle_Facturacion];

-- Drop SP
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].sp_validar_login', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[sp_validar_login];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].nuevo_usuario', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[nuevo_usuario];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].cambiar_contrasena', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[cambiar_contrasena];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].nuevo_rol_usuario', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[nuevo_rol_usuario];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].nuevo_rol', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[nuevo_rol];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].agregar_funcionalidad', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[agregar_funcionalidad];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].quitar_funcionalidad', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[quitar_funcionalidad];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].mod_rol', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[mod_rol];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].habilitar_rol', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[habilitar_rol];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].eliminar_rol', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[eliminar_rol];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].nuevo_cliente', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[nuevo_cliente];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].mod_cliente', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[mod_cliente];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].nueva_carga_tarjeta', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[nueva_carga_tarjeta];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].nueva_carga_efectivo', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[nueva_carga_efectivo];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].nueva_compra', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[nueva_compra];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].consumir_oferta', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[consumir_oferta];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].sp_facturar', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[sp_facturar];

-- Drop Funciones
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].ofertas_disponibles', 'TF') IS NOT NULL DROP FUNCTION [SELECT_THISGROUP_FROM_APROBADOS].[ofertas_disponibles];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].cupones_proveedor', 'TF') IS NOT NULL DROP FUNCTION [SELECT_THISGROUP_FROM_APROBADOS].[cupones_proveedor];

-- Drop Triggers
IF OBJECT_ID('tr_actualizarTotalFactura') IS NOT NULL DROP TRIGGER [SELECT_THISGROUP_FROM_APROBADOS].[tr_actualizarTotalFactura];

/* Esquema */

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'SELECT_THISGROUP_FROM_APROBADOS')
BEGIN
	EXEC ('CREATE SCHEMA [SELECT_THISGROUP_FROM_APROBADOS] AUTHORIZATION gdCupon2019')
END
GO


/* Creacion tablas */

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Funcionalidad](
    [id] [numeric](18, 0) IDENTITY,
	[descripcion] [varchar](255) NOT NULL,
    PRIMARY KEY (id)
)
GO

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Rol](
    [id] [numeric](18,0) IDENTITY,
    [nombre] [varchar](255) NOT NULL,
    habilitado [bit] NOT NULL DEFAULT 1,
    PRIMARY KEY (id)
)
GO

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Rol_Funcionalidad](
    [id_rol] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Rol(id),
    [id_func] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Funcionalidad(id),
    PRIMARY KEY (id_func, id_rol)
)
GO

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Usuario](
    [id] [numeric](18,0) IDENTITY,
    [username] [varchar](255) UNIQUE NOT NULL,
    [password] [varchar](255) NOT NULL,
    [intentos_fallidos] [tinyint] NOT NULL DEFAULT 0,
    [habilitado] [bit] NOT NULL DEFAULT 1,
    PRIMARY KEY (id),
)
GO

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Rol_Usuario](
    [id_rol] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Rol(id),
    [id_usuario] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Usuario(id),
    PRIMARY KEY (id_rol, id_usuario),
)
GO

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Cliente](
    [id] [numeric](18,0) IDENTITY,
    [id_usuario] [numeric](18,0) FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Usuario(id),
    [nombre] [varchar](255) NOT NULL,
    [apellido] [varchar](255) NOT NULL,
    [dni] [numeric](18,0) UNIQUE NOT NULL,
    [telefono] [numeric](18,0) NOT NULL,
    [mail] [varchar](255) NOT NULL, -- hay mails repetidos.
    [direccion] [varchar](255) NOT NULL,
    [ciudad] [varchar](255) NOT NULL,
    [cod_postal] [smallint],
    [fecha_nac] [datetime] NOT NULL,
    [saldo] [numeric](18,2) NOT NULL DEFAULT 0 CHECK ([saldo] >= 0),
    [habilitado] [bit] NOT NULL DEFAULT 1, -- 1 habilitado, 0 inhabilitado
    PRIMARY KEY (id)
)
GO

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Rubro](
    [id] [numeric](18,0) IDENTITY,
    [descripcion] [varchar](255) UNIQUE NOT NULL,
    PRIMARY KEY (id)
)
GO

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Proveedor](
    [cuit] [char](13),
    [razon_soc] [varchar](255) UNIQUE NOT NULL,
    [id_usuario] [numeric](18,0) FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Usuario(id),
    [nombre_contacto] [varchar](255), -- no hay información en tabla maestra. Queda como NULL si es migrado, pero verificar en FE.
    [rubro] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Rubro(id),
    [telefono] [numeric](18,0) NOT NULL,
    [mail] [varchar](255), -- no hay información en tabla maestra. Queda como NULL si es migrado, pero verificar en FE.
    [direccion] [varchar](255) NOT NULL,
    [ciudad] [varchar](255) NOT NULL,
    [cod_postal] [smallint], -- no hay información en tabla maestra. Queda como NULL si es migrado, pero verificar en FE.
    [habilitado] [bit] NOT NULL DEFAULT 1, -- 1 habilitado, 0 inhabilitado
    PRIMARY KEY (cuit)
)
GO


CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Facturacion](
    [numero_factura] [numeric](18,0) IDENTITY,
    [fecha_desde] [datetime] NOT NULL,
    [fecha_hasta] [datetime] NOT NULL,
    [cuit_proveedor] [char](13) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Proveedor(cuit),
    [total] [numeric](18,2) NOT NULL,
    PRIMARY KEY (numero_factura)
)
GO
SET IDENTITY_INSERT [SELECT_THISGROUP_FROM_APROBADOS].[Facturacion] ON  

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Tipo_Pago](
    [id] [tinyint] IDENTITY,
    [descripcion] [varchar](255) NOT NULL,
    PRIMARY KEY (id)
)
GO

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Carga](
    [id] [numeric](18,0) IDENTITY,
    [id_cliente] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Cliente(id),
    [id_tipoPago] [tinyint] NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Tipo_Pago(id),
    [fecha] [datetime] NOT NULL,
    [monto] [numeric](18,2) NOT NULL,
    PRIMARY KEY (id)
)
GO


CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Datos_Tarjeta](
    [id] [numeric](18,0) IDENTITY,
    [id_tipoPago] [tinyint] NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Tipo_Pago(id),
    [numero] [numeric](18,0) NOT NULL,
    [nombre] [varchar](255) NOT NULL,
    PRIMARY KEY (id)
)
GO

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Oferta](
    [id] [numeric](18,0) IDENTITY,
    [cuit_prov] [char](13) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Proveedor(cuit),
    [codigo] [varchar](255), --para poder migrar los datos
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

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Cupon](
    [codigo_cupon] [numeric](18,0) IDENTITY,
    [id_oferta] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Oferta(id),
    [cod_compra] [numeric](18,0), -- se le asigna en el stored procedure de compra
    [id_entrega] [numeric](18,0), -- puede haber cupon sin entregar aun
    [fecha_vencimiento] [datetime] NOT NULL,
    [cantidad] [int] NOT NULL,
	[monto] [numeric](18,2)
    PRIMARY KEY (codigo_cupon)
)
GO

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Entrega](
    [id] [numeric](18,0) IDENTITY,
    [fecha_consumo] [datetime] NOT NULL,
    [cupon] [numeric](18,0) UNIQUE NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Cupon(codigo_cupon),
    [id_cliente] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Cliente(id),
    PRIMARY KEY (id)
)
GO

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Compra](
    [codigo_compra] [numeric](18,0) IDENTITY,
    [id_cliente_compra] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Cliente(id),
    [cod_cupon] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Cupon(codigo_cupon),
    [fecha_compra] [datetime] NOT NULL,
    PRIMARY KEY (codigo_compra)
)
GO

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Detalle_Facturacion](
	[id] [numeric](18,0) IDENTITY,
	[numero_factura] [numeric](18,0) FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Facturacion(numero_factura),
	[id_oferta] [numeric](18,0) FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Oferta(id),
	[cantidad] int NOT NULL,
	[monto] [numeric](18,0) NOT NULL,
	PRIMARY KEY (id)
)
GO

-- Agregar FK faltantes de Cupon (no se puede al crear la tabla porque no existen las otras tablas)
ALTER TABLE [SELECT_THISGROUP_FROM_APROBADOS].Cupon ADD FOREIGN KEY (cod_compra) REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Compra(codigo_compra) 
ALTER TABLE [SELECT_THISGROUP_FROM_APROBADOS].Cupon ADD FOREIGN KEY (id_entrega) REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Entrega(id)


/* Migracion */

-- Roles
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Rol(nombre)
VALUES ('Administrador General'), ('Cliente'), ('Proveedor'), ('Administrativo')
GO

-- Funcionalidades
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Funcionalidad(descripcion)
VALUES ('ABM Rol'), ('ABM Cliente'), ('ABM Proveedor'), ('Carga Credito'), ('Crear Oferta'), ('Comprar Oferta'), ('Consumir Oferta'), ('Facturacion'), ('Listado Estadistico') 
GO

-- Funcionalidades por Rol
-- Administrador General puede: todo
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Rol_Funcionalidad(id_rol, id_func)
SELECT 1, id FROM [SELECT_THISGROUP_FROM_APROBADOS].Funcionalidad 
GO
-- Cliente puede: cargar credito y comprar oferta
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Rol_Funcionalidad(id_rol, id_func)
SELECT 2, id FROM [SELECT_THISGROUP_FROM_APROBADOS].Funcionalidad
WHERE descripcion IN ('Carga Credito', 'Comprar Oferta')
GO
-- Proveedor puede:
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Rol_Funcionalidad(id_rol, id_func)
SELECT 3, id FROM [SELECT_THISGROUP_FROM_APROBADOS].Funcionalidad
WHERE descripcion IN ('Crear Oferta', 'Consumir Oferta', 'Facturacion')
GO
-- Administrativo puede:
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Rol_Funcionalidad(id_rol, id_func)
SELECT 4, id FROM [SELECT_THISGROUP_FROM_APROBADOS].Funcionalidad
WHERE descripcion IN ('ABM Rol', 'ABM Cliente', 'ABM Proveedor', 'Crear Oferta', 'Facturacion')
GO

-- Usuarios
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Usuario(username, password)
VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'))
GO

-- Rol por Usuario
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Rol_Usuario(id_rol, id_usuario)
VALUES ((SELECT id FROM [SELECT_THISGROUP_FROM_APROBADOS].Rol WHERE nombre = 'Administrador General'), (SELECT id FROM [SELECT_THISGROUP_FROM_APROBADOS].Usuario WHERE username = 'admin'))
GO


-- Migrar Clientes. El CP NULL indicará que es un dato migrado (controlar en FE) ya que no es un dato en tabla maestra.
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Cliente(
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

-- Migrar Rubros.
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Rubro(
    descripcion
)
SELECT DISTINCT 
    Provee_Rubro 
FROM gd_esquema.Maestra
WHERE Provee_Rubro IS NOT NULL
GO

-- Migrar Proveedores. nombre_contacto, mail y codigo postal vacios en tabla maestra.
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Proveedor(
    cuit,
    razon_soc,
    telefono,
    direccion,
    ciudad,
    rubro
) SELECT DISTINCT 
	Provee_CUIT,
    Provee_RS,
    Provee_Telefono,
    Provee_Dom,
    Provee_Ciudad,
	r.id 
    FROM gd_esquema.Maestra
	JOIN SELECT_THISGROUP_FROM_APROBADOS.Rubro r ON Provee_Rubro = descripcion
GO

-- Cargar Tipo de Pagos
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Tipo_Pago(descripcion)
VALUES ('Débito'), ('Crédito'), ('Efectivo')
GO

-- Migrar Cargas (Todas las hizo el mismo cliente)
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Carga(
    id_cliente,
    fecha,
    monto,
    id_tipoPago
) SELECT 
    (SELECT id FROM [SELECT_THISGROUP_FROM_APROBADOS].Cliente WHERE dni = (SELECT DISTINCT Cli_Dni FROM gd_esquema.Maestra WHERE Carga_Credito IS NOT NULL)) AS id_cliente,
    Carga_Fecha,
    Carga_Credito,
    (SELECT id FROM [SELECT_THISGROUP_FROM_APROBADOS].Tipo_Pago WHERE descripcion = Tipo_Pago_Desc) AS id_tipoPago
FROM gd_esquema.Maestra
WHERE Carga_Credito IS NOT NULL
GO


-- Actualizar saldo del unico cliente que realizo cargas
UPDATE [SELECT_THISGROUP_FROM_APROBADOS].Cliente
SET saldo = (SELECT SUM(monto) FROM [SELECT_THISGROUP_FROM_APROBADOS].Carga)
WHERE id = 140
GO

-- Migrar Ofertas
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Oferta(
	cuit_prov,
	codigo,
	descripcion,
	fec_public,
	fec_venc,
	precio_oferta,
	precio_lista,
	cantidad_disponible,
	max_por_cliente
) SELECT
	Provee_CUIT,
	Oferta_Codigo,
	Oferta_Descripcion,
	Oferta_Fecha,
	Oferta_Fecha_Venc,
	Oferta_Precio,
	Oferta_Precio_Ficticio,
	Oferta_Cantidad,
	Oferta_Cantidad -- no hay datos en tabla maestra sobre cantidad maxima por cliente
FROM gd_esquema.Maestra
WHERE Oferta_Codigo is not null
GROUP BY Provee_CUIT, Oferta_Codigo, Oferta_Descripcion, Oferta_Fecha, Oferta_Fecha_Venc, Oferta_Precio, Oferta_Precio_Ficticio, Oferta_Cantidad
GO

CREATE INDEX oferta_codigo ON [SELECT_THISGROUP_FROM_APROBADOS].Oferta(codigo)
go

declare un_cursor CURSOR 
STATIC READ_ONLY FORWARD_ONLY
for (SELECT Oferta_Codigo, Oferta_Cantidad, Oferta_Precio, Cli_Dni, Oferta_Fecha_Compra, Oferta_Fecha_Venc FROM gd_esquema.Maestra WHERE Oferta_Fecha_Compra is not null and Factura_Fecha is null and Oferta_Entregado_Fecha is null)

open un_cursor

declare @cupon_temp table(id_cupon numeric(18,0))
declare @compra_temp table(id_compra numeric(18,0))
declare @codigo_oferta varchar(255)
declare @cantidad_oferta_comprada numeric(18,0)
declare @oferta_precio numeric(18,2)
declare @dni numeric(18,0)
declare @fecha_compra datetime
declare @fecha_venc datetime
declare @id_oferta numeric(18,0)

fetch un_cursor into @codigo_oferta, @cantidad_oferta_comprada, @oferta_precio, @dni, @fecha_compra, @fecha_venc
while @@FETCH_STATUS = 0
begin
	set @id_oferta = (SELECT id FROM [SELECT_THISGROUP_FROM_APROBADOS].Oferta WHERE codigo = @codigo_oferta)

	insert into [SELECT_THISGROUP_FROM_APROBADOS].Cupon(
	id_oferta,
	fecha_vencimiento,
	cantidad,
	monto)
	output inserted.codigo_cupon into @cupon_temp
	values (
		@id_oferta,
		@fecha_venc,
		@cantidad_oferta_comprada,
		@cantidad_oferta_comprada * @oferta_precio
	 )

	insert into [SELECT_THISGROUP_FROM_APROBADOS].Compra(
		id_cliente_compra,
		cod_cupon,
		fecha_compra
	) output inserted.codigo_compra into @compra_temp
	values(
		(SELECT id from [SELECT_THISGROUP_FROM_APROBADOS].Cliente WHERE dni = @dni),
		(SELECT id_cupon FROM @cupon_temp),
		@fecha_compra
	)

	UPDATE [SELECT_THISGROUP_FROM_APROBADOS].Cupon
	SET cod_compra = (SELECT id_compra FROM @compra_temp) 
	WHERE codigo_cupon = (SELECT id_cupon FROM @cupon_temp)

	DELETE @compra_temp 
	DELETE @cupon_temp

	fetch un_cursor into @codigo_oferta, @cantidad_oferta_comprada, @oferta_precio, @dni, @fecha_compra, @fecha_venc
end

close un_cursor
deallocate un_cursor

-- Migrar Entregas
--INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Entrega(
--	fecha_consumo,
--	id_cliente,
--	cupon
--) SELECT
--	Oferta_Entregado_Fecha,
--	(SELECT id FROM [SELECT_THISGROUP_FROM_APROBADOS].Cliente WHERE dni = Cli_Dni) as id_cliente,
--	(SELECT codigo_cupon FROM [SELECT_THISGROUP_FROM_APROBADOS].Cupon Cupon 
--		JOIN [SELECT_THISGROUP_FROM_APROBADOS].Compra Compra on Compra.cod_cupon = Cupon.codigo_cupon
--		JOIN [SELECT_THISGROUP_FROM_APROBADOS].Cliente Cliente on Cliente.id = Compra.id_cliente_compra, 
--		[SELECT_THISGROUP_FROM_APROBADOS].Oferta Oferta
--		WHERE Cupon.id_oferta = Oferta.id and Oferta_Codigo = codigo and Cliente.dni = Cli_Dni) as cupon
--FROM gd_esquema.Maestra
--WHERE Oferta_Entregado_Fecha is not null
--GO

-- Migrar Facturación
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Facturacion(
	numero_factura,
	fecha_desde,
	fecha_hasta,
	cuit_proveedor,
	total
) SELECT DISTINCT
	m1.factura_Nro, 
	(SELECT MIN(Oferta_Fecha_Compra) FROM gd_esquema.Maestra m2 WHERE m2.Factura_Nro = m1.factura_Nro),
	(SELECT MAX(Oferta_Fecha_Compra) FROM gd_esquema.Maestra m2 WHERE m2.Factura_Nro = m1.factura_Nro),
	provee_cuit,
	0
FROM gd_esquema.Maestra m1
WHERE Factura_Fecha is not null
GO

-- Migrar Detalle_Facturacion:
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Detalle_Facturacion(
	numero_factura,
	id_oferta,
	cantidad,
	monto
) SELECT 
	Factura_Nro,
	id,
	Oferta_Cantidad,
	Oferta_Precio*Oferta_Cantidad 
FROM gd_esquema.Maestra
JOIN [SELECT_THISGROUP_FROM_APROBADOS].Oferta ON codigo = Oferta_Codigo
WHERE Factura_Nro IS NOT NULL
GO

-- Actualizo Total de cada factura:
-- Observación importante: El monto ya es cantidad*precio, no multiplicar de vuelta!
UPDATE [SELECT_THISGROUP_FROM_APROBADOS].Facturacion
SET  total = (SELECT SUM(monto) FROM [SELECT_THISGROUP_FROM_APROBADOS].Detalle_Facturacion WHERE f.numero_factura = numero_factura)
FROM [SELECT_THISGROUP_FROM_APROBADOS].Facturacion f
JOIN [SELECT_THISGROUP_FROM_APROBADOS].Detalle_Facturacion df ON f.numero_factura = df.numero_factura
GO


-- Stored Procedures
-- sp_validar_login
CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].sp_validar_login(@username varchar(255), @password varchar(255))
AS
 BEGIN
    IF ((SELECT habilitado FROM [SELECT_THISGROUP_FROM_APROBADOS].Usuario WHERE username = @username) = 0)
		RETURN -1 -- Código usuario inhablitado

    IF((SELECT intentos_fallidos FROM [SELECT_THISGROUP_FROM_APROBADOS].Usuario WHERE username = @username) >= 3)
        RETURN -2 -- Código usuario más de 3 intentos fallidos
 	
    DECLARE @hash_pass varchar(255)
	DECLARE @id_usuario numeric(18,0)

	SET @hash_pass = HASHBYTES('SHA2_256', @password)
	SET @id_usuario = (SELECT id FROM [SELECT_THISGROUP_FROM_APROBADOS].Usuario WHERE username = @username AND password = @hash_pass)

	IF (@id_usuario IS NOT NULL)
		BEGIN 
		UPDATE [SELECT_THISGROUP_FROM_APROBADOS].Usuario SET intentos_fallidos = 0 WHERE username = @username
		RETURN @id_usuario
		END
	ELSE 	
		BEGIN 
		UPDATE [SELECT_THISGROUP_FROM_APROBADOS].Usuario SET intentos_fallidos += 1 WHERE username = @username
		RETURN -3 -- Codigo usuario/password incorrecto/inexistente
		END 
 END
GO

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].nuevo_usuario(@username varchar(255), @password varchar(255))
AS
 BEGIN
    DECLARE @hash_pass varchar(255)
	DECLARE @id_usuario numeric(18,0)

	SET @hash_pass = HASHBYTES('SHA2_256', @password)
	SET @id_usuario = (SELECT id FROM [SELECT_THISGROUP_FROM_APROBADOS].Usuario WHERE username = @username)

	IF (@id_usuario IS NULL)
		BEGIN 
		INSERT SELECT_THISGROUP_FROM_APROBADOS.Usuario (username, intentos_fallidos, habilitado, password)
		VALUES(@username, 0, 1, @hash_pass)
		RETURN (select id from Usuario where username like @username)
		END
	ELSE
		RETURN -1 -- usuario ya esiste
 END
GO

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].cambiar_contrasena(@id_usuario numeric(18,0), @nueva_pass varchar(255),
																		@vieja_pass varchar(255))
AS
BEGIN
	DECLARE @hash_pass_nueva varchar(255)
	DECLARE @hash_pass_vieja varchar(255)

	SET @hash_pass_nueva = HASHBYTES('SHA2_256', @nueva_pass)
	SET @hash_pass_vieja = HASHBYTES('SHA2_256', @vieja_pass)

	UPDATE Usuario
	SET password = @hash_pass_nueva
	WHERE id = @id_usuario and password = @hash_pass_vieja

	if @@ROWCOUNT = 0
	 return -1 -- contraseña no es correcta
	else
	 return 0
END
GO

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].nuevo_rol_usuario(@id_user numeric(18,0), @id_rol numeric(18,0))
AS
 BEGIN
	INSERT Rol_Usuario (id_usuario, id_rol)
	VALUES (@id_user, @id_rol)

	IF (@@ERROR = 0)
		RETURN 0
	ELSE
		RETURN -1
 END
GO

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].nuevo_rol(@nombre varchar(255))
AS
BEGIN
	if(@nombre in (select nombre from Rol))
		return -1 --Rol ya existe
	INSERT INTO Rol (nombre, habilitado)
	VALUES (@nombre, 1)
	if @@ERROR = 0
		return (select id from Rol where @nombre = nombre)
	else
		return -2 --Error al crear rol
END
GO

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].agregar_funcionalidad(@id_rol numeric(18,0), @descripcion varchar(255))
AS
BEGIN
	declare @id_func numeric(18,0)
	select @id_func = id from Funcionalidad where descripcion like @descripcion
	INSERT INTO Rol_Funcionalidad(id_func, id_rol)
	VALUES (@id_func, @id_rol)
END
GO

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].quitar_funcionalidad(@id_rol numeric(18,0), @descripcion varchar(255))
AS
BEGIN
	declare @id_func numeric(18,0)
	select @id_func = id from Funcionalidad where descripcion like @descripcion
	DELETE Rol_Funcionalidad
	where id_func = @id_func and id_rol = @id_rol
END
GO

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].mod_rol(@nombre_actual varchar(255), @nombre_nuevo varchar(255))
AS
BEGIN
	declare @id_rol numeric(18,0)
	select @id_rol = id from Rol where nombre like @nombre_actual
	UPDATE Rol
	set nombre = @nombre_nuevo
	where id = @id_rol
	if @@ERROR = 0
		return @id_rol
	else
		return -1
END
GO

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].habilitar_rol(@id_rol numeric(18,0), @estado_nuevo bit)
AS
BEGIN
	UPDATE Rol
	set habilitado = @estado_nuevo
	where id = @id_rol
	if @@ERROR = 0
		return 0
	else
		return -1
END
GO

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].eliminar_rol(@id_rol numeric(18,0))
AS
BEGIN
	declare @borrar_logicamente numeric(18,0)
END
GO

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].nuevo_cliente(@nombre_nuevo varchar(255),
																@apellido_nuevo varchar(255), @dni_nuevo numeric(18,0),
																@mail varchar(255), @telefono numeric(18,0), 
																@direccion varchar(255), @ciudad varchar(255), @cod_postal smallint,
																@fecha_nac datetime)
AS
BEGIN
	declare @id numeric(18,0)
	if @dni_nuevo in (select dni from Cliente)
		return -1 --Cliente ya existe
	Insert into Cliente (nombre, apellido, dni, mail, telefono, direccion, ciudad, cod_postal, fecha_nac, saldo)
	values(@nombre_nuevo, @apellido_nuevo, @dni_nuevo,
		@mail, @telefono, @direccion, @ciudad,
		@cod_postal, @fecha_nac, 200)
	if @@ERROR = 0
		return (select id from Cliente where dni = @dni_nuevo)
	else
		return -2 --error al cargar nuevos datos
END
GO

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].mod_cliente(@id numeric(18,0), @nombre_nuevo varchar(255),
																@apellido_nuevo varchar(255), @dni_nuevo numeric(18,0),
																@mail varchar(255), @telefono numeric(18,0), 
																@direccion varchar(255), @ciudad varchar(255), @cod_postal smallint,
																@fecha_nac datetime)
AS
BEGIN
	UPDATE Cliente
	set nombre = @nombre_nuevo, apellido = @apellido_nuevo, dni = @dni_nuevo,
		mail = @mail, telefono = @telefono, direccion = @direccion, ciudad = @ciudad,
		cod_postal = @cod_postal, fecha_nac = @fecha_nac
	where id = @id
	if @@ERROR = 0
		return 0
	else
		return -1
END
GO

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].nueva_carga_tarjeta(@id_cliente numeric(18,0), @nombre_titular varchar(255), 
																@numero_tarjeta numeric(18,0), @monto numeric(18,2), 
																@tipo_pago tinyint, @fecha datetime)
AS 
BEGIN Transaction
	update Cliente
	set saldo = saldo + @monto
	where @id_cliente = id
	if @@ERROR != 0
	begin
		rollback
		return -1 --no se encontro cliente
	end

	insert Datos_Tarjeta (nombre, numero, id_tipoPago)
	values(@nombre_titular, @numero_tarjeta, @tipo_pago)
	if @@ERROR != 0
	begin
		rollback
		return -2 --no se pudo insertar datos de tarjeta
	end

	insert Carga (id_cliente, fecha, monto, id_tipoPago)
	values (@id_cliente, @fecha, @monto, @tipo_pago)
	if @@ERROR != 0
	begin
		rollback
		return -3 --no se pudo insertar datos de la carga
	end

	commit
GO

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].nueva_carga_efectivo(@id_cliente numeric(18,0), @monto numeric(18,2), @fecha datetime)
AS 
BEGIN Transaction
	update Cliente
	set saldo = saldo + @monto
	where @id_cliente = id
	if @@ERROR != 0
	begin
		rollback
		return -1 --no se encontro cliente
	end

	declare @tipo_pago tinyint
	set @tipo_pago = (select id from Tipo_Pago where descripcion Like 'Efectivo')

	insert Carga (id_cliente, fecha, monto, id_tipoPago)
	values (@id_cliente, @fecha, @monto, @tipo_pago)
	if @@ERROR != 0
	begin
		rollback
		return -2 --no se pudo insertar datos de la carga
	end

	commit
GO

--Nueva Compra
---Controla que la cantidad comprada no sea mayor a la cantidad maxima por cliente
---Controla que la cantidad comprada no sea mayor a la cantidad disponible
---Controla que el saldo del cliente sea suficiente por Constraint
CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].nueva_compra(@id_cliente numeric(18,0), @id_oferta numeric(18,0),
																 @cantidad numeric(18,0), @fecha datetime)
AS 
BEGIN Transaction
	declare @cant_comprada numeric(18,0)
	set @cant_comprada = (select sum(cantidad) from Cupon where id_oferta = @id_oferta)
	
	--if(@id_cliente in (select id_cliente_compra from SELECT_THISGROUP_FROM_APROBADOS.Compra 
	--					join SELECT_THISGROUP_FROM_APROBADOS.Cupon on cod_compra = codigo_compra
	--					join SELECT_THISGROUP_FROM_APROBADOS.Oferta on id = id_oferta
	--					where id = @id_oferta))
	--begin
	--	rollback
	--	return -5 --cliente ya compro esta oferta
	--end

	Select precio_oferta, cantidad_disponible, max_por_cliente, fec_venc
	Into #oferta_temp
	from Oferta
	where id = @id_oferta

	declare @cant_maxima numeric (18,2)
	declare @cant_disponible numeric (18,2)
	declare @fecha_vencimiento datetime

	set @cant_maxima = (select max_por_cliente from #oferta_temp)
	set @cant_disponible = (select cantidad_disponible from #oferta_temp)
	set @fecha_vencimiento = (select fec_venc from #oferta_temp)

	if(@cantidad + @cant_comprada > @cant_maxima OR @cantidad + @cant_comprada > @cant_disponible)
	begin
		rollback
		return -1 --no se puede comprar porque supera el limite
	end

	declare @monto numeric(18,2)
	set @monto = (select precio_oferta * @cantidad from #oferta_temp)
	if @@ERROR != 0
	begin
		rollback
		return -2 --no se encontro oferta
	end

	begin try
		update Cliente
		set saldo = saldo - @monto
		where @id_cliente = id
	end try
	begin catch
		rollback
		return -3 --cliente no posee suficiente saldo
	end catch

	declare @cupon table(id numeric(18,0))
	
	insert Cupon(id_oferta, fecha_vencimiento, cantidad, monto)
	output inserted.codigo_cupon into @cupon
	values (@id_oferta, @fecha_vencimiento, @cantidad, @monto)
	if @@ERROR != 0
	begin
		rollback
		return -4 --no se pudo insertar datos de la compra
	end

	declare @id_cupon numeric(18,0)
	set @id_cupon = (select id from @cupon)

	declare @compra table(id numeric(18,0))

	insert Compra(id_cliente_compra, fecha_compra, cod_cupon)
	output inserted.codigo_compra into @compra
	values (@id_cliente, @fecha, @id_cupon)
	if @@ERROR != 0
	begin
		rollback
		return -4 --no se pudo insertar datos de la compra
	end

	declare @id_compra numeric(18,0)
	set @id_compra = (select id from @compra)
	
	update Cupon
	set cod_compra = @id_compra
	where codigo_cupon = @id_cupon
	if @@ERROR != 0
	begin
		rollback
		return -4 --no se pudo insertar datos de la compra
	end

	update Oferta
	set cantidad_disponible = cantidad_disponible - @cantidad
	where id = @id_oferta
	if @@ERROR != 0
	begin
		rollback
		return -4 --no se pudo insertar datos de la compra
	end

	commit
	return @id_compra
GO

--Consumir_Oferta:
----SEGUN RESPUESTA DEL FORO: el cliente puede no ser el comprador del cupon
CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].consumir_oferta (@fecha_sistema datetime, @cod_cupon numeric(18,0), @id_cliente numeric(18,0))
AS BEGIN TRANSACTION
	declare @entrega table(id_entrega numeric(18,0))

	insert Entrega (fecha_consumo, cupon, id_cliente)
	output inserted.id into @entrega
	values (@fecha_sistema, @cod_cupon, @id_cliente)

	if @@ERROR != 0
	begin
		rollback
		return -1
	end

	update Cupon
	set id_entrega = (select id_entrega from @entrega)
	where codigo_cupon = @cod_cupon

	if @@ERROR != 0
	begin
		rollback
		return -1
	end

	commit
	return 0
GO

-- SP para Facturar: sp_facturar
-- Observación importante: El monto en los cupones ya es cantidad*precio, así que si se toma el valor de ahí, no repetir la multiplicación porque da cualquier cosa.
CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].sp_facturar(@cuitProveedor char(13), @fechaDesde datetime, @fechaHasta datetime,
@numeroFact NUMERIC OUTPUT, @importeTotal NUMERIC OUTPUT)
AS
 BEGIN
    IF ((SELECT COUNT(*) FROM [SELECT_THISGROUP_FROM_APROBADOS].Facturacion WHERE cuit_proveedor = @cuitProveedor AND CONVERT(datetime,fecha_desde) = @fechaDesde AND CONVERT(datetime,fecha_hasta) = @fechaHasta) > 0)
		BEGIN
			SELECT @numeroFact = numero_factura, @importeTotal = total FROM [SELECT_THISGROUP_FROM_APROBADOS].Facturacion WHERE cuit_proveedor = @cuitProveedor AND CONVERT(datetime, fecha_desde) = @fechaDesde AND CONVERT(datetime, fecha_hasta) = @fechaHasta
			RETURN
		END
	
	-- pregunto si existe algún registro para ese proveedor en esas fecha, en cuyo caso regreso valores que interpretará la aplicación pero no generara ninguna oferta
	IF((SELECT COUNT(*) FROM [SELECT_THISGROUP_FROM_APROBADOS].Cupon WHERE id_oferta IN (SELECT id FROM [SELECT_THISGROUP_FROM_APROBADOS].Oferta WHERE cuit_prov = @cuitProveedor)
	AND cod_compra IN (SELECT codigo_compra FROM [SELECT_THISGROUP_FROM_APROBADOS].Compra WHERE CONVERT(datetime, fecha_compra) >= @fechaDesde AND CONVERT(datetime, fecha_compra) <= @fechaHasta)) < 1)
		BEGIN
			SET @numeroFact = -1
			SET @importeTotal = -1
			RETURN
		END
	
	-- Si llegó acá no existe una factura para ese proveedor en ese período, y hay cosas para facturar
	
	-- inserto factura
	INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Facturacion (fecha_desde, fecha_hasta, cuit_proveedor, total) OUTPUT inserted.numero_factura VALUES (@fechaDesde, @fechaHasta, @cuitProveedor, 0)
	SET @numeroFact = SCOPE_IDENTITY()

	-- inserto detalle
	INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Detalle_Facturacion (numero_factura, id_oferta, cantidad, monto) 
	SELECT @numeroFact, id_oferta, cantidad, monto FROM [SELECT_THISGROUP_FROM_APROBADOS].Cupon cup
	WHERE	cup.id_oferta IN (SELECT id FROM [SELECT_THISGROUP_FROM_APROBADOS].Oferta o WHERE o.cuit_prov = @cuitProveedor)
			AND 
			cup.cod_compra IN (SELECT codigo_compra FROM [SELECT_THISGROUP_FROM_APROBADOS].Compra c WHERE CONVERT(datetime, c.fecha_compra) >= @fechaDesde AND CONVERT(datetime, c.fecha_compra) <= @fechaHasta)	
	

	-- actualizo total nueva factura
	UPDATE [SELECT_THISGROUP_FROM_APROBADOS].Facturacion
	SET  total = (SELECT SUM(monto) FROM [SELECT_THISGROUP_FROM_APROBADOS].Detalle_Facturacion df WHERE df.numero_factura = @numeroFact)
	WHERE numero_factura = @numeroFact

	SELECT @importeTotal = total FROM [SELECT_THISGROUP_FROM_APROBADOS].Facturacion WHERE numero_factura = @numeroFact
	
 END
GO


-- Funciones

--Ofertas_Disponibles:
----Retorna una tabla con todas las ofertas que no esten vencidas
CREATE FUNCTION [SELECT_THISGROUP_FROM_APROBADOS].ofertas_disponibles (@fecha_sistema datetime)
RETURNS @Ofertas TABLE (codigo varchar(255), descripcion varchar(255), 
						fecha_vencimiento datetime, precio_lista numeric(18,2),
						precio_oferta numeric(18,2), cantidad_disponible numeric(18,0),
						cantidad_maxima numeric(18,0))
AS Begin
	insert @Ofertas(codigo, descripcion, fecha_vencimiento, precio_lista, precio_oferta, cantidad_disponible, cantidad_maxima)
	select id, descripcion, fec_venc, precio_lista, precio_oferta, cantidad_disponible, max_por_cliente
	from Oferta where fec_venc >= convert(datetime, @fecha_sistema)
	return
End
Go

--Cupones_Proveedor:
----Retorna una tabla con los cupones de el proveedor con @cuit, que no esten vencidos ni entregados
CREATE FUNCTION [SELECT_THISGROUP_FROM_APROBADOS].cupones_proveedor (@cuit char(13), @fecha_sistema datetime)
RETURNS @Cupones TABLE (id_cupon numeric(12,0), codigo_oferta varchar(255), descripcion varchar(255), 
						fecha_vencimiento datetime, total numeric(18,2))
AS Begin
	insert @Cupones(id_cupon, codigo_oferta, descripcion, fecha_vencimiento, total)
	select codigo_cupon, id, descripcion, fecha_vencimiento, monto
	from Cupon Join Oferta on id_oferta = id
	where fecha_vencimiento >= convert(datetime, @fecha_sistema) 
		and id_entrega is null
		and cuit_prov = @cuit
	return
End
Go

-- Triggers

--quitar rol de usuario cuando este se inhabilita
CREATE TRIGGER after_rol_inhabilitado on [SELECT_THISGROUP_FROM_APROBADOS].Rol
FOR UPDATE
AS DECLARE @id_rol numeric(18,0)
SELECT @id_rol = ins.id from inserted ins
IF UPDATE(habilitado)
BEGIN
	declare @habilitado bit
	set @habilitado = (select habilitado from Rol where @id_rol = id) 
	if(@habilitado = 0)
	Begin
		Delete Rol_Usuario
		where @id_rol = id_rol
	End
END
GO

-- INSERT Usuario Proveedor para probar
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Usuario(username, password)
VALUES ('proveedor1', HASHBYTES('SHA2_256', 'test123'))
GO

UPDATE [SELECT_THISGROUP_FROM_APROBADOS].[Proveedor] SET [id_usuario] = 2
WHERE cuit = '11-22445103-2'



