go
use knjiznica
go
select * from autor
--koje knjige je napisao šenoa
select b.naslov as ime
from autor a
inner join katalog b on a.sifra=b.autor
where prezime ='Šenoa'


-- sve naslove knjiga i nazive mjesta izdanja
-- gdje je autor rođ 1976 i aktivan izdav

select a.ime 
from autor a
inner join katalog b on a.sifra=b.autor
inner join mjesto c on c.sifra=b.mjesto
inner join izdavac d on d.sifra=b.izdavac
where a.datumrodenja between '1976-01-01' and '1976-12-31'
and d.aktivan=1




