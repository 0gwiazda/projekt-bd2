USE Projekt_CLR_UDT;
GO

DROP TABLE "Przedmioty"
DROP TABLE "Zam�wienie";
DROP TABLE "Pojemnik";
DROP TABLE "Narz�dzie";
DROP TABLE "Hodowla";
DROP TABLE "Zwierz�";
DROP TABLE "Klient";



ALTER ASSEMBLY Projekt_CLR FROM
	 'C:\Projekt_CLR_UDT\Projekt\bin\Release\Projekt.dll'
GO
