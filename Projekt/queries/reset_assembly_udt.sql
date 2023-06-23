USE Projekt_CLR_UDT;
GO

DROP TABLE "Przedmioty"
DROP TABLE "Zamówienie";
DROP TABLE "Pojemnik";
DROP TABLE "Narzêdzie";
DROP TABLE "Hodowla";
DROP TABLE "Zwierzê";
DROP TABLE "Klient";



ALTER ASSEMBLY Projekt_CLR FROM
	 'C:\Projekt_CLR_UDT\Projekt\bin\Release\Projekt.dll'
GO
