using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banka.Models
{
    public class Posudba
    {
        [Key] public int? Sifra_Posudbe { get; set; }
        ForeignKeyAttribute ForeignKey { get; set; }
        public DateTime? Datum_podizanja { get; set; }
        public DateTime? Datum_Vracanja { get; set; }
        public decimal? Iznos { get; set; }
        public decimal? Kamata { get; set; }

    }
}
