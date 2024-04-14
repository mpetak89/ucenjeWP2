using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banka.Models
{
    public class Kredit : Entitet
    {
        /// <summary>
        /// Vrsta kredita
        /// </summary>
        [Required(ErrorMessage = "Obavezan unos vrste kredita")]
        public string? vrsta_kredita { get; set; }
        /// <summary>
        /// Valuta kredita
        /// </summary>
        [Required(ErrorMessage = "Obavezan unos valute kredita")]
        public string? valuta_kredita { get; set; }
        /// <summary>
        /// Vrsta kamate
        /// </summary>
        [Required(ErrorMessage = "Obavezan unos vrste kamate")]
        public string? vrsta_kamate { get; set; }
        /// <summary>
        /// Osiguranje kredita
        /// </summary>
        [Required(ErrorMessage = "Obavezan odabir osiguranja kredita")]
        public bool? osiguranje_kredita { get; set; }


    }
}