USE Projekt_CLR_UDT;
GO

CREATE TABLE "Narzędzie"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "nazwa" NVARCHAR(255) NOT NULL,
    "szczegóły" NVARCHAR(255) NOT NULL,
	"ilosc" INT NOT NULL,
    "price" INT NOT NULL
);
ALTER TABLE
    "Narzędzie" ADD CONSTRAINT "narzędzie_id_primary" PRIMARY KEY("id");

CREATE TABLE "Klient"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "imie" NVARCHAR(255) NOT NULL,
    "nazwisko" NVARCHAR(255) NOT NULL,
    "adres" [dbo].[Address] NOT NULL,
    "email" [dbo].[EmailAddress] NOT NULL
);
ALTER TABLE
    "Klient" ADD CONSTRAINT "klient_id_primary" PRIMARY KEY("id");

CREATE TABLE "Pojemnik"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "pojemnik" [dbo].[Enclosure] NOT NULL,
	"ilosc" INT NOT NULL,
    "cena" INT NOT NULL
);
ALTER TABLE
    "Pojemnik" ADD CONSTRAINT "pojemnik_id_primary" PRIMARY KEY("id");

CREATE TABLE "Zwierzę"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "zwierzak" [dbo].[Animal] NOT NULL,
	"ilosc" INT NOT NULL,
    "cena" INT NOT NULL
);
ALTER TABLE
    "Zwierzę" ADD CONSTRAINT "zwierzę_id_primary" PRIMARY KEY("id");

CREATE TABLE "Przedmioty"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "zamówienie_id" INT NOT NULL,
	"zwierze_id" INT NULL,
	"pojemnik_id" INT NULL,
	"narzedzie_id" INT NULL

);
ALTER TABLE
    "Przedmioty" ADD CONSTRAINT "przedmioty_id_primary" PRIMARY KEY("id");

CREATE TABLE "Zamówienie"(
	"id" INT IDENTITY(1,1) NOT NULL,
	"klient_id" INT NOT NULL,
	"ilość" INT NOT NULL,
	"data_wysyłki" NVARCHAR(MAX) NOT NULL,
	"data_otrzymania" NVARCHAR(MAX) NULL
);
ALTER TABLE
	"Zamówienie" ADD CONSTRAINT "zamówienie_id_primary" PRIMARY KEY("id");

CREATE TABLE "Hodowla"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "klient_id" INT NOT NULL,
    "zwierzak" [dbo].[Animal] NOT NULL,
    "DangerDocument" [dbo].[DangerDocument] NULL,
    "CITES" [dbo].[CITESDocument] NULL
);
ALTER TABLE
    "Hodowla" ADD CONSTRAINT "hodowla_id_primary" PRIMARY KEY("id");
ALTER TABLE
    "Zamówienie" ADD CONSTRAINT "zamówienie_klient_id_foreign" FOREIGN KEY("klient_id") REFERENCES "Klient"("id");
ALTER TABLE
	"Przedmioty" ADD CONSTRAINT "przedmioty_zwierze_id_foreign" FOREIGN KEY("zwierze_id") REFERENCES "Zwierzę"("id");
ALTER TABLE
	"Przedmioty" ADD CONSTRAINT "przedmioty_pojemnik_id_foreign" FOREIGN KEY("pojemnik_id") REFERENCES "Pojemnik"("id");
ALTER TABLE
	"Przedmioty" ADD CONSTRAINT "przedmioty_narzedzie_id_foreign" FOREIGN KEY("narzedzie_id") REFERENCES "Narzędzie"("id");
ALTER TABLE 
	"Przedmioty" ADD CONSTRAINT "przedmioty_zamówienie_id_foreign" FOREIGN KEY("zamówienie_id") REFERENCES "Zamówienie"("id");
ALTER TABLE
    "Hodowla" ADD CONSTRAINT "hodowla_klient_id_foreign" FOREIGN KEY("klient_id") REFERENCES "Klient"("id");
GO

CREATE TRIGGER [dbo].[ValidateAnimals] ON [dbo].[Hodowla] FOR INSERT 
AS EXTERNAL NAME [Projekt_CLR].[Projekt.Wyzwalacze].[ValidateAnimal];
GO

CREATE TRIGGER [dbo].[UpdateHodowla] ON [dbo].[Przedmioty] FOR INSERT
AS EXTERNAL NAME [Projekt_CLR].[Projekt.Wyzwalacze].[UpdateHodowla];
GO

CREATE TRIGGER [dbo].[UpdateHodowlaDate] ON [dbo].[Zamówienie] FOR UPDATE
AS EXTERNAL NAME [Projekt_CLR].[Projekt.Wyzwalacze].[UpdateHodowlaDate]
GO

CREATE TRIGGER [dbo].[RemoveItem] ON [dbo].[Przedmioty] FOR INSERT
AS EXTERNAL NAME [Projekt_CLR].[Projekt.Wyzwalacze].[RemoveItem]
GO


