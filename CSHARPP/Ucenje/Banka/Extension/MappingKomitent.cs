using Banka.Mappers;
using Banka.Models;
    
    namespace Banka.Extension
{
    public static class MappingKomitent
    {
        public static List<KomitentDTORead> MapKomitentReadList(this List<Komitent>lista)

        {
            var mapper = KomitentMapper.InicijalizirajReadToDTO();
            var vrati = new List<KomitentDTORead>();
            lista.ForEach(e =>
            {
                vrati.Add(mapper.Map<KomitentDTORead>(e));
            });
            return vrati;
        }
        public static KomitentDTORead MapKomitentReadFromDTO(this Komitent entitet)

        {
            var mapper = KomitentMapper.InicijalizirajReadFromDTO();
            return mapper.Map<KomitentDTORead>(entitet);
        }
        public static KomitentDTORead MapKomitentReadToDTO(this Komitent entitet)

        {
            var mapper = KomitentMapper.InicijalizirajReadToDTO();
            return mapper.Map<KomitentDTORead>(entitet);
        }

        public static KomitentDTOInsertUpdate MapKomitentInsertUpdateToDTO(this Komitent entitet)

        {
            var mapper = KomitentMapper.InicijalizirajInsertUpdateToDTO();
            return mapper.Map<KomitentDTOInsertUpdate>(entitet);
        }
        public static Komitent MapKomitentInsertUpdateFromDTO(this KomitentDTOInsertUpdate dto, Komitent entitet)
        {
            entitet.sifra_komitenta = dto.sifra_komitenta;
            entitet.oib = dto.oib;
            entitet.ime = dto.ime;
            entitet.prezime = dto.prezime;
            entitet.datum_rodenja = dto.datum_rodenja;
            entitet.ulica_stanovanja = dto.ulica_stanovanja;
            entitet.grad_stanovanja = dto.grad_stanovanja;
            return entitet;

    }

    }
}
 