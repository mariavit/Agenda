Create database AgendaContatos;

Use AgendaContatos;

Create table TipoContato (
	Codigo int not null primary key AUTO_INCREMENT,
	Descricao varchar(100) not null);

Create table Contato (
	Codigo int not null primary key AUTO_INCREMENT,
	Nome varchar(64) not null,
    Endereco varchar(100) not null,
    Bairro varchar(100) not null,
    Cidade varchar(100) not null,
    Estado varchar(100) not null,
    Telefone int not null,
    
	constraint Contato_TipoContato_fk foreign key (Codigo) references TipoContato(Codigo));

Insert into TipoContato ( Descricao) values ( 'Familia');
Insert into TipoContato ( Descricao) values ('Amigos');
Insert into TipoContato( Descricao) values ( 'Trabalho');
Insert into TipoContato ( Descricao) values ( 'Emergencia');



Insert into Contato(Nome, Endereco, Bairro, Cidade, Estado, Telefone, Codigo)
values('Maria', 'Rua João', 'Vila Maria', 'Matão', 'São Paulo', 99794-41485, 1);

Insert into Contato(Nome, Endereco, Bairro, Cidade, Estado, Telefone, Codigo)
values('Otavio', 'Rua Antonio', 'Centro', 'Matão', 'São Paulo', 99395-0485, 2);
