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

# EndPoint's
## Usuario
{
    "Nome": "user4",
    "Login": "user4@gmail.com",
    "Senha": "11111",
    "IsAdmin": 0
}
### Post, Put
http://localhost:{port}/api/usuario

### Get, Delete
http://localhost:{port}/api/usuario/{id}

http://localhost:{port}/api/usuario
http://localhost:{port}/api/usuario

## LogAcesso
http://localhost:49436/api/logacesso/1


