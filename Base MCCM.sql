--CREATE DATABASE MCCM
use MCCM

CREATE TABLE TMCCM_Usuario(
	TN_ID_Usuario int identity(1,1),
	TC_Identificacion Varchar(30),
	TC_Nombre Varchar(30),
	TC_Primer_Apellido varchar(30),
	TC_Segundo_Apellido varchar(30),
	TC_Correo Varchar(100),
	TC_Contrasennia varchar(20),
	TB_En_Grupo bit default 0,
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TMCCM_Usuario PRIMARY KEY(TN_ID_Usuario)
)

CREATE TABLE TMCCM_Rol(
	TN_ID_Rol int identity,
	TC_Nombre varchar(30),
	TC_Descripcion varchar(30),
	TF_Fecha_Creacion date,
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TMCCM_Rol Primary key(TN_ID_Rol)
)

CREATE TABLE TMCCM_Usuario_Rol(
	TN_ID_Rol int,
	TN_ID_Usuario int,
	CONSTRAINT FK_TMCCM_Rol_REL_TMCCM_Usuario_Rol Foreign Key(TN_ID_Rol) references TMCCM_Rol(TN_ID_Rol),
	CONSTRAINT FK_TMCCM_Usuario_REL_TMCCM_Usuario_Rol Foreign Key(TN_ID_Usuario) references TMCCM_Usuario(TN_ID_Usuario),
	CONSTRAINT PK_TMCCM_Usuario_Rol PRIMARY KEY(TN_ID_Rol,TN_ID_Usuario)
)

CREATE TABLE TMCCM_Caso(
	TN_ID_Caso int identity,
	TN_ECU int,
	TC_Nombre_Caso varchar(100),
	TC_Enfoque_Trabajo varchar(100),
	TC_Area_Trabajo varchar(100),
	TN_Nivel int,
	TC_Descripcion varchar(200),
	TC_Fuente varchar(200),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TMCCM_Caso PRIMARY KEY(TN_ID_Caso)
)

ALTER TABLE TMCCM_Caso
ADD TC_Delito varchar(100);

ALTER TABLE TMCCM_Caso
ADD TF_Fecha Date;

CREATE TABLE TMCCM_Grupo(
	TN_ID_Grupo int identity,
	TN_ID_Caso int,
	TF_Hora time,
	TC_Zona varchar(50),
	TF_Fecha_Inicio Date,
	TF_Fecha_Final Date,
	TB_Mando bit default 0,
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_Grupo PRImARY KEY(TN_ID_Grupo),
	CONSTRAINT FK_TMCCM_Caso_REL_TMCCM_Grupo Foreign Key(TN_ID_Caso) references TMCCM_Caso(TN_ID_Caso),
)

CREATE TABLE TMCCM_Grupo_Usuario(
	TN_ID_Usuario int,
	TN_ID_Grupo int,
	TB_Eliminado bit default 1,
	TB_Encargado bit,
	CONSTRAINT FK_TMCCM_Grupo_REL_TMCCM_Grupo_Usuario Foreign Key(TN_ID_Grupo) references TMCCM_Grupo(TN_ID_Grupo),
	CONSTRAINT FK_TMCCM_Usuario_REL_TMCCM_Grupo_Usuario Foreign Key(TN_ID_Usuario) references TMCCM_Usuario(TN_ID_Usuario),
	CONSTRAINT PK_TMCCM_Grupo_Usuario PRIMARY KEY(TN_ID_Usuario,TN_ID_Grupo)
)

CREATE TABLE TMCCM_Vehiculo(
	TN_ID_Vehiculo int identity,
	TC_Placa varchar(20),
	TC_Marca varchar(50),
	TC_Clase varchar(50),
	TB_Fotografia varbinary(MAX),
	TC_Clasificacion varchar(50),
	TC_Estilo varchar(50),
	TN_Anno int,
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_Vehiculo PRImARY KEY(TN_ID_Vehiculo)
)

CREATE TABLE TMCCM_Grupo_Vehiculo(
	TN_ID_Vehiculo int,
	TN_ID_Grupo int,
	TB_Eliminado bit default 1,
	CONSTRAINT FK_TMCCM_Grupo_REL_TMCCM_Grupo_Vehiculo Foreign Key(TN_ID_Grupo) references TMCCM_Grupo(TN_ID_Grupo),
	CONSTRAINT FK_TMCCM_Vehiculo_REL_TMCCM_Grupo_Vehiculo Foreign Key(TN_ID_Vehiculo) references TMCCM_Vehiculo(TN_ID_Vehiculo),
	CONSTRAINT PK_TMCCM_Grupo_Vehiculo PRIMARY KEY(TN_ID_Vehiculo,TN_ID_Grupo)
)

CREATE TABLE TMCCM_Evento(
	TN_ID_Evento int identity,
	TN_ID_Caso int,
	TF_Fecha date,
	TF_Hora time,
	TC_Informa varchar(50),
	TC_Lugar varchar(50),
	TC_Novedad varchar(200),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_Evento PRImARY KEY(TN_ID_Evento),
	CONSTRAINT FK_TMCCM_Caso_REL_TMCCM_Evento Foreign Key(TN_ID_Caso) references TMCCM_Caso(TN_ID_Caso),
)

