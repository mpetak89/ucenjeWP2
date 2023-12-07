use master
go
drop database if exists kolokvij3;
go
create database kolokvij3;
go
alter database kolokvij3 collate Croatian_CI_AS;
go
use  kolokvij3
go
create table svekar (
sifra int not null primary key identity (1000,1),
novcica decimal (16,8) not null,
skunja varchar (44) not null,
bojakose varchar (36), 
prstena int,
narukvica int not null,
cura int not null)

create table cura (
sifra int not null primary key identity (2000,1),
dukserica varchar (49), 
maraka decimal (13,7),
drugiputa datetime,
majica varchar (49),
novcica decimal (15,8),
ogrlica int not null)

create table snasa (
sifra int not null primary key identity (3000,1),
introvertno bit,
kuna decimal (15,6) not null,
eura decimal (12,9) not null,
treciputa datetime,
ostavljena int not null)

create table punica (
sifra int not null primary key identity (4000,1),
asocijalno bit,
kratkamajica varchar (44), 
kuna decimal (13,8) not null,
vesta varchar (32) not null,
snasa int )

create table ostavljena (
sifra int not null primary key identity (5000,1),
kuna decimal (17,5),
lipa decimal (15,6),
majica varchar (36),
modelnaocala varchar (31) not null,
prijatelj int )


create table prijatelj(
sifra int not null primary key identity (6000,1),
kuna decimal (16,10),
haljina varchar (37),
lipa decimal (13,10),
dukserica varchar (31),
indiferentno bit not null)

create table prijatelj_brat (
sifra int not null primary key identity (7000,1),
prijatelj int not null,
brat int not null)

create table brat (
sifra int not null primary key identity (8000,1),
jmbag char (11),
ogrlica int not null,
ekstrovertno bit not null)


alter table svekar add foreign key (cura) references cura (sifra)
alter table snasa add foreign key (ostavljena) references ostavljena (sifra)
alter table punica add foreign key (snasa) references snasa (sifra)
alter table ostavljena add foreign key (prijatelj) references prijatelj (sifra)
alter table prijatelj_brat add foreign key (prijatelj) references prijatelj (sifra)
alter table prijatelj_brat add foreign key (brat) references brat (sifra)


select*from prijatelj

insert into prijatelj values ('18.55','zelena','170.55','zelena', 1)
insert into prijatelj values ('45.55','duga','187.55','zelena',1)
insert into prijatelj values ('27.55','kratka','454.55','zelena',0)


insert into ostavljena values ('33.55','44.55','crvena','mačka','6007')
insert into ostavljena values ('33.55','44.55','zelena','kocka','6008')
insert into ostavljena values ('33.55','44.55','žuta','rayban','6009')
insert into ostavljena values ('33.55','9','žuta','rayban','6009')
insert into ostavljena values ('33.55','20','žuta','rayban','6007')

select*from ostavljena

insert into snasa values (null,'10.55','783.55',null, '5004')
insert into snasa values (1,'20.55','158.55', null, '5005')
insert into snasa values (0,'30.55','258.55','2023-11-11', '5006')

insert into brat values ('55642154542', '101', 1)
insert into brat values ('94342154542', '202', 1)
insert into brat values ('55896154542', '303', 0)

select*from cura

insert into prijatelj_brat values ('6007', '8001')
insert into prijatelj_brat values ('6008', '8002')
insert into prijatelj_brat values ('6009', '8003')

insert into cura values ('zelena', '11.88', '2023-11-12', 'plava', '411.58', '101')
insert into cura values ('plava', '115.88', '2023-08-12', 'siva', '171.58', '102')
insert into cura values ('smeđa', '18.88', '2020-11-08', 'zelena', '131.58', '103')

insert into svekar values ('10.55','zelena','plava', null, '101','2000')
insert into svekar values ('588.55','žuta','smeđa', '55', '103','2001')
insert into svekar values ('55.55','zelena','zelena', null, '102','2002')

update svekar set skunja='osijek' 

select*from snasa

insert into punica values (1,'ab','11.11','plava', '3007')
insert into punica values (0,'ac','22.11','plava', '3006')
insert into punica values (1,'ab','33.11','zelena', '3008')

select*from punica
delete from punica where kratkamajica='ab'

select * from ostavljena

update ostavljena set majica = 'plava' where sifra='5007'
update ostavljena set majica = 'siva' where sifra='5008'

select majica
from ostavljena where lipa not in (9,10,20,30,35)

