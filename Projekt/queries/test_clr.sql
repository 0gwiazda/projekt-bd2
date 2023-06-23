
CREATE ASSEMBLY Projekt_CLR FROM
	'C:\Projekt\bin\Release\Projekt.dll'
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

CREATE TABLE test(ID int IDENTITY(1,1) PRIMARY KEY, Pet Animal, Addr Address, email EmailAddress, Danger DangerDocument, CITES CITESDocument, Terra Enclosure)

INSERT INTO test(Pet, Addr, email, Danger, CITES, Terra) VALUES ('Pterinochilus,murinus,0,2,3,8,false', 'ul. Testowo 34,Rzeplin,32-043,Skala', 'test@gmail.com','Adam Kowalski;Heteroscodra,maculata,0,1,2,8,false;20.03.2001','Heterometrus,silenus,1,0,1,2,false;0;Adam Kowalski;20.08.2003','terrarium,30x30x30,false,');
GO

SELECT ID, Pet.ToString()  AS Animal, Addr.ToString() AS Address, email.ToString() AS Email, Danger.ToString() AS DangerDocument, CITES.ToString() AS CITESDocument, Terra.ToString() AS Enclosure
FROM test;
GO


SELECT ID, (Pet.Family + ' ' + Pet.Species) AS Animal, Addr.Code AS Code, email.ToString() AS Email, Danger.Pet.ToString() AS DangerPet, CITES.Owner AS Owner, Terra.Type AS Enclosure
FROM test;
GO

DROP TABLE dbo.test;
DROP TYPE dbo.Animal;
DROP TYPE dbo.Address;
DROP TYPE dbo.EmailAddress;
DROP TYPE dbo.DangerDocument;
DROP TYPE dbo.CITESDocument;
DROP TYPE dbo.Enclosure;
DROP FUNCTION dbo.CheckClientAbility;
DROP ASSEMBLY Projekt_CLR;