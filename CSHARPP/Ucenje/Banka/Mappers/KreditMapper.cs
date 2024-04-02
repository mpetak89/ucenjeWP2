using AutoMapper;
using Banka.Models;
using Microsoft.Extensions.Configuration;

namespace Banka.Mappers
{
    public class KreditMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Kredit, KreditDTORead>();
                })
                );
        }
        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<KreditDTORead, Kredit>();
                })
                );
        }
        public static Mapper InicijalizirajInsertUpdateToDTO()
            {
                return new Mapper(
                    new MapperConfiguration(c =>
                    {
                        c.CreateMap<Kredit, KreditDTOInsertUpdate>();
                    })
                    );
            }
        //public static Mapper InicijalizirajInsertUpdateFromDTO()
        //{
        //    return new Mapper(
        //        new MapperConfiguration(c =>
        //        {
        //            c.CreateMap<KreditDTOInsertUpdate, Kredit>();
        //        })
        //        );
        //}
    }
}
