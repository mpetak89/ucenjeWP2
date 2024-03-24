using Banka.Data;
using Banka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace Banka.Controllers

/// <summary>
/// Namjenjeno za CRUD operacije nad entitetom smjer u bazi
///</summary>
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KreditController : ControllerBase
    {
        private readonly BankaContext _context;

        public KreditController (BankaContext context)
        {
            _context = context;

            /// <summary>
            /// Dohvaća sve smjerove iz baze
            /// </summary>
            /// <remarks>
            /// Primjer upita
            /// 
            ///    GET api/v1/Smjer
            ///    
            /// </remarks>
            /// <returns>Smjerovi u bazi</returns>
            /// <response code="200">Sve OK, ako nema podataka content-length: 0 </response>
            /// <response code="400">Zahtjev nije valjan</response>
            /// <response code="503">Baza na koju se spajam nije dostupna</response>
        }
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid) 
            { 
            return BadRequest(ModelState);
            }
            try
            {
                var Krediti = _context.Krediti.ToList ();
                if (Krediti==null|| Krediti.Count==0)
                { 
                    return new EmptyResult(); 
                }
                return new JsonResult (Krediti);
            }catch (Exception ex) 
            
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }

            
        }
        [HttpPost]
        public IActionResult Post (Kredit Krediti)
        {
            if (!ModelState.IsValid || Krediti  == null) 
            {
                return BadRequest();
            }
            try
            {
                _context.Krediti.Add (Krediti);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, Krediti);
                
            }catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }
        [HttpPut]
        [Route("{sifra_kredita:int}")]

        public IActionResult Put (int sifra_kredita, Kredit Kredit)
        {
            if (sifra_kredita<=0 || !ModelState.IsValid || Kredit == null)
            {
                return BadRequest();
            }
            try
            { 
            var kreditizbaze = _context.Krediti.Find(sifra_kredita);
           if (kreditizbaze == null)    
                {
                return BadRequest();
                }
            kreditizbaze.Vrsta_Kredita = Kredit.Vrsta_Kredita;
            _context.Krediti.Update(kreditizbaze);
            _context.SaveChanges ();
            return StatusCode (StatusCodes.Status200OK, kreditizbaze );
        }
        catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
    }
           

}
        [HttpDelete]
        [Route("{sifra_kredita:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra_kredita)
        {
            if (!ModelState.IsValid || sifra_kredita <= 0)
            {
                return BadRequest();
            }

            try
            {
                var kreditizbaze = _context.Krediti.Find(sifra_kredita);

                if (kreditizbaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra_kredita);
                }

                _context.Krediti.Remove(kreditizbaze);
                _context.SaveChanges();

                return new JsonResult(new { poruka = "Obrisan kredit pod šifrom " + sifra_kredita });
            }

            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.ErrorCode);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }



            }



    }
}