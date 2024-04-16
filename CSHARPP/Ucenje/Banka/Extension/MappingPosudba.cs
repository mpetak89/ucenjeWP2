using Banka.Mappers;
using Banka.Models;

namespace Banka.Extension
{
    public static class MappingPosudba
    {
        public static List<PosudbaDTORead> MapPosudbaReadList(this List<Posudba> lista)

        {
            var mapper = PosudbaMapper.InicijalizirajRead();
            var vrati = new List<PosudbaDTORead>();
            lista.ForEach(e =>
            {
                vrati.Add(mapper.Map<PosudbaDTORead>(e));
            });
            return vrati;
        }

        public static PosudbaDTORead MapPosudbaRead(this Posudba entitet)

        {
            var mapper = PosudbaMapper.InicijalizirajRead();
            return mapper.Map<PosudbaDTORead>(entitet);
        }

    }
}
