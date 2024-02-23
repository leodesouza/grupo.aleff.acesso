# Orientações para Executar o Projeto

#Banco de Dados
<add name="AleffBD" connectionString="Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=master;Integrated Security=True;" providerName="System.Data.SqlClient" />

# Script Tabelas e Insert do Admin 
CREATE TABLE [dbo].[Usuario]
(
	[UsuarioId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Nome] VARCHAR(50) NOT NULL, 
    [Login] VARCHAR(50) NOT NULL, 
    [Senha] VARCHAR(50) NOT NULL, 
    [IsAdmin] BIT NULL
)


CREATE TABLE [dbo].[LogAcesso] (
    [LogAcessoId]    INT      IDENTITY (1, 1) NOT NULL,
    [UsuarioId]      INT      NOT NULL,
    [DataHoraAcesso] DATETIME NOT NULL,
    [EnderecoIp ] VARCHAR(50) NOT NULL, 
    PRIMARY KEY CLUSTERED ([LogAcessoId] ASC)
);

INSERT INTO USUARIO(Nome, Login, Senha, IsAdmin) VALUES('admin2','admin.root','123456', 1)
