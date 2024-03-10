using Banka.Data;
using Banka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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

     }
}