CREATE TABLE TMCCM_Tarea(
	TN_ID_Tarea int identity,
	TN_ID_Caso int,
	TN_ID_Usuario int,
	TF_Fecha date,
	TF_Hora time,
	TC_Diligencia varchar(100),
	TC_Lugar varchar(50),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_Tarea PRImARY KEY(TN_ID_Tarea),
	CONSTRAINT FK_TMCCM_Caso_REL_TMCCM_Tarea Foreign Key(TN_ID_Caso) references TMCCM_Caso(TN_ID_Caso),
	CONSTRAINT FK_TMCCM_Usuario_REL_TMCCM_Tarea Foreign Key(TN_ID_Usuario) references TMCCM_Usuario(TN_ID_Usuario)
)

CREATE TABLE TMCCM_C_Droga_Tipo_Droga(
	TN_ID_Tipo_Droga int identity,
	TF_Fecha_Creacion date,
	TC_Nombre varchar(50),
	TC_Descripcion varchar(100),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_C_Droga_Tipo_Droga PRImARY KEY(TN_ID_Tipo_Droga)
)

CREATE TABLE TMCCM_Entidad_Droga(
	TN_ID_Droga int identity,
	TN_ID_Caso int,
	TN_ID_Tipo_Droga int,
	TC_Nombre varchar(50),
	TC_Detalle varchar(200),
	TN_Cantidad int,
	TF_Fecha_Decomiso date,
	TF_Hora_Decomiso time,
	TB_Eliminado bit default 0,
	CONSTRAINT PK_TCCM_Entidad_Droga PRImARY KEY(TN_ID_Droga),
	CONSTRAINT FK_TMCCM_Caso_REL_TMCCM_Entidad_Droga Foreign Key(TN_ID_Caso) references TMCCM_Caso(TN_ID_Caso),
	CONSTRAINT FK_TMCCM_C_Droga_Tipo_Droga_REL_TMCCM_Entidad_Droga Foreign Key(TN_ID_Tipo_Droga) references TMCCM_C_Droga_Tipo_Droga(TN_ID_Tipo_Droga)
)

ALTER TABLE TMCCM_Entidad_Droga
ADD TF_Fecha_Creacion date;

ALTER TABLE TMCCM_Entidad_Droga
ADD TF_Fecha_Modificacion date;

ALTER TABLE TMCCM_Entidad_Droga
ADD TC_Creado_Por varchar(50);

ALTER TABLE TMCCM_Entidad_Droga
ADD TC_Modificado_Por varchar(50);

ALTER TABLE TMCCM_Entidad_Droga
ADD TB_Verificado bit default 0;

CREATE TABLE TMCCM_C_Gasto_Tipo_Gasto(
	TN_ID_Tipo_Gasto int identity,
	TC_Nombre varchar(50),
	TC_Descripcion varchar(100),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_C_Gasto_Tipo_Gasto PRImARY KEY(TN_ID_Tipo_Gasto)
)

CREATE TABLE TMCCM_Gasto(
	TN_ID_Gasto int identity,
	TN_ID_Caso int,
	TN_ID_Tipo_Gasto int,
	TF_Fecha date,
	TN_Num_Factura int,
	TD_Monto float(2),
	TC_Compra varchar(100),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_Gasto PRImARY KEY(TN_ID_Gasto),
	CONSTRAINT FK_TMCCM_Caso_REL_TMCCM_Gasto Foreign Key(TN_ID_Caso) references TMCCM_Caso(TN_ID_Caso),
	CONSTRAINT FK_TMCCM_C_Gasto_Tipo_Gasto_REL_TMCCM_Gasto Foreign Key(TN_ID_Tipo_Gasto) references TMCCM_C_Gasto_Tipo_Gasto(TN_ID_Tipo_Gasto)
)

CREATE TABLE TMCCM_C_Arma_Marca(
	TN_ID_Marca_Arma int identity,
	TC_Descripcion varchar(100),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_C_Arma_Marca PRImARY KEY(TN_ID_Marca_Arma)
)

CREATE TABLE TMCCM_C_Arma_Tipo_Arma(
	TN_ID_Tipo_Arma int identity,
	TC_Descripcion varchar(100),
	TB_Eliminado bit default 1,
	TN_Peso int,
	CONSTRAINT PK_TCCM_C_Arma_Tipo_Arma PRImARY KEY(TN_ID_Tipo_Arma)
)

CREATE TABLE TMCCM_C_Arma_Icono_Arma(
	TN_ID_Icono_Arma int identity,
	TC_Descripcion varchar(100),
	TB_Imagen varbinary(MAX),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_C_Arma_Icono_Arma PRImARY KEY(TN_ID_Icono_Arma)
)

