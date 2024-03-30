using System.ComponentModel.DataAnnotations;

namespace Banka.Models
{

    public abstract class Entitet
    {
        /// <summary>
        /// primarni ključ u bazi
        /// </summary>

        [Required(ErrorMessage="Obavezan unos")]
        [Key]

        public int sifra_kredita { get; set; }




    }
}
