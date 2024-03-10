using EdunovaAPP.Mappers;
using EdunovaAPP.Models;

namespace EdunovaAPP.Extensions
{
    public static class Mapping
    {
        public static List<SmjerDTORead>MapSmjerRead (this List<Smjer>lista)
        {
            var mapper = SmjerMapper.Inicjaliziraj();
            var vrati = new List <SmjerDTORead>();
            lista.ForEach(e =>
            {
                vrati.Add(mapper.Map<SmjerDTORead>(e));
            });
            return vrati;

        }
}
