CREATE TABLE [dbo].[Usuario]
(
	[UsuarioId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Nome] VARCHAR(50) NOT NULL, 
    [Login] VARCHAR(50) NOT NULL, 
    [Senha] VARCHAR(50) NOT NULL, 
    [IsAdmin] BIT NULL
)


CREATE TABLE [dbo].[LogAcesso]
(
	[LogAcessoId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [UsuarioId] INT NOT NULL, 
    [DataHoraAcesso] DATETIME NOT NULL
)
