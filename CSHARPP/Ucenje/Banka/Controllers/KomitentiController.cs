using Banka.Data;
using Banka.Models;
using Microsoft.AspNetCore.Mvc;


namespace Banka.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class KomitentController : ControllerBase
    {

        private readonly BankaContext _context;

        public KomitentController(BankaContext context)
        {
            _context = context;
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
                var lista = _context.Komitenti.ToList();
                if (lista == null || lista.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }

        [HttpGet]
        [Route("{sifra_komitenta:int}")]
        public IActionResult GetBySifra(int sifra)
        {

            if (!ModelState.IsValid || sifra <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var komitent = _context.Komitenti.Find(sifra);
                if (komitent == null)
                {
                    return new EmptyResult();
                }
                return new JsonResult(komitent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(Komitent entitet)
        {
            if (!ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }
            try
            {
                _context.Komitenti.Add(entitet);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, entitet);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Komitent entitet)
        {
            if (sifra <= 0 || !ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }
            try
            {

                var entitetizbaze = _context.Komitenti.Find(sifra);

                if (entitetizbaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                entitetizbaze.sifra_komitenta = entitet.sifra_komitenta;
                entitetizbaze.oib = entitet.oib;
                entitetizbaze.ime = entitet.ime;
                entitetizbaze.prezime = entitet.prezime;
                entitetizbaze.datum_rodenja = entitet.datum_rodenja;
                entitetizbaze.ulica_stanovanja = entitet.ulica_stanovanja;
                entitetizbaze.grad_stanovanja = entitet.grad_stanovanja;

                _context.Komitenti.Update(entitetizbaze);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, entitetizbaze);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }


        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (!ModelState.IsValid || sifra <= 0)
            {
                return BadRequest();
            }

            try
            {
                var entitetizbaze = _context.Komitenti.Find(sifra);

                if (entitetizbaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Komitenti.Remove(entitetizbaze);
                _context.SaveChanges();

                return new JsonResult(new { poruka = "Obrisano" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }

    }
}