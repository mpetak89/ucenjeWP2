use master
go
drop database if exists obitelj;
go
create database obitelj;
go
alter database obitelj collate Croatian_CI_AS;
go
use  obitelj
go
create table sestra (
sifra int not null primary key identity (100,1),
introvertno bit,
haljina varchar (31) not null,
maraka decimal (16,6),
hlace varchar (46),
narukvica int)

create table punac (
sifra int not null primary key identity (200,1),
ogrlica int, 
gustoca decimal (14,9),
hlace varchar (41) not null);

create table zena(
sifra int not null primary key identity (300,1),
treciputa datetime,
hlace varchar (46),
kratkamajica varchar (31) not null,
jmbag char (11) not null,
bojaociju varchar (39) not null,
haljina varchar (44),
sestra int not null)

create table cura (
sifra int not null primary key identity (400,1),
novcica decimal (16,5) not null,
gustoca decimal (18,6) not null,
lipa decimal (13,10),
ogrlica int not null,
bojakose varchar (38), 
suknja varchar (36),
punac int)


create table muskarac (
sifra int not null identity (600,1) primary key,
bojaociju varchar (50) not null,
hlace varchar (30),
modelhlaca varchar (43),
maraka decimal (14,3),
zena int not null)

create table svekar (
sifra int not null identity (700,1) primary key,
bojaociju varchar (40) not null,
prstena int,
dukserica varchar (41),
lipa decimal (13,8),
eura decimal (12,7),
majica varchar (35))

create table mladic (
sifra int not null identity (800,1) primary key,
suknja varchar (50) not null,
kuna decimal (16,8) not null,
drugiputa datetime, 
asocijalno bit,
ekstroventno bit not null,
dukserica varchar (48) not null,
muskarac int not null)

alter table mladic add primary key (sifra)

create table sestra_svekar(
sifra int not null identity (500,1)  primary key,
sestra int not null,
svekar int not null)

alter table zena add foreign key (sestra) references sestra (sifra)
alter table cura add foreign key (punac) references punac (sifra)
alter table muskarac add foreign key (zena) references zena (sifra)
alter table sestra_svekar add foreign key (sestra) references sestra (sifra)
alter table sestra_svekar add foreign key (svekar) references svekar (sifra)
alter table mladic add foreign key (muskarac) references muskarac (sifra)


--U tablice muskarac, zena i sestra_svekar unesite po 3 retka. (7)
select*from sestra

insert into sestra values (1,'krinolina','105.88', 'traperice', '25550')
insert into sestra values (0,'kratka','105.88', 'traperice', '25550')
insert into sestra values (1,'duga','15.88', 'trapez', '552')

insert into zena values ('2023-01-01','traperice','top', '97254109818', 'zelena','minica', '100')
insert into zena values ('2020-01-23','tajice','t-shirt', '91431612151', 'plava','sky', '101')
insert into zena values ('2018-11-11','trapez','košulja', '85156256284', 'smeđa','duga', '102')
insert into zena values ('2018-11-11','slana','košulja', '85156256284', 'smeđa','duga', '102')
select*from zena

insert into muskarac values ('zelena','traperice','levis', '100.11', '300')
insert into muskarac values ('plava','trapez','bama', '555.11', '302')
insert into muskarac values ('smeđa','traperice','kinez', '8522.211', '301')
select*from muskarac


insert into svekar values ('plava', '5', 'plava', '111.55', '10', 's')
insert into svekar values ('crna', '1', 'duga', '558.55', '14', 'm')
insert into svekar values ('smeđa', '5', 'bijela', '5552', '88', 'l')
select*from svekar

insert into sestra_svekar values ('100','701')
insert into sestra_svekar values ('101','703')
insert into sestra_svekar values ('102','702')
select*from sestra_svekar

insert into mladic values ('krinolina','105.88', 1, 'traperice', '25550')
insert into mladic values ('kratka','105.88', 0, 'traperice', '25550')
insert into mladic values ('duga','15.88', 0, 'trapez', '552')


--tablici cura postavite svim zapisima kolonu gustoca na vrijednost 15,77. (4)

update cura set gustoca = '15.77'

--U tablici mladic obrišite sve zapise čija je vrijednost kolone kuna veće od 15,78. (4)

insert into mladic values ('kratka', '10.10', null, null, 1, 'zelena', '602')
insert into mladic values ('duga', '15.78', null, null, 0, 'plava', '603')
insert into mladic values ('polukraka', '16.10', null, null, 1, 'zuta', '604')
insert into mladic values ('polukraka', '15.77', '2023-03-14', null, 1, 'zuta', '604')

update mladic set kuna='5.5' where sifra = 807

select*from mladic

delete from mladic where kuna >= '15.78'

--4. Izlistajte kratkamajica iz tablice zena uz uvjet da vrijednost kolone hlace sadrže slova ana. 

select kratkamajica
from zena
where hlace like '%ana%'


--Prikažite dukserica iz tablice svekar, asocijalno iz tablice mladic te hlace iz tablice muskarac 
--uz uvjet da su vrijednosti kolone hlace iz tablice zena sadrže niz znakova tr te da vrijednosti 
--kolone haljina iz tablice sestra počinju slovom a. Podatke posložite po hlace iz tablice muskarac silazno

select f.dukserica, a.hlace, b.asocijalno, c.hlace
from muskarac a 
inner join mladic b on a.sifra=b.muskarac
inner join zena c on c.sifra=a.zena
inner join sestra d on d.sifra=c.sestra
inner join sestra_svekar e on e.sestra=d.sifra
inner join svekar f on f.sifra=e.svekar
where c.hlace like 'tr%' and d.haljina like'%a%'
order by 2 desc

;--Prikažite kolone haljina i maraka iz tablice sestra čiji se primarni ključ 
--ne nalaze u tablici sestra_svekar. (5)

select haljina, maraka
from sestra 
