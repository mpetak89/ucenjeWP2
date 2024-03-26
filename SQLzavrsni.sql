use master;
go
drop database if exists banka;
go
Create database banka
go
use banka
alter database banka collate Croatian_CI_AS;
go
use banka;

create table krediti(
sifra_kredita int not null primary key,
vrsta_kredita varchar (100) not null);

create table komitenti (
sifra_komitenta int not null primary key identity(100,1),
OIB char (11) not null,
ime varchar (50) not null,
prezime varchar(50) not null,
datum_rodenja date not null,
ulica_stanovanja varchar (100) not null,
grad_stanovanja varchar (100) not null);

create table posudbe (
sifra_posudbe int not null primary key identity(978101,1),
datum_podizanja date not null,
datum_vracanja date,
iznos decimal(16,2),
kamata decimal (9,4),
sifra_kredita int foreign key references krediti(sifra_kredita),
sifra_komitenta int foreign key references komitenti (sifra_komitenta));

insert into krediti values (1125, 'kratkoročni')
insert into krediti values (1126, 'stambeni')
insert into krediti values (1127, 'hipotekarni')
insert into krediti values (1128, 'nenamjenski')

select*from krediti

insert into komitenti values ('01884354741', 'Jelena', 'Beštek',' 1976-07-01', 'Mišinačka 7, Brezovac','Bjelovar')
insert into komitenti values ('51532807967', 'Ankica', 'Petak',' 1963-12-27', 'Mišinačka 5, Brezovac','Bjelovar')
insert into komitenti values ('42743586705', 'Kristina', 'Farkaš','1978-08-06', 'Matošev trg 17','Bjelovar')
insert into komitenti values ('44334088589', 'Tina', 'Smoljanović','1980-03-24', 'Ulica Javora 5, Strmac','Zagreb')

select*from komitenti

insert into posudbe values ('2020-07-01', null, 15000.00, 4.1, 1128, 101)
insert into posudbe values ('2021-12-24', null, 7500000.00, 3.1, 1126, 102)
insert into posudbe values ('1999-12-20', '2023-09-11', 100000.00, 3.1, 1127, 101)
insert into posudbe values ('2020-01-24', null, 1000000.00, 5.158, 1128, 103)
insert into posudbe values ('2022-11-20', null, 10000.00, 4.11, 1125, 100)

select*from posudbe

update posudbe set iznos=iznos+100000 where sifra_posudbe = 978101