CREATE TABLE TMCCM_Entidad_Arma(
	TN_ID_Arma int identity,
	TN_ID_Caso int,
	TN_ID_Marca_Arma int,
	TN_ID_Icono_Arma int,
	TN_ID_Tipo_Arma int,
	TC_Modelo_Arma varchar(40),
	TC_Calibre varchar(15),
	TC_Serie varchar(20),
	TF_Fecha_Creacion date,
	TF_Fecha_Modificacion date,
	TC_Creado_Por varchar(50),
	TC_Modificado_Por varchar(50),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_Entidad_Arma PRImARY KEY(TN_ID_Arma),
	CONSTRAINT FK_TMCCM_Caso_REL_TMCCM_Entidad_Arma Foreign Key(TN_ID_Caso) references TMCCM_Caso(TN_ID_Caso),
	CONSTRAINT FK_TMCCM_C_Arma_Tipo_Arma_REL_TMCCM_Entidad_Arma Foreign Key(TN_ID_Tipo_Arma) references TMCCM_C_Arma_Tipo_Arma(TN_ID_Tipo_Arma),
	CONSTRAINT FK_TMCCM_C_Arma_Icono_Arma_REL_TMCCM_Entidad_Arma Foreign Key(TN_ID_Icono_Arma) references TMCCM_C_Arma_Icono_Arma(TN_ID_Icono_Arma),
	CONSTRAINT FK_TMCCM_C_Arma_Marca_REL_TMCCM_Entidad_Arma Foreign Key(TN_ID_Marca_Arma) references TMCCM_C_Arma_Marca(TN_ID_Marca_Arma)
)

ALTER TABLE TMCCM_Entidad_Arma
ADD TB_Verificado bit default 0;

ALTER TABLE TMCCM_Entidad_Arma
ADD TC_Comentario varchar(100);

CREATE TABLE TMCCM_C_Ubicacion_Tipo_Ubicacion(
	TN_ID_Tipo_Ubicacion int identity,
	TC_Nombre varchar(50),
	TC_Descripcion varchar(100),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_C_Ubicacion_Tipo_Ubicacion PRImARY KEY(TN_ID_Tipo_Ubicacion)
)

CREATE TABLE TMCCM_C_Ubicacion_Provincia(
	TN_ID_Provincia int identity,
	TF_Fecha_Creacion date,
	TC_Descripcion varchar(100),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_C_Ubicacion_Provincia PRImARY KEY(TN_ID_Provincia)
)

CREATE TABLE TMCCM_C_Ubicacion_Canton(
	TN_ID_Canton int identity,
	TN_ID_Provincia int,
	TF_Fecha_Creacion date,
	TC_Descripcion varchar(100),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_C_Ubicacion_Canton PRImARY KEY(TN_ID_Canton),
	CONSTRAINT FK_TMCCM_C_Ubicacion_Provincia_REL_TMCCM_C_Ubicacion_Canton 
	Foreign Key(TN_ID_Provincia) references TMCCM_C_Ubicacion_Provincia(TN_ID_Provincia),
)

CREATE TABLE TMCCM_C_Ubicacion_Distrito(
	TN_ID_Distrito int identity,
	TN_ID_Canton int,
	TF_Fecha_Creacion date,
	TC_Descripcion varchar(100),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_C_Ubicacion_Distrito PRImARY KEY(TN_ID_Distrito),
	CONSTRAINT FK_TMCCM_C_Ubicacion_Canton_REL_TMCCM_C_Ubicacion_Distrito 
	Foreign Key(TN_ID_Canton) references TMCCM_C_Ubicacion_Canton(TN_ID_Canton)
)


CREATE TABLE TMCCM_Entidad_Ubicacion(
	TN_ID_Ubicacion int identity,
	TN_ID_Caso int,
	TN_ID_Tipo_Ubicacion int,
	TN_ID_Provincia int,
	TN_ID_Canton int,
	TN_ID_Distrito int,
	TC_Sennas varchar(100),
	TD_Latitud float,
	TD_Longitud float,
	TF_Fecha_Creacion date,
	TF_Fecha_Modificacion date,
	TC_Creado_Por varchar(50),
	TC_Modificado_Por varchar(50),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_Entidad_Ubicacion PRImARY KEY(TN_ID_Ubicacion),
	
	CONSTRAINT FK_TMCCM_Caso_REL_TMCCM_Entidad_Ubicacion Foreign Key(TN_ID_Caso) references TMCCM_Caso(TN_ID_Caso),
	
	CONSTRAINT FK_TMCCM_C_Ubicacion_Tipo_Ubicacion_REL_TMCCM_Entidad_Ubicacion 
	Foreign Key(TN_ID_Tipo_Ubicacion) references TMCCM_C_Ubicacion_Tipo_Ubicacion(TN_ID_Tipo_Ubicacion),
	
	CONSTRAINT FK_TMCCM_C_Ubicacion_Provincia_REL_TMCCM_Entidad_Ubicacion 
	Foreign Key(TN_ID_Provincia) references TMCCM_C_Ubicacion_Provincia(TN_ID_Provincia),
	
	CONSTRAINT FK_TMCCM_C_Ubicacion_Canton_REL_TMCCM_Entidad_Ubicacion 
	Foreign Key(TN_ID_Canton) references TMCCM_C_Ubicacion_Canton(TN_ID_Canton),

	CONSTRAINT FK_TMCCM_C_Ubicacion_Distrito_REL_TMCCM_Entidad_Ubicacion 
	Foreign Key(TN_ID_Distrito) references TMCCM_C_Ubicacion_Distrito(TN_ID_Distrito),
)

