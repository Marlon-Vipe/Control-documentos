create database PFINAL00

use PFINAL00

create table Usuarios (

		ID int identity primary key,
		Nombre varchar(33),
		Departamento int foreign key references Departamentos(ID),
		Cargo varchar(33)

)

create table Departamentos (

		ID int identity primary key,
		Nombre varchar(55),
		Siglas varchar(11),

)

create table Documentos(

			ID_Envio int not null identity primary key,
			Tipo_Documento varchar(30),
			Id_Usuario int foreign key references Usuarios(ID),
		    Id_DeptOrigen int foreign key references Departamentos(ID),
		    Id_DeptDestino int foreign key references Departamentos(ID),
		    Secuencia varchar(30),
		    Fecha date,
		    --constraint fk_EnvioDocumento_IdUsuario foreign key
		    --(Id_Usuario) references Usuarios (Id_Usuario) ON DELETE NO ACTION ON UPDATE NO ACTION,
		    --constraint fk_EnvioDocumento_IdDeptOrigen foreign key
		    --(Id_DeptOrigen) references Departamentos (Id_Departamento) ON DELETE NO ACTION ON UPDATE NO ACTION,
		    --constraint fk_EnvioDocumento_IdDeptDestino foreign key
		    --(Id_DeptDestino) references Departamentos (Id_Departamento) ON DELETE NO ACTION ON UPDATE NO ACTION,
)



drop table Documentos

select * from Usuarios

select * from Departamentos

select * from AspNetUsers

select * from Documentos

--delete from Usuarios where ID = 3; 

set ansi_nulls on

Go


Set Quoted_Identifier on
Go
Alter Procedure [PFINAL00].[Usuarios]
@Nombre varchar (33)
as
Begin
	Select * from Usuarios where Nombre = @Nombre
End

[PFINAL00].[Usuarios] Juan

Go

drop trigger DocumentSequence

--Trigger para secuencia de documentos

create trigger DocumentSequence on Documentos
after insert
as 
begin
 declare @userID int;
 declare @sendID int;
 Declare @TypeOfDocument varchar(50);
 declare @Date date;
 declare @DepartmentOfOrigin int;
 declare @DestinationOfDepartment int;
 declare @Sequence varchar(50);
 declare @AcronymOrigin varchar(4);
 declare @AcronymEnd varchar(4);

 Select @sendID = ID_Envio, @userID = Id_Usuario, @TypeOfDocument = Tipo_Documento, @Date = Fecha,

 @DepartmentOfOrigin = Id_DeptOrigen, @DestinationOfDepartment = Id_DeptDestino from inserted;

 set @AcronymOrigin =  (select Siglas from Departamentos  where ID = @DepartmentOfOrigin)

set @AcronymEnd =  (select Siglas from Departamentos  where ID = @DestinationOfDepartment)

Set @Sequence = cast(Year(@Date) as varchar(4))+'-'+@AcronymOrigin+'-'+@AcronymEnd+'-'+Cast(@sendID as varchar(4));

update Documentos set Secuencia = @Sequence where ID_Envio = @sendID;

end




--RANGO DE FECHA

Create procedure ByDateRange @StartYear varchar(40), @FinalYear varchar(40)

As
Begin

Select * from Documentos where Fecha Between @StartYear and @FinalYear

End

Go

--Exec ByDateRange


--drop trigger DeleteAll



-- Eliminar todos los usuarios que pertenezcan a un departamento cuando se elimine el mismo
create trigger DeleteAll on Departamentos

instead of delete
as

  begin

  delete from Documentos where Id_DeptOrigen in (select ID from deleted) or Id_DeptDestino in (select ID from deleted)

  delete from Usuarios where Departamento in (select ID from deleted)

  delete from Departamentos where ID in (select ID from deleted)

  end




-- Eliminar todos los usuarios que pertenezcan a un departamento cuando se elimine el mismo
create trigger DeleteDocuments on Usuarios
instead of delete
as

  begin

  delete from Documentos where Id_Usuario in (select ID from deleted)

  delete from Usuarios where ID in (select ID from deleted)

  end

  select * from AspNetUsers