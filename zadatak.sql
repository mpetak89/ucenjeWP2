use master
drop database if exists zadatak;
go
create database zadatak
go
alter database zadatak collate Croatian_CI_AS;
go
use zadatak;

create table zupanija (
sifrazup int primary key not null,
naziv varchar (50) not null,
zupan varchar (50) not null,
);

create table opcina (
sifraopc int primary key identity (1001, 1) not null,
naziv varchar (50) not null,
sifrazup int not null foreign key references zupanija (sifrazup) 
);

create table mjesto (
sifra int primary key identity (200, 1) not null,
naziv varchar (50) not null,
sifraopc int not null foreign key references opcina (sifraopc) 
);

insert into zupanija values ('43000', 'Bjelovarsko bilogorska', 'Dario Hrebak')
insert into zupanija values ('31000', 'Osijek', 'Ivica Vrkić')
insert into zupanija values ('10000', 'Zagreb', 'Tomislav Tomašević')


insert into opcina values ('Berek', '43000')
insert into opcina values ('Nova Rača',  '43000')
insert into opcina values ('Zagrebačka', '10000')
insert into opcina values ('Travno', '31000')
insert into opcina values ('Brdo', '31000')

select*from opcina

insert into mjesto values ('Berek', '1001')
insert into mjesto values ('Šimljanca',  '1001')
insert into mjesto values ('Nova Ploščica', '1002')
insert into mjesto values ('Galovac', '1004')
insert into mjesto values ('Sirač',  '1004')
insert into mjesto values ('Bijelo Brdo', '1004')
insert into mjesto values ('Samobor', '1003')
insert into mjesto values ('Zaprešić',  '1003')
insert into mjesto values ('Bistra', '1003')

select*from mjesto

update mjesto set naziv = 'Brezovac' where sifra = 200
update mjesto set naziv = 'klokočevac' where sifra = 205

select*from mjesto

delete from mjesto where sifra=208;

