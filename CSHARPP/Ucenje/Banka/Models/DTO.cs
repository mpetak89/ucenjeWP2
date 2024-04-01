namespace Banka.Models
{
    public record KreditDTORead (int sifra_kredita, string vrsta_kredita, string valuta_kredita, string vrsta_kamate, bool osiguranje_kredita);
        public record KreditDTOInsertUpdate(int sifra_kredita, string vrsta_kredita, string valuta_kredita, string vrsta_kamate, bool osiguranje_kredita);
}
