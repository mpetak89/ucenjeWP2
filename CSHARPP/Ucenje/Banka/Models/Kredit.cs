using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banka.Models
{
    public class Kredit:Entitet
    {
        [Required(ErrorMessage = "Obavezan Naziv_Kredita")]

        [Key]

        public int Sifra_Kredita { get; set; }
        public string? Vrsta_Kredita { get; set; }
        public string? valuta_kredita { get; set; }
        public string? vrsta_kamate { get; set; }
        public bool? osiguranje_kredita { get; set; }


    }
}

