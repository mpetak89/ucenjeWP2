using AutoMapper;
using Banka.Models;
using Microsoft.Extensions.Configuration;

namespace Banka.Mappers
{
    public class PosudbaMapper
    {
        public static Mapper InicijalizirajRead()
        {
            return new Mapper(
                    new MapperConfiguration(c =>
                    {
                        c.CreateMap<Posudba, PosudbaDTORead>();
                    })
                );
        }
        public static Mapper InicijalizirajInsertUpdate()
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