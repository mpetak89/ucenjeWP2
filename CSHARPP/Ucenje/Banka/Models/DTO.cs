using Banka.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Banka.Models
{
    public record KreditDTORead(int sifra_kredita, string vrsta_kredita, string valuta_kredita, string vrsta_kamate, bool osiguranje_kredita);
    public record KreditDTOInsertUpdate(int sifra_kredita, string vrsta_kredita, string valuta_kredita, string vrsta_kamate, bool osiguranje_kredita);
    public record KomitentDTORead(int sifra_komitenta, string oib, string ime, string prezime, string datum_rodenja, string ulica_stanovanja, string grad_stanovanja);
    public record KomitentDTOInsertUpdate(int sifra_komitenta, string oib, string ime, string prezime, DateTime datum_rodenja, string ulica_stanovanja, string grad_stanovanja);
    public record PosudbaDTORead(int sifra_posudbe, string vrsta_kredita, int sifra_komitenta, DateTime datum_podizanja, DateTime datum_vracanja, decimal iznos, string valuta_kredita, decimal kamata);
    public record PosudbaDTOInsertUpdate(int sifra_posudbe, int sifra_kredita, string vrsta_kredita, int sifra_komitenta, DateTime datum_podizanja, DateTime datum_vracanja, decimal iznos, string valuta_kredita, decimal kamata);

}