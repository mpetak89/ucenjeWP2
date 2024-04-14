using Banka.Mappers;
using Banka.Models;

namespace Banka.Extension
{
    public static class MappingPosudba
    {
        public static List<PosudbaDTORead> MapPosudbaReadList(this List<Posudba> lista)

        {
            var mapper = PosudbaMapper.InicijalizirajReadToDTO();
            var vrati = new List<PosudbaDTORead>();
            lista.ForEach(e =>
            {
                vrati.Add(mapper.Map<PosudbaDTORead>(e));
            });
            return vrati;
        }
        public static PosudbaDTORead MapPosudbaReadToDTO(this Posudba entitet)

        {
            var mapper = PosudbaMapper.InicijalizirajReadToDTO();
            return mapper.Map<PosudbaDTORead>(entitet);
        }

        public static Posudba MapPosudbaInsertUpdateToDTO(this PosudbaDTOInsertUpdate entitet)

        {
            var mapper = PosudbaMapper.InicijalizirajInsertUpdateFromDTO();
            return mapper.Map<Posudba>(entitet);
        }
        public static Posudba MapPosudbaInsertUpdateFromDTO(this PosudbaDTOInsertUpdate dto, Posudba entitet)
        {
            entitet.sifra_posudbe = dto.sifra_posudbe;

            entitet.datum_podizanja = dto.datum_podizanja;
            entitet.datum_vracanja = dto.datum_vracanja;
            entitet.iznos = dto.iznos;
            entitet.kamata = dto.kamata;
            return entitet;
        }

    }
}