ALTER TABLE TMCCM_Entidad_Ubicacion
ADD TB_Verificado bit default 0;

CREATE TABLE TMCCM_C_Telefono_Empresa_Telefonica(
	TN_ID_Proveedor int identity,
	TC_Descripcion varchar(100),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TMCCM_C_Telefono_Empresa_Telefonica PRImARY KEY(TN_ID_Proveedor)
)

CREATE TABLE TMCCM_C_Telefono_Icono_Telefono(
	TN_ID_Icono_Telefono int identity,
	TC_Descripcion varchar(100),
	TB_Imagen varbinary(MAX),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TMCCM_C_Telefono_Icono_Telefono PRImARY KEY(TN_ID_Icono_Telefono)
)

CREATE TABLE TMCCM_Entidad_Telefono(
	TN_ID_Telefono int identity,
	TN_ID_Caso int,
	TN_ID_Proveedor int,
	TN_ID_Icono_Telefono int,
	TC_Comentario varchar(100),
	TN_Numero int,
	TF_Fecha_Creacion date,
	TF_Fecha_Modificacion date,
	TC_Creado_Por varchar(50),
	TC_Modificado_Por varchar(50),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_Entidad_Telefono PRImARY KEY(TN_ID_Telefono),
	
	CONSTRAINT FK_TMCCM_Caso_REL_TMCCM_Entidad_Telefono Foreign Key(TN_ID_Caso) references TMCCM_Caso(TN_ID_Caso),
	
	CONSTRAINT FK_TMCCM_C_Telefono_Icono_Telefono_REL_TMCCM_Entidad_Telefono 
	Foreign Key(TN_ID_Icono_Telefono) references TMCCM_C_Telefono_Icono_Telefono(TN_ID_Icono_Telefono),
	
	CONSTRAINT FK_TMCCM_C_Telefono_Empresa_Telefonica_REL_TMCCM_Entidad_Telefono 
	Foreign Key(TN_ID_Proveedor) references TMCCM_C_Telefono_Empresa_Telefonica(TN_ID_Proveedor)
)

ALTER TABLE TMCCM_Entidad_Telefono
ADD TB_Verificado bit default 0;

CREATE TABLE TMCCM_C_Vehiculo_Marca(
	TN_ID_Marca_Vehiculo int identity,
	TC_Descripcion varchar(100),
	TF_Fecha_Creacion date,
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TMCCM_C_Vehiculo_Marca PRImARY KEY(TN_ID_Marca_Vehiculo)
)

CREATE TABLE TMCCM_C_Vehiculo_Icono(
	TN_ID_Icono_Vehiculo int identity,
	TC_Descripcion varchar(100),
	TF_Fecha_Creacion date,
	TB_Imagen varbinary(MAX),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TMCCM_C_Vehiculo_Icono PRImARY KEY(TN_ID_Icono_Vehiculo)
)

CREATE TABLE TMCCM_C_Vehiculo_Color(
	TN_ID_Color_Vehiculo int identity,
	TC_Descripcion varchar(100),
	TF_Fecha_Creacion date,
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TMCCM_C_Vehiculo_Color PRImARY KEY(TN_ID_Color_Vehiculo)
)

CREATE TABLE TMCCM_C_Vehiculo_Clase(
	TN_ID_Clase_Vehiculo int identity,
	TC_Descripcion varchar(100),
	TF_Fecha_Creacion date,
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TMCCM_C_Vehiculo_Clase PRImARY KEY(TN_ID_Clase_Vehiculo)
)

CREATE TABLE TMCCM_Entidad_Vehiculo(
	TN_ID_Vehiculo int identity,
	TN_ID_Caso int,
	TN_ID_Marca_Vehiculo int,
	TN_ID_Icono_Vehiculo int,
	TN_ID_Color_Vehiculo int,
	TC_Placa varchar(20),
	TC_Clase varchar(50),
	TC_Estilo varchar(50),
	TC_Comentario varchar(100),
	TN_Anno int,
	TF_Fecha_Creacion date,
	TF_Fecha_Modificacion date,
	TC_Creado_Por varchar(50),
	TC_Modificado_Por varchar(50),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TCCM_Entidad_Vehiculo PRImARY KEY(TN_ID_Vehiculo),
	
	CONSTRAINT FK_TMCCM_Caso_REL_TMCCM_Entidad_Vehiculo Foreign Key(TN_ID_Caso) references TMCCM_Caso(TN_ID_Caso),
	
	CONSTRAINT FK_TMCCM_C_Vehiculo_Icono_REL_TMCCM_Entidad_Vehiculo 
	Foreign Key(TN_ID_Icono_Vehiculo) references TMCCM_C_Vehiculo_Icono(TN_ID_Icono_Vehiculo),
	
	CONSTRAINT FK_TMCCM_C_Vehiculo_Marca_REL_TMCCM_Entidad_Vehiculo 
	Foreign Key(TN_ID_Marca_Vehiculo) references TMCCM_C_Vehiculo_Marca(TN_ID_Marca_Vehiculo),

	CONSTRAINT FK_TMCCM_C_Vehiculo_Color_REL_TMCCM_Entidad_Vehiculo 
	Foreign Key(TN_ID_Color_Vehiculo) references TMCCM_C_Vehiculo_Color(TN_ID_Color_Vehiculo),	
)

