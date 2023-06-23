USE Projekt_CLR_UDT;
GO

INSERT INTO "Klient"("imie", "nazwisko", "email", "adres") VALUES ('Adam','Kowalski', 'adam@gmail.com', 'ul. testowa 34,Skala,32-043,Skala')
INSERT INTO "Klient"("imie", "nazwisko", "email", "adres") VALUES ('Jan','Nowak', 'jan@gmail.com', 'ul. testowa 38,Skala,32-043,Skala')
INSERT INTO "Klient"("imie", "nazwisko", "email", "adres") VALUES ('Grzegorz','Brzeczyszczykiewicz','istartedwar@gmail.com','ul. Wojenna 39,Zakopane,19-419,Zakopane')

INSERT INTO "Hodowla"("klient_id","zwierzak","DangerDocument","CITES") VALUES (1, 'Chromatopelma,cyaneopubescens,0,2,3,0,1,false',NULL,NULL);
INSERT INTO "Hodowla"("klient_id","zwierzak","DangerDocument","CITES") VALUES (1, 'Latrodectus,mactans,0,2,3,0,10,false','Adam Kowalski;Latrodectus,mactans,0,2,3,0,10,false;20.01.2009',NULL);
INSERT INTO "Hodowla"("klient_id","zwierzak","DangerDocument","CITES") VALUES (1, 'Tiltocatl,albopilosum,0,1,3,0,1,true',NULL,'Adam Kowalski;Tiltocatl,albopilosum,0,1,3,0,1,true;01.03.2003');

INSERT INTO "Hodowla"("klient_id","zwierzak","DangerDocument","CITES") VALUES (2, 'Ophiophagus,hannah,5,1,2,0,10,false','Jan Nowak;Ophiophagus,hannah,5,1,2,0,10,false;04.02.2012',NULL);
INSERT INTO "Hodowla"("klient_id","zwierzak","DangerDocument","CITES") VALUES (2, 'Chlamydosaurus,kingii,0,2,3,0,2,false',NULL,NULL);

INSERT INTO "Hodowla"("klient_id","zwierzak","DangerDocument","CITES") VALUES (3, 'Chromatopelma,cyaneopubescens,0,2,3,0,1,false',NULL,NULL);
INSERT INTO "Hodowla"("klient_id","zwierzak","DangerDocument","CITES") VALUES (3, 'Brachypelma,emilia,0,0,1,0,1,true',NULL,'Grzegorz Brzeczyszczykiewicz;Brachypelma,emilia,0,0,1,0,1,true;12.09.2015');
INSERT INTO "Hodowla"("klient_id","zwierzak","DangerDocument","CITES") VALUES (3, 'Brachypelma,hamorii,0,1,2,0,1,true',NULL,'Grzegorz Brzeczyszczykiewicz;Brachypelma,hamorii,0,1,2,0,1,true;15.10.2015');

--INSERT INTO "Hodowla"("id", "klient_id","zwierzak","DangerDocument","CITES") VALUES (1, 1, 'Psalmopoeus,irminia,0,2,3,1,false',NULL,NULL);

INSERT INTO "Zwierzê"("zwierzak","ilosc","cena") VALUES ('Brachypelma,hamorii,0,2,3,0,1,true',10,120);
INSERT INTO "Zwierzê"("zwierzak","ilosc", "cena") VALUES ('Poecilotheria,metallica,0,2,3,0,6,false',3,400);
INSERT INTO "Zwierzê"("zwierzak","ilosc", "cena") VALUES ('Poecilotheria,regalis,0,1,2,0,6,false',1,250);
INSERT INTO "Zwierzê"("zwierzak","ilosc", "cena") VALUES ('Rhacodactylus,auriculatus,6,1,3,0,3,false',5,600);
INSERT INTO "Zwierzê"("zwierzak","ilosc", "cena") VALUES ('Galeodes,granti,2,0,2,0,5,false',1,300);
INSERT INTO "Zwierzê"("zwierzak","ilosc", "cena") VALUES ('Damon,diadema,3,2,3,0,0,false',4,160);

INSERT INTO "Pojemnik"("pojemnik","ilosc","cena") VALUES ('terrarium,30x30x30,false,', 10, 200);
INSERT INTO "Pojemnik"("pojemnik","ilosc","cena") VALUES ('terrarium,20x20x40,false,', 10, 120);
INSERT INTO "Pojemnik"("pojemnik","ilosc","cena") VALUES ('terrarium,40x40x30,true,tropical', 10, 650);

INSERT INTO "Narzêdzie"("nazwa", "szczegó³y", "ilosc", "price") VALUES ('tweezers', '30 cm, metal, hard', 100, 20);
INSERT INTO "Narzêdzie"("nazwa", "szczegó³y", "ilosc", "price") VALUES ('tweezers', '15 cm, metal, soft', 100, 10);
INSERT INTO "Narzêdzie"("nazwa", "szczegó³y", "ilosc", "price") VALUES ('thermometer', 'electric, outside thermometer with small measuring device', 20, 50);
INSERT INTO "Narzêdzie"("nazwa", "szczegó³y", "ilosc", "price") VALUES ('water dish', 'medium, shallow, in shape of a rock', 100, 20);

INSERT INTO "Zamówienie"("klient_id", "iloœæ", "data_wysy³ki", "data_otrzymania") VALUES (1, 3, '20.03.2012','23.03.2012'); 
INSERT INTO "Zamówienie"("klient_id", "iloœæ", "data_wysy³ki", "data_otrzymania") VALUES (1, 1, '25.05.2013','27.05.2013');
INSERT INTO "Zamówienie"("klient_id", "iloœæ", "data_wysy³ki", "data_otrzymania") VALUES (2, 2, '20.09.2015','23.09.2015');
INSERT INTO "Zamówienie"("klient_id", "iloœæ", "data_wysy³ki", "data_otrzymania") VALUES (2, 1, '20.10.2015','23.10.2015');
INSERT INTO "Zamówienie"("klient_id", "iloœæ", "data_wysy³ki", "data_otrzymania") VALUES (3, 1, '20.11.2019', NULL);

INSERT INTO "Przedmioty"("zamówienie_id","zwierze_id","pojemnik_id","narzedzie_id") VALUES (1, 2, NULL, NULL);
INSERT INTO "Przedmioty"("zamówienie_id","zwierze_id","pojemnik_id","narzedzie_id") VALUES (2, NULL, 2, NULL);
INSERT INTO "Przedmioty"("zamówienie_id","zwierze_id","pojemnik_id","narzedzie_id") VALUES (2, NULL, 1, NULL);

INSERT INTO "Przedmioty"("zamówienie_id","zwierze_id","pojemnik_id","narzedzie_id") VALUES (3, 4, NULL, NULL);
INSERT INTO "Przedmioty"("zamówienie_id","zwierze_id","pojemnik_id","narzedzie_id") VALUES (4, 1, 1, 2);
INSERT INTO "Przedmioty"("zamówienie_id","zwierze_id","pojemnik_id","narzedzie_id") VALUES (4, NULL, 2, 1);

INSERT INTO "Przedmioty"("zamówienie_id","zwierze_id","pojemnik_id","narzedzie_id") VALUES (5,5,1,1);
