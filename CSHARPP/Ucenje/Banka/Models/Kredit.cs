using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banka.Models
{
    public class Kredit:Entitet
    {
        [Required(ErrorMessage ="Obavezan Naziv_Kredita")]
        public string? Vrsta_Kredita { get; set; }

    }
}