ALTER TABLE TMCCM_Entidad_Vehiculo
ADD TB_Verificado bit default 0;

ALTER TABLE TMCCM_Entidad_Vehiculo
ADD TB_Fotografia varbinary(MAX);

CREATE TABLE TMCCM_C_Persona_Tipo_Identificacion(
	TN_ID_Tipo_Identificacion int identity,
	TC_Descripcion varchar(100),
	TC_Mascara varchar(50),
	TF_Fecha_Creacion date,
	CONSTRAINT PK_TMCCM_C_Persona_Tipo_Identificacion PRImARY KEY(TN_ID_Tipo_Identificacion)
)


CREATE TABLE TMCCM_C_Persona_Icono_Persona(
	TN_ID_Icono_Persona int identity,
	TC_Descripcion varchar(100),
	TB_Imagen varbinary(MAX),
	CONSTRAINT PK_TMCCM_C_Persona_Icono_Persona PRImARY KEY(TN_ID_Icono_Persona)
)

CREATE TABLE TMCCM_C_Persona_Sexo(
	TN_ID_Sexo int identity,
	TC_Descripcion varchar(100),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TMCCM_C_Persona_Sexo PRImARY KEY(TN_ID_Sexo)
)

CREATE TABLE TMCCM_C_Persona_Nacionalidad(
	TN_ID_Nacionalidad int identity,
	TC_Descripcion varchar(100),
	TF_Fecha_Creacion date,
	CONSTRAINT PK_TMCCM_C_Persona_Nacionalidad PRImARY KEY(TN_ID_Nacionalidad)
)

CREATE TABLE TMCCM_C_Persona_Genero(
	TN_ID_Genero int identity,
	TC_Descripcion varchar(100),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TMCCM_C_Persona_Genero PRImARY KEY(TN_ID_Genero)
)

CREATE TABLE TMCCM_Entidad_Persona(
	TN_ID_Persona int identity,
	TN_ID_Caso int,
	TN_ID_Tipo_Identificacion int,
	TN_ID_Icono_Persona int,
	TN_ID_Sexo int,
	TN_ID_Genero int,
	TN_ID_Nacionalidad int,
	TC_Nombre varchar(30),
	TC_Primer_Apellido varchar(30),
	TC_Segundo_Apellido varchar(30),
	TF_Fecha_Nacimiento Date,
	TN_Edad int,
	TB_Fotografia varbinary(MAX),
	TC_Cedula varchar(20),
	TB_Fallecido bit,
	TN_Autopsia int,
	TB_Exp_Criminal bit,
	TF_Fecha_Creacion date,
	TF_Fecha_Modificacion date,
	TC_Creado_Por varchar(50),
	TC_Modificado_Por varchar(50),
	TB_Verificado bit,
	CONSTRAINT PK_TCCM_Entidad_Persona PRImARY KEY(TN_ID_Persona),
	
	CONSTRAINT FK_TMCCM_Caso_REL_TMCCM_Entidad_PErsona Foreign Key(TN_ID_Caso) references TMCCM_Caso(TN_ID_Caso),
	
	CONSTRAINT FK_TMCCM_C_Persona_Tipo_Identificacion_REL_TMCCM_Entidad_Persona 
	Foreign Key(TN_ID_Tipo_Identificacion) references TMCCM_C_Persona_Tipo_Identificacion(TN_ID_Tipo_Identificacion),
	
	CONSTRAINT FK_TMCCM_C_Persona_Icono_Persona_REL_TMCCM_Entidad_Persona 
	Foreign Key(TN_ID_Icono_Persona) references TMCCM_C_Persona_Icono_Persona(TN_ID_Icono_Persona),

	CONSTRAINT FK_TMCCM_C_Persona_Sexo_REL_TMCCM_Entidad_Persona 
	Foreign Key(TN_ID_Sexo) references TMCCM_C_Persona_Sexo(TN_ID_Sexo),

	CONSTRAINT FK_TMCCM_C_Persona_Genero_REL_TMCCM_Entidad_Persona 
	Foreign Key(TN_ID_Genero) references TMCCM_C_Persona_Genero(TN_ID_Genero),

	CONSTRAINT FK_TMCCM_C_Persona_Nacionalidad_REL_TMCCM_Entidad_Persona 
	Foreign Key(TN_ID_Nacionalidad) references TMCCM_C_Persona_Nacionalidad(TN_ID_Nacionalidad)
)

ALTER TABLE TMCCM_Entidad_Persona
ADD CONSTRAINT df_estado_Verificado
DEFAULT 0 FOR TB_Verificado;

ALTER TABLE TMCCM_Entidad_Persona
ADD TB_Eliminado bit default 1;

ALTER TABLE TMCCM_Entidad_Persona
ADD TC_Alias varchar(30);

