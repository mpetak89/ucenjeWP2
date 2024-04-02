using Banka.Mappers;
using Banka.Models;
    
    namespace Banka.Extension
{
    public static class Mapping
    {
        public static List<KreditDTORead> MapKreditReadList(this List<Kredit>lista)

        {
            var mapper = KreditMapper.InicijalizirajReadToDTO();
            var vrati = new List<KreditDTORead>();
            lista.ForEach(e =>
            {
                vrati.Add(mapper.Map<KreditDTORead>(e));
            });
            return vrati;
        }
        public static KreditDTORead MapKreditReadFromDTO(this Kredit entitet)

        {
            var mapper = KreditMapper.InicijalizirajReadFromDTO();
            return mapper.Map<KreditDTORead>(entitet);
        }
        public static KreditDTORead MapKreditReadToDTO(this Kredit entitet)

        {
            var mapper = KreditMapper.InicijalizirajReadToDTO();
            return mapper.Map<KreditDTORead>(entitet);
        }

        public static KreditDTOInsertUpdate MapKreditInsertUpdatedToDTO(this Kredit entitet)

        {
            var mapper = KreditMapper.InicijalizirajInsertUpdateToDTO();
            return mapper.Map<KreditDTOInsertUpdate>(entitet);
        }
        public static Kredit MapKreditInsertUpdateFromDTO(this KreditDTOInsertUpdate dto, Kredit entitet)
        {
            entitet.sifra_kredita = dto.sifra_kredita;
            entitet.vrsta_kredita = dto.vrsta_kredita;
            entitet.valuta_kredita = dto.valuta_kredita;
            entitet.vrsta_kamate = dto.vrsta_kamate;
            entitet.osiguranje_kredita = dto.osiguranje_kredita;
            return entitet;

        }

    }
}
 