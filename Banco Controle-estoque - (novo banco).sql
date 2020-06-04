create database controleEstoque

use controleEstoque

create table Departamentos (
	Codigo varchar (15) primary key,
	Cnpj varchar (20),
	Nome varchar (30),
	Data  varchar(10),
	NomeFantasia varchar (15)
);

create table Produtos(
	Codigo varchar (15) primary key,
	Nome varchar (30),
	ValorCompra varchar (10),
	ValorVenda varchar (10),
	QntEstoque int,
	Descricao varchar (200),
	Departamento varchar (15),
	foreign key (Departamento) references Departamentos(Codigo)
);


create table Login (
	Usuario varchar (10),
	Senha varchar (10)
);


select * from Login

insert into Login values ('Admin', '123456')
 
drop table Departamentos

