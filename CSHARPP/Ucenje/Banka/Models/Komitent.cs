using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banka.Models
{
    public class Komitent    
    {
        [Key]public int? sifra_komitenta { get; set; }
        public string? Oib { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public DateTime? Datum_rodenja { get; set; }
        public string? Ulica_stanovanja { get; set; }
        public string? Grad_stanovanja { get; set; }
    }
}
