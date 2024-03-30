using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banka.Models
{
    public class Kredit:Entitet
    {
                        
        public string? vrsta_kredita { get; set; }
        public string? valuta_kredita { get; set; }
        public string? vrsta_kamate { get; set; }
        public bool? osiguranje_kredita { get; set; }


    }
}

