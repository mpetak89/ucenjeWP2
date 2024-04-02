using Banka.Data;
using Banka.Extension;
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
                return new JsonResult(lista.MapKomitentReadList());
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
                return new JsonResult(komitent.MapKomitentReadToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(KomitentDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid || dto == null)
            {
                return BadRequest();
            }
            try
            {
                var entitet = dto.MapKomitentInsertUpdateFromDTO(new Komitent());
                _context.Komitenti.Add(entitet);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, entitet.MapKomitentReadToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, KomitentDTOInsertUpdate dto)
        {
            if (sifra <= 0 || !ModelState.IsValid || dto == null)
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
                entitetizbaze = dto.MapKomitentInsertUpdateFromDTO(entitetizbaze);

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