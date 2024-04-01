using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banka.Models
{
    public class Komitent    
    {
        [Key]public int? sifra_komitenta { get; set; }
        public string? oib { get; set; }
        public string? ime { get; set; }
        public string? prezime { get; set; }
        public DateTime? datum_rodenja { get; set; }
        public string? ulica_stanovanja { get; set; }
        public string? grad_stanovanja { get; set; }


    }
}
