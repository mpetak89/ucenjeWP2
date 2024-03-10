using AutoMapper;
using EdunovaAPP.Models;
namespace EdunovaAPP.Mappers

{
    public class SmjerMapper
    {
        public static Mapper Inicjaliziraj ()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<SmjerMapper, SmjerDTORead>();

                })
                );
        }
        public static Mapper InicjalizirajInsertUpdate()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<SmjerMapper, SmjerDTOInsertUpdate>();

                })
                );
        }
    }
}