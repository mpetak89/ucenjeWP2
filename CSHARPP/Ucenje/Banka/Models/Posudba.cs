using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banka.Models
{
    public class Posudba
    {
        [Key] public int? sifra_posudbe { get; set; }
        [ForeignKey ("sifra_kredita")]
        //public Kredit? Kredit{ get; set; }
        public Kredit? sifra_kredita { get; set; }
        [ForeignKey("sifra_komitenta")]
        public Komitent? Komitent { get; set; }
        public DateTime? datum_podizanja { get; set; }
        public DateTime? datum_vracanja { get; set; }
        public decimal? iznos { get; set; }
        public decimal? kamata { get; set; }

        
    }
}