CREATE TABLE TMCCM_Entidad_Persona_Juridica(
	TN_ID_Persona_Juridica int identity,
	TN_ID_Caso int,
	TC_ID_Cedula_Juridica varchar(50),
    TC_Nombre_Organizaciรณn varchar(100),
	TC_Nombre_Comercial varchar(100),
	TN_ID_Icono_Persona_Juridica int,
	TB_Fotografia varbinary(MAX),
	TN_ID_Tipo_Organizacion int,
	TC_Sitio_Web varchar(200),
	TC_Comentario varchar(100),
	TF_Fecha_Creacion date,
	TF_Fecha_Modificacion date,
	TC_Creado_Por varchar(50),
	TC_Modificado_Por varchar(50),
	TB_Verificado bit,
	TB_Eliminado bit default 1,

	
	CONSTRAINT FK_TMCCM_C_Persona_Juridica_Icono_Persona_Juridica_REL_TMCCM_Entidad_Persona_Juridica 
	Foreign Key(TN_ID_Icono_Persona_Juridica) references TMCCM_C_Persona_Juridica_Icono_Persona_Juridica(TN_ID_Icono_Persona_Juridica),

	CONSTRAINT FK_TMCCM_C_Persona_Juridica_Tipo_Organizaciรณn_REL_TMCCM_Entidad_Persona_Juridica 
	Foreign Key(TN_ID_Tipo_Organizacion) references TMCCM_C_Persona_Juridica_Tipo_Organizaciรณn(TN_ID_Tipo_Organizacion),


)

CREATE TABLE TMCCM_C_Persona_Juridica_Icono_Persona_Juridica(
	TN_ID_Icono_Persona_Juridica int identity,
	TC_Descripcion varchar(100),
	TB_Imagen varbinary(MAX),
	CONSTRAINT PK_TMCCM_C_Persona_Icono_Persona_Juridica PRImARY KEY(TN_ID_Icono_Persona_Juridica)
)

CREATE TABLE TMCCM_C_Persona_Juridica_Tipo_Organizaciรณn(
	TN_ID_Tipo_Organizacion int identity,
	TC_Descripcion varchar(100),
	TB_Eliminado bit default 1,
	CONSTRAINT PK_TMCCM_C_Persona_Juridica_Tipo_Organizaciรณn PRImARY KEY(TN_ID_Tipo_Organizacion)
)

CREATE PROCEDURE [dbo].[sp_obtenerEventosPorCaso](@casoID int)
as
select TN_ID_Evento,TF_Fecha,TC_Informa,TC_Lugar,TC_Novedad from TMCCM_Evento where TB_Eliminado=0 and TN_ID_Caso=@casoID;

ALTER TABLE dbo.TMCCM_Entidad_Droga
ALTER COLUMN TF_Fecha_Creacion datetime;

ALTER TABLE dbo.TMCCM_Entidad_Droga
ALTER COLUMN TF_Fecha_Modificacion datetime;
Alter Table dbo.TMCCM_Entidad_Persona_Juridica add constraint PK_TCCM_C_Entidad_Persona_Juridica Primary key(TN_Id_Persona_Juridica)


ALTER TABLE dbo.TMCCM_Evento ALTER COLUMN TF_Fecha DATETIME
ALTER TABLE dbo.TMCCM_Evento DROP COLUMN TF_Hora

create procedure sp_Obtener_Catalogo_Usuario
as
select TN_ID_Usuario,TC_Identificacion,CONCAT(TC_Nombre,' ',TC_Primer_Apellido,' ',TC_Segundo_Apellido) as TC_Nombre_Completo from TMCCM_Usuario

ALTER TABLE dbo.TMCCM_Tarea ALTER COLUMN TF_Fecha DATETIME
ALTER TABLE dbo.TMCCM_Tarea DROP COLUMN TF_Hora



ALTER TABLE TMCCM_Entidad_Droga
DROP COLUMN TF_Hora_Decomiso;

---Insertar Marca Arma-----
INSERT INTO [dbo].[TMCCM_C_Arma_Marca]
           ([TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('DESCONOCIDO'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Arma_Marca]
           ([TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('A.A. BROWN &amp; SONS'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Arma_Marca]
           ([TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('ACCU-TEK'
           ,'0')
GO
------Insertar C_Arma_Tipo_Arma
INSERT INTO [dbo].[TMCCM_C_Arma_Tipo_Arma]
           ([TC_Descripcion]
           ,[TB_Eliminado]
           ,[TN_Peso])
     VALUES
           ('AARMA BLNACA'
           ,'0'
           ,'10')
GO
INSERT INTO [dbo].[TMCCM_C_Arma_Tipo_Arma]
           ([TC_Descripcion]
           ,[TB_Eliminado]
           ,[TN_Peso])
     VALUES
           ('ARMA DE FUEGO'
           ,'0'
           ,'20')
GO
INSERT INTO [dbo].[TMCCM_C_Arma_Tipo_Arma]
           ([TC_Descripcion]
           ,[TB_Eliminado]
           ,[TN_Peso])
     VALUES
           ('ARMA CONTUNDENTE'
           ,'0'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Arma_Tipo_Arma]
           ([TC_Descripcion]
           ,[TB_Eliminado]
           ,[TN_Peso])
     VALUES
           ('MUNICION'
           ,'0'
           ,'0')
GO

-----Insertar C_Tipo_Ubicación------
INSERT INTO [dbo].[TMCCM_C_Ubicacion_Tipo_Ubicacion]
           ([TC_Nombre]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('CASA'
           ,'Construcción cubierta destinada a ser habitada'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Ubicacion_Tipo_Ubicacion]
           ([TC_Nombre]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('PARQUE'
           ,'Terreno acotado en núcleos rurales o urbanos, generalmente con plantas y árboles'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Ubicacion_Tipo_Ubicacion]
           ([TC_Nombre]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('EDIFICIO'
           ,'Construcción de grandes dimensiones fabricada con piedras, ladrillos y materiales resistentes'
           ,'0')
GO

-------INSERTAR C_Ubicacion_Provincia-----
INSERT INTO [dbo].[TMCCM_C_Ubicacion_Provincia]
           ([TF_Fecha_Creacion]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           (GETDATE()
           ,'NO INDICA'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Ubicacion_Provincia]
           ([TF_Fecha_Creacion]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           (GETDATE()
           ,'SAN JOSÉ'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Ubicacion_Provincia]
           ([TF_Fecha_Creacion]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           (GETDATE()
           ,'CARTAGO'
           ,'0')
GO

-----INSERTAR C_Ubicacion_Cantón---
INSERT INTO [dbo].[TMCCM_C_Ubicacion_Canton]
           ([TN_ID_Provincia]
           ,[TF_Fecha_Creacion]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('1'
           ,GETDATE()
           ,'NO INDICA'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Ubicacion_Canton]
           ([TN_ID_Provincia]
           ,[TF_Fecha_Creacion]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('2'
           ,GETDATE()
           ,'SAN JOSÉ'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Ubicacion_Canton]
           ([TN_ID_Provincia]
           ,[TF_Fecha_Creacion]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('3'
           ,GETDATE()
           ,'PARAÍSO'
           ,'0')
GO

----INSERTAR C_Ubicacion_Distrito-----
INSERT INTO [dbo].[TMCCM_C_Ubicacion_Distrito]
           ([TN_ID_Canton]
           ,[TF_Fecha_Creacion]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('1'
           ,GETDATE()
           ,'NO INDICA'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Ubicacion_Distrito]
           ([TN_ID_Canton]
           ,[TF_Fecha_Creacion]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('2'
           ,GETDATE()
           ,'NO INDICA'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Ubicacion_Distrito]
           ([TN_ID_Canton]
           ,[TF_Fecha_Creacion]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('3'
           ,GETDATE()
           ,'NO INDICA'
           ,'0')
GO
--------Insertar C_Vehículos_Marca------
INSERT INTO [dbo].[TMCCM_C_Vehiculo_Marca]
           ([TC_Descripcion]
           ,[TF_Fecha_Creacion]
           ,[TB_Eliminado])
     VALUES
           ('DESCONOCIDO'
           ,GETDATE()
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Vehiculo_Marca]
           ([TC_Descripcion]
           ,[TF_Fecha_Creacion]
           ,[TB_Eliminado])
     VALUES
           ('MARCA NO REGISTRADA'
           ,GETDATE()
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Vehiculo_Marca]
           ([TC_Descripcion]
           ,[TF_Fecha_Creacion]
           ,[TB_Eliminado])
     VALUES
           ('FOREDIL'
           ,GETDATE()
           ,'0')
GO

--------INSERTAR C_Vehiculo_Clase-----
INSERT INTO [dbo].[TMCCM_C_Vehiculo_Clase]
           ([TC_Descripcion]
           ,[TF_Fecha_Creacion]
           ,[TB_Eliminado])
     VALUES
           ('Motocicleta'
           ,GETDATE()
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Vehiculo_Clase]
           ([TC_Descripcion]
           ,[TF_Fecha_Creacion]
           ,[TB_Eliminado])
     VALUES
           ('Motocarro'
           ,GETDATE()
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Vehiculo_Clase]
           ([TC_Descripcion]
           ,[TF_Fecha_Creacion]
           ,[TB_Eliminado])
     VALUES
           ('Automovil'
           ,GETDATE()
           ,'0')
GO
-----INSERTAR C_Vehiculo_Color-----
INSERT INTO [dbo].[TMCCM_C_Vehiculo_Color]
           ([TC_Descripcion]
           ,[TF_Fecha_Creacion]
           ,[TB_Eliminado])
     VALUES
           ('DESCONOCIDO'
           ,GETDATE()
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Vehiculo_Color]
           ([TC_Descripcion]
           ,[TF_Fecha_Creacion]
           ,[TB_Eliminado])
     VALUES
           ('CAFE'
           ,GETDATE()
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Vehiculo_Color]
           ([TC_Descripcion]
           ,[TF_Fecha_Creacion]
           ,[TB_Eliminado])
     VALUES
           ('CELESTE'
           ,GETDATE()
           ,'0')
GO

-------INSERTAR C_Persona_Juridica_Tipo_Organización----
INSERT INTO [dbo].[TMCCM_C_Persona_Juridica_Tipo_Organización]
           ([TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('Empresario Individual'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Persona_Juridica_Tipo_Organización]
           ([TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('Sociedad Anonima'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Persona_Juridica_Tipo_Organización]
           ([TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('Asociaciones sin ánimo de lucro'
           ,'0')
GO

------INSERTAR C_Tipo_Identificacion----
INSERT INTO [dbo].[TMCCM_C_Persona_Tipo_Identificacion]
           ([TC_Descripcion]
           ,[TC_Mascara]
           ,[TF_Fecha_Creacion])
     VALUES
           ('DESCONOCIDO'
           ,'xxxxxxxxxxxxxxxxxxxx'
           ,GETDATE())
GO
INSERT INTO [dbo].[TMCCM_C_Persona_Tipo_Identificacion]
           ([TC_Descripcion]
           ,[TC_Mascara]
           ,[TF_Fecha_Creacion])
     VALUES
           ('CEDULA'
           ,'##########'
           ,GETDATE())
GO
INSERT INTO [dbo].[TMCCM_C_Persona_Tipo_Identificacion]
           ([TC_Descripcion]
           ,[TC_Mascara]
           ,[TF_Fecha_Creacion])
     VALUES
           ('CEDULA DE RESIDENCIA'
           ,'xxxxxxxxxxxxxxxxxxxx'
           ,GETDATE())
GO
----INSERTAR C_Persona_Sexo----
INSERT INTO [dbo].[TMCCM_C_Persona_Sexo]
           ([TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('DESCONOCIDO'
           ,0)
GO
INSERT INTO [dbo].[TMCCM_C_Persona_Sexo]
           ([TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('HOMBRE'
           ,0)
GO
INSERT INTO [dbo].[TMCCM_C_Persona_Sexo]
           ([TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('MUJER'
           ,0)
GO

-----INSERTAR C_Persona_Genero----
INSERT INTO [dbo].[TMCCM_C_Persona_Genero]
           ([TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('DESCONOCIDO'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Persona_Genero]
           ([TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('INDEFINIDO'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Persona_Genero]
           ([TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('MASCULINO'
           ,'0')
GO
INSERT INTO [dbo].[TMCCM_C_Persona_Genero]
           ([TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           ('FEMENINO'
           ,'0')
GO
-------INSERTAR C_Persona_Nacionalidad----
INSERT INTO [dbo].[TMCCM_C_Persona_Nacionalidad]
           ([TC_Descripcion]
           ,[TF_Fecha_Creacion])
     VALUES
           ('OTRO O DESCONOCIDO'
           ,GETDATE())
GO
INSERT INTO [dbo].[TMCCM_C_Persona_Nacionalidad]
           ([TC_Descripcion]
           ,[TF_Fecha_Creacion])
     VALUES
           ('COSTA RICA'
           ,GETDATE())
GO
INSERT INTO [dbo].[TMCCM_C_Persona_Nacionalidad]
           ([TC_Descripcion]
           ,[TF_Fecha_Creacion])
     VALUES
           ('ABJASIA'
           ,GETDATE())
GO
////Catalogo_Tipo_Droga
INSERT INTO [dbo].[TMCCM_C_Droga_Tipo_Droga]
           ([TF_Fecha_Creacion]
           ,[TC_Nombre]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           (GETDATE()
           ,'Alcohol'
           ,'Bebida que contiene alcohol etílico.'
           ,1)
GO
INSERT INTO [dbo].[TMCCM_C_Droga_Tipo_Droga]
           ([TF_Fecha_Creacion]
           ,[TC_Nombre]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           (GETDATE()
           ,'Tabaco'
           ,'Hoja de esta planta que, curada y preparada, se fuma, se masca o se aspira en forma de rapé.'
           ,1)
GO
INSERT INTO [dbo].[TMCCM_C_Droga_Tipo_Droga]
           ([TF_Fecha_Creacion]
           ,[TC_Nombre]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           (GETDATE()
           ,'Marihuana'
           ,'Una sustancia química que proviene de una planta llamada cannabis'
           ,1)
GO
INSERT INTO [dbo].[TMCCM_C_Droga_Tipo_Droga]
           ([TF_Fecha_Creacion]
           ,[TC_Nombre]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           (GETDATE()
           ,'Cocaína'
           ,'Droga derivada de la planta de coca un adicto a la cocaína'
           ,1)
GO
INSERT INTO [dbo].[TMCCM_C_Droga_Tipo_Droga]
           ([TF_Fecha_Creacion]
           ,[TC_Nombre]
           ,[TC_Descripcion]
           ,[TB_Eliminado])
     VALUES
           (GETDATE()
           ,'Crack'
           ,'Droga de aspecto sólido derivada de la cocaína y altamente adictiva.'
           ,1)
GO

ALTER TABLE TMCCM_Entidad_Persona_Juridica
ADD CONSTRAINT FK_TMCCM_Caso_REL_TMCCM_Entidad_Persona_Juridica Foreign Key(TN_ID_Caso) references TMCCM_Caso(TN_ID_Caso)







