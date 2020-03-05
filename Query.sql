create database Restaurant

create table DatosRestaurant
(
ID int primary key Identity(1,1),
Nombre varchar(22),
Dirección nvarchar(35),
RNC nvarchar(15),
Teléfono nvarchar(13),
PersonaACargo varchar(50),
CantidadEmpleado int,

FechaCreacion date,
FechaModificacion date,
TipoComida nvarchar(20),
VentasMensualesPromedio money,
GuidReg nvarchar
)

CREATE PROCEDURE spinsertar	
(
@nombre varchar(22),
@direccion nvarchar(35),
@rnc nvarchar(15),
@tel nvarchar(13),
@pac nvarchar(50),
@ca int,
@fc date,
@fm date,
@tc nvarchar,
@vmp money,
@guidreg nvarchar
)
AS
BEGIN
 INSERT INTO DatosRestaurant VALUES (@nombre,@direccion,@rnc,@tel,@pac,@ca,@fc,@fm,@tc,@vmp,@guidreg)
 END

 
CREATE PROCEDURE spseleccionar
(
	@id int
)
AS
BEGIN
	SELECT *FROM DatosRestaurant WHERE Id=@id
END


CREATE PROCEDURE spactualizar
(
@nombre varchar(22),
@direccion nvarchar(35),
@rnc nvarchar(15),
@tel nvarchar(13),
@pac nvarchar(50),
@ca int,
@fc date,
@fm date,
@tc nvarchar,
@vmp money,
@guidreg nvarchar
)
AS
BEGIN
	UPDATE DatosRestaurant SET Dirección=@direccion,RNC=@rnc,Teléfono=@tel,PersonaACargo=@pac,CantidadEmpleado=@ca,FechaCreacion=@fc,FechaModificacion=@fm,TipoComida=@tc,VentasMensualesPromedio=@vmp,GuidReg=@guidreg WHERE Nombre=@nombre
END
	
 CREATE PROCEDURE speliminar
(
	@id int
)
AS
BEGIN
	DELETE FROM DatosRestaurant WHERE Id=@id
END
