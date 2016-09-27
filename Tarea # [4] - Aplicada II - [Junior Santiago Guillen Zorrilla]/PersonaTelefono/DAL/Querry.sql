create table Personas(
PersonasId int primary key identity,
Nombres varchar(50),
Sexo varchar(1)
);
 
go

create table PersonasTelefonos(
id int primary key identity,
PersonasId int references Personas(PersonasId),
TipoTelefono varchar(10),
Telefono varchar(13)
);