CREATE DATABASE BDCRIMINALISTICA

USE BDCRIMINALISTICA


CREATE TABLE UNIDADSISTEMA(
id int NOT NULL IDENTITY PRIMARY KEY,
nombre varchar(150) NOT NULL)

CREATE TABLE ROL(
id int NOT NULL IDENTITY PRIMARY KEY,
nombre varchar(50) NOT NULL,
activo bit NOT NULL)

CREATE TABLE USUARIOCRIMINALISTICA(
id int NOT NULL IDENTITY PRIMARY KEY,
userCreaRepo int NOT NULL,
usuarioRepo int,
fechaAlta datetime NOT NULL,
persona int NULL,
civil int NULL,
norDni int NULL,
nombre varchar(50) NULL,
apellido varchar(50) NULL,
tipoPersona bit NULL,
fechaBaja datetime NULL,
usuarioBaja int NULL,
baja bit NULL,
sistema int FOREIGN KEY REFERENCES UNIDADSISTEMA(id),
cifrado varchar(250),
fechaVinculacion datetime NULL,
rol int FOREIGN KEY REFERENCES ROL(id),
activo bit NOT NULL)

CREATE TABLE ESTADO(
id int NOT NULL IDENTITY PRIMARY KEY,
nombre varchar(50) NOT NULL,
activo bit NOT NULL)

CREATE TABLE EXPEDIENTE(
id int NOT NULL IDENTITY PRIMARY KEY,
fechaExpte datetime NOT NULL,
nroNota varchar(50) NOT NULL,
origenExpte varchar(50) NOT NULL,
extracto varchar(150) NOT NULL,
nroIntervencion varchar(150) NULL,
informeTecnico varchar(150) NULL,
peritoInterviniente int NULL,
tipoPericia varchar(50) NOT NULL,
estadoExpte int FOREIGN KEY REFERENCES ESTADO(id),
observacion varchar(150) NULL,
fechaCreacion datetime NOT NULL,
usuarioCrea int FOREIGN KEY REFERENCES USUARIOCRIMINALISTICA(id),
fechaModificacion datetime NULL,
usuarioModifica int FOREIGN KEY REFERENCES USUARIOCRIMINALISTICA(id),
fechaBaja datetime NULL,
usuarioBaja int FOREIGN KEY REFERENCES USUARIOCRIMINALISTICA(id),
activo bit NOT NULL)

CREATE TABLE MOVIMIENTOEXPTE(
id int NOT NULL IDENTITY PRIMARY KEY,
expte int FOREIGN KEY REFERENCES EXPEDIENTE(id),
destinoPolicial int NULL,
destinoNoPolicial varchar(150) NULL,
fechaEnvio datetime NULL,
usuarioEnvia int FOREIGN KEY REFERENCES USUARIOCRIMINALISTICA(id),
fechaRecepcion datetime NULL,
usuarioRecibe int FOREIGN KEY REFERENCES USUARIOCRIMINALISTICA(id),
tipoMovimiento varchar(50) NULL,
observaciones varchar(150) NULL,
activo bit NOT NULL)