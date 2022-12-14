use COLEGIO
go

/*

create table Alumno
(
AL1_CCODIGO	CHAR(10) primary key,
AL1_CPATERNO VARCHAR(20),
AL1_CMATERNO VARCHAR(20),
AL1_CNOMBRES VARCHAR(20),
AL1_CDIRECCION VARCHAR(60),
AL1_FECHA DATE,
AL1_NEDAD INTEGER
)

*/

-- select * from Alumno
-- SP_MANTENIMIENTO_ALUMNO '0','','cus','sie','jd','av. xxxxxxxx','20/06/1990'
-- SP_MANTENIMIENTO_ALUMNO '1','','cus','sie','jd','av. xxxxxxxx','20/06/1990'

alter PROCEDURE SP_MANTENIMIENTO_ALUMNO
@IND VARCHAR(2),
@AL1_CCODIGO	VARCHAR(10),
@AL1_CPATERNO VARCHAR(20),
@AL1_CMATERNO VARCHAR(20),
@AL1_CNOMBRES VARCHAR(20),
@AL1_CDIRECCION VARCHAR(60),
@AL1_FECHA VARCHAR(10)
AS

DECLARE @AL1_NEDAD INTEGER
IF @IND IN ('1','2')
BEGIN
	SET @AL1_NEDAD=DATEDIFF(YEAR,CONVERT(DATETIME,@AL1_FECHA,103),GETDATE())
END

IF @IND='0' -- LISTAR
BEGIN 
	SELECT AL1_CCODIGO,AL1_CPATERNO,AL1_CMATERNO,AL1_CNOMBRES,AL1_CDIRECCION,AL1_FECHA=convert(varchar(10),AL1_FECHA,103),AL1_NEDAD FROM Alumno
END
ELSE IF @IND='1' -- INSERTAR
BEGIN 
	DECLARE @COR INT
	SELECT @COR=MAX(RIGHT(AL1_CCODIGO,9)) FROM Alumno
	set @COR=isnull(@COR,0)+1
	SET @AL1_CCODIGO='A'+REPLICATE('0',9-LEN(@COR))+CONVERT(VARCHAR,@COR)

	INSERT INTO Alumno (AL1_CCODIGO,AL1_CPATERNO,AL1_CMATERNO,AL1_CNOMBRES,AL1_CDIRECCION,AL1_FECHA,AL1_NEDAD) 
		VALUES (@AL1_CCODIGO,@AL1_CPATERNO,@AL1_CMATERNO,@AL1_CNOMBRES,@AL1_CDIRECCION,CONVERT(DATETIME,@AL1_FECHA,103),@AL1_NEDAD)
END
ELSE IF @IND='2' -- MODIFICAR
BEGIN 
	UPDATE Alumno SET AL1_CPATERNO=@AL1_CPATERNO,AL1_CMATERNO=@AL1_CMATERNO,AL1_CNOMBRES=@AL1_CNOMBRES,AL1_CDIRECCION=@AL1_CDIRECCION,AL1_FECHA=CONVERT(DATETIME,@AL1_FECHA,103),
	AL1_NEDAD=@AL1_NEDAD
	WHERE AL1_CCODIGO=@AL1_CCODIGO
END
ELSE IF @IND='3' -- ELIMINAR
BEGIN 
	DELETE Alumno WHERE AL1_CCODIGO=@AL1_CCODIGO
END








