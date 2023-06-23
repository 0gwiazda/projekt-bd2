USE Projekt_CLR_UDT
GO


--SELECT "Imie", "Nazwisko", "Address".ToString(), "Email".ToString() FROM "Klient";

--SELECT "zwierzak".ToString(), "DangerDocument".ToString(), "CITES".ToString() FROM "Hodowla" JOIN "Klient" ON "Hodowla"."klient_id" = "Klient"."id";

--SELECT "zwierzak".ToString() FROM "Zwierzê";

--SELECT * FROM "Narzêdzie";

--SELECT "pojemnik".ToString() FROM "Pojemnik";

--SELECT * FROM "Zamówienie";

SELECT "zwierzak".ToString() FROM "Zwierzê" WHERE "zwierzak".Filter('maturity','2') = 1;

SELECT "pojemnik".ToString() FROM "Pojemnik" WHERE "pojemnik".Filter('enviroment','tropikalne') = 1;

SELECT "DangerDocument".ToString() FROM "Hodowla" WHERE "DangerDocument".Filter('owner','Adam Kowalski') = 1;


SELECT "zwierzak".ToString() AS pet FROM "Hodowla" WHERE "klient_id" = 3 AND "zwierzak".checkDanger(6) = -1

SELECT dbo.CheckClientAbility(3,8);

INSERT INTO "Hodowla"("id","klient_id" ,"zwierzak", "DangerDocument", "CITES") VALUES (9,3,'Tiltocatl,vagans,0,2,3,1,true',NULL,NULL);

SELECT "zwierzak".ToString() FROM "Hodowla" WHERE klient_id = 3;
SELECT COUNT(*) FROM "Hodowla" WHERE ("zwierzak".Endangered = 1 AND "CITES" IS NULL) OR ("zwierzak".Danger = 10 AND "DangerDocument" IS NULL)


SELECT "zwierzak".ToString(), "CITES".ToString(), "DangerDocument".ToString() FROM "Hodowla";

SELECT * FROM "Zamówienie" WHERE "Zamówienie"."klient_id" = 3
SELECT "zwierzak".ToString() FROM "Hodowla" WHERE "Hodowla"."klient_id" = 3

UPDATE "Zamówienie" SET "data_otrzymania" = '25.11.2019' WHERE "Zamówienie"."id" = 5


SELECT * FROM "Narzêdzie";
