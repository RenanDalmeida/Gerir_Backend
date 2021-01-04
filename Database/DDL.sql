--Criar Banco de Dados
CREATE DATABASE Gerir;

USE Gerir

--Criar tabela Usuário
CREATE TABLE Usuarios(
	id UNIQUEIDENTIFIER PRIMARY KEY,
	nome VARCHAR(150) NOT NULL,
	email VARCHAR(150) NOT NULL,
	senha VARCHAR(150) not null,
	tipo VARCHAR(100) NOT NULL,
);

--Criar tabela Tarefas
CREATE TABLE Tarefas(
	id UNIQUEIDENTIFIER PRIMARY KEY,
	titulo VARCHAR(150) NOT NULL,
	categoria VARCHAR(150) NOT NULL,
	dataentrega DATETIME NOT NULL,
	status BIT NOT NULL,
	descricao TEXT NOT NULL,
--Adicionando Foreign Key Usuário
	usuario_id uniqueidentifier
	FOREIGN KEY(usuario_id) REFERENCES Usuarios(id) ON DELETE CASCADE
);

DROP DATABASE Gerir;
