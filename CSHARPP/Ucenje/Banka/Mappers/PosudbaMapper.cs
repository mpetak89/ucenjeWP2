using AutoMapper;
using Banka.Models;
using Microsoft.Extensions.Configuration;

namespace Banka.Mappers
{
    public class PosudbaMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                    new MapperConfiguration(c =>
                    {
                        c.CreateMap<Posudba, PosudbaDTORead>();
                    })
                );
        }
        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<PosudbaDTORead, Posudba>();
                })
                );
        }
        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Posudba, PosudbaDTOInsertUpdate>();
                })
                );
        }
    }
}