USE Projekt_CLR_UDT;
GO

CREATE ASSEMBLY Projekt_CLR FROM
	 'C:\Projekt_CLR_UDT\Projekt\bin\Release\Projekt.dll'
GO

CREATE TYPE [dbo].[Animal]
EXTERNAL NAME [Projekt_CLR].[Projekt.Animal];
GO

CREATE TYPE [dbo].[Address]
EXTERNAL NAME [Projekt_CLR].[Projekt.Address];
GO

CREATE TYPE [dbo].[EmailAddress]
EXTERNAL NAME [Projekt_CLR].[Projekt.EmailAddress];
GO

CREATE TYPE [dbo].[DangerDocument]
EXTERNAL NAME [Projekt_CLR].[Projekt.DangerDocument];
GO

CREATE TYPE [dbo].[CITESDocument]
EXTERNAL NAME [Projekt_CLR].[Projekt.CITESDocument];
GO

CREATE TYPE [dbo].[Enclosure]
EXTERNAL NAME [Projekt_CLR].[Projekt.Enclosure];
GO

CREATE FUNCTION [dbo].[CheckClientAbility](@owner_id INT, @anim_danger INT) RETURNS INT
EXTERNAL NAME [Projekt_CLR].[Projekt.Funkcje].[CheckClientAbility];
GO