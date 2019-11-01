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

-- Drop SP
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].sp_validar_login', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[sp_validar_login];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].nuevo_rol', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[nuevo_rol];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].agregar_funcionalidad', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[agregar_funcionalidad];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].quitar_funcionalidad', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[quitar_funcionalidad];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].mod_rol', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[mod_rol];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].habilitar_rol', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[habilitar_rol];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].eliminar_rol', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[eliminar_rol];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].buscar_cliente', 'TF') IS NOT NULL DROP FUNCTION [SELECT_THISGROUP_FROM_APROBADOS].[buscar_cliente];
IF OBJECT_ID('[SELECT_THISGROUP_FROM_APROBADOS].mod_cliente', 'P') IS NOT NULL DROP PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].[mod_cliente];

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
    [saldo] [numeric](18,2) NOT NULL DEFAULT 0,
    [habilitado] [bit] NOT NULL DEFAULT 1, -- 1 habilitado, 0 inhabilitado
    PRIMARY KEY (id)
)
GO

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Proveedor](
    [cuit] [char](13),
    [razon_soc] [varchar](255) UNIQUE NOT NULL,
    [id_usuario] [numeric](18,0) FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Usuario(id),
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

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Facturacion](
    [numero_factura] [numeric](18,0),
    [fecha_desde] [datetime] NOT NULL,
    [fecha_hasta] [datetime] NOT NULL,
    [cuit_proveedor] [char](13) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Proveedor(cuit),
    [total] [numeric](18,2) NOT NULL,
    PRIMARY KEY (numero_factura)
)
GO

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

CREATE TABLE [SELECT_THISGROUP_FROM_APROBADOS].[Cupon](
    [codigo_cupon] [numeric](18,0),
    [id_oferta] [numeric](18,0) NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Oferta(id),
    [cod_compra] [numeric](18,0) NOT NULL,
    [id_entrega] [numeric](18,0), -- puede haber cupon sin entregar aun
    [fecha_vencimiento] [datetime] NOT NULL,
    [cantidad] [int] NOT NULL,
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
    [cod_cupon] [numeric](18,0) UNIQUE NOT NULL FOREIGN KEY REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Cupon(codigo_cupon),
    [fecha_compra] [datetime] NOT NULL,
    PRIMARY KEY (codigo_compra)
)
GO




-- Agregar FK faltantes de Cupon (no se puede al crear la tabla porque no existen las otras tablas)
ALTER TABLE [SELECT_THISGROUP_FROM_APROBADOS].Cupon ADD FOREIGN KEY (cod_compra) REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Compra(codigo_compra) 
ALTER TABLE [SELECT_THISGROUP_FROM_APROBADOS].Cupon ADD FOREIGN KEY (id_entrega) REFERENCES [SELECT_THISGROUP_FROM_APROBADOS].Entrega(id)


/* Migracion */

-- Roles
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Rol(nombre)
VALUES ('Administrador'), ('Cliente'), ('Proveedor')
GO

-- Funcionalidades
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Funcionalidad(descripcion)
VALUES ('ABM Rol'), ('ABM Cliente'), ('ABM Proveedor'), ('Carga Credito'), ('Crear Oferta'), ('Comprar Oferta'), ('Consumir Oferta'), ('Facturacion'), ('Listado Estadistico') 
GO

-- Funcionalidades por Rol
-- Administrador puede: todo
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

-- Usuarios
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Usuario(username, password)
VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'))
GO

-- Rol por Usuario
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Rol_Usuario(id_rol, id_usuario)
VALUES ((SELECT id FROM [SELECT_THISGROUP_FROM_APROBADOS].Rol WHERE nombre = 'Administrador'), (SELECT id FROM [SELECT_THISGROUP_FROM_APROBADOS].Usuario WHERE username = 'admin'))
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


-- Migrar Proveedores. nombre_contacto, mail y codigo postal vacios en tabla maestra.
INSERT INTO [SELECT_THISGROUP_FROM_APROBADOS].Proveedor(
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


-- Actualizar saldo del unico cliente que realizo cargas - VER

-- Migrar Facturación

-- Migrar Entregas

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

CREATE PROCEDURE [SELECT_THISGROUP_FROM_APROBADOS].nuevo_rol(@nombre varchar(255))
AS
BEGIN
	declare @id numeric(18,0)
	select @id = (MAX(id) + 1) from Rol
	if(@nombre in (select nombre from Rol))
		return -1 --Rol ya existe
	INSERT INTO Rol (id, nombre, habilitado)
	VALUES (@id, @nombre, 1)
	return @id
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


-- Funciones
CREATE FUNCTION	[SELECT_THISGROUP_FROM_APROBADOS].buscar_cliente(@nombre varchar(255), @apellido varchar(255), @dni numeric(18,0))
RETURNS @clientes TABLE (nombre varchar(255) not null, apellido varchar(255), dni numeric(18,0), habilitado bit)
AS
BEGIN
	if(@nombre Like '' and @apellido like '' and @dni is null)
	begin
		insert @clientes
		Select nombre, apellido, dni, habilitado from SELECT_THISGROUP_FROM_APROBADOS.Cliente
		return
	end	
	else
	begin
		if(@apellido like '' and @dni is null)
		begin
			insert @clientes
			Select nombre, apellido, dni, habilitado from SELECT_THISGROUP_FROM_APROBADOS.Cliente
			where nombre Like @nombre
			return
		end
		if(@nombre like '' and @dni is null)
		begin
			insert @clientes
			Select nombre, apellido, dni, habilitado from SELECT_THISGROUP_FROM_APROBADOS.Cliente
			where apellido Like @apellido
			return
		end
		if(@nombre like '' and @apellido like '')
		begin
			insert @clientes
			Select nombre, apellido, dni, habilitado from SELECT_THISGROUP_FROM_APROBADOS.Cliente
			where dni = @dni
			return
		end
		if(@nombre like '' and @apellido like '')
		begin
			insert @clientes
			Select nombre, apellido, dni, habilitado from SELECT_THISGROUP_FROM_APROBADOS.Cliente
			where dni = @dni
			return
		end
		if(@nombre like '')
		begin
			insert @clientes
			Select nombre, apellido, dni, habilitado from SELECT_THISGROUP_FROM_APROBADOS.Cliente
			where dni = @dni and apellido like @apellido
			return
		end
		if(@apellido like '')
		begin
			insert @clientes
			Select nombre, apellido, dni, habilitado from SELECT_THISGROUP_FROM_APROBADOS.Cliente
			where dni = @dni and nombre like @nombre
			return
		end
		if(@dni is null)
		begin
			insert @clientes
			Select nombre, apellido, dni, habilitado from SELECT_THISGROUP_FROM_APROBADOS.Cliente
			where nombre like @nombre and apellido like @apellido
			return
		end
		insert @clientes
		select nombre, apellido, dni, habilitado from SELECT_THISGROUP_FROM_APROBADOS.Cliente
		where apellido Like @apellido and nombre like @nombre and dni = @dni
		return
	end
	return
END
GO

-- Triggers

--TODO: quitar rol de usuario cuando este se inhabilita