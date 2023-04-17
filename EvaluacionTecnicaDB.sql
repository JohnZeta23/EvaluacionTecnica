CREATE DATABASE EvaluacionTecnicaDB

CREATE TABLE Usuarios(
	Id INT PRIMARY KEY NOT NULL,
	RoleId INT FOREIGN KEY REFERENCES Roles(id) ON DELETE CASCADE NOT NULL,
	Nombre NVARCHAR(max) NULL,
	Apellido NVARCHAR(max) NULL,
	Cedula VARCHAR(50) NULL,
	Usuario_Nombre VARCHAR(16) NULL,
	Contraseña NVARCHAR(max) NULL,
	Fecha_Nacimiento DATETIME NOT NULL,
	Usuario_Transaccion NVARCHAR(max) DEFAULT ('USER') NULL,
	Fecha_Transaccion DATETIME DEFAULT (getdate()) NOT NULL)

CREATE UNIQUE NONCLUSTERED INDEX IX_Cedula ON Usuarios(Cedula ASC)
CREATE NONCLUSTERED INDEX IX_Fecha_Nacimiento ON Usuarios(Fecha_Nacimiento ASC)
CREATE NONCLUSTERED INDEX IX_RoleId ON Usuarios(RoleId ASC)
CREATE UNIQUE NONCLUSTERED INDEX IX_Usuario_Nombre ON Usuarios(Usuario_Nombre ASC)

CREATE TABLE Roles(
	Id INT PRIMARY KEY NOT NULL,
	Nombre NVARCHAR(max) NULL,
	Usuario_Transaccion NVARCHAR(max) DEFAULT ('USER') NULL,
	Fecha_Transaccion DATETIME DEFAULT (getdate()) NOT NULL)


INSERT INTO Roles(Id,Nombre) VALUES(1,'ADMIN')
INSERT INTO Roles(Id,Nombre) VALUES(2,'DESARROLLADOR')

INSERT INTO Usuarios(Id,RoleId,Nombre,Apellido,Cedula,Usuario_Nombre,Contraseña,Fecha_Nacimiento) 
VALUES(1,1,'Simetrica','Consulting','25322522135','ADMIN','ADMIN','01-01-1990')
INSERT INTO Usuarios(Id,RoleId,Nombre,Apellido,Cedula,Usuario_Nombre,Contraseña,Fecha_Nacimiento)  
VALUES(2,2,'John','Consulting','0000000000','DESARROLLADOR','APLICANTE','02-25-2000')
