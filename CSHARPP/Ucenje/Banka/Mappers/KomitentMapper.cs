using AutoMapper;
using Banka.Models;
using Microsoft.Extensions.Configuration;

namespace Banka.Mappers
{
    public class KomitentMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Komitent, KomitentDTORead>();
                })
                );
        }
        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<KomitentDTORead, Komitent>();
                })
                );
        }
        public static Mapper InicijalizirajInsertUpdateToDTO()
            {
                return new Mapper(
                    new MapperConfiguration(c =>
                    {
                        c.CreateMap<Komitent, KomitentDTOInsertUpdate>();
                    })
                    );
            }
        public static Mapper InicijalizirajInsertUpdateFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<KomitentDTOInsertUpdate, Komitent>();
                })
                );
        }
    }
}
