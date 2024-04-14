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
                    return BadRequest("Ne postoje komitenti u bazi");
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
        public IActionResult GetBySifra(int sifra_komitenta)
        {

            if (!ModelState.IsValid || sifra_komitenta <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var k = _context.Komitenti.Find(sifra_komitenta);
                if (k == null)
                {
                    return BadRequest("Ne postoji komitent pod šifrom " + sifra_komitenta + " u bazi");
                }
                return new JsonResult(k.MapKomitentInsertUpdatedToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(KomitentDTOInsertUpdate komitentDTO)
        {
            if (!ModelState.IsValid || komitentDTO == null)
            {
                return BadRequest();
            }
            try
            {
                var komitent = komitentDTO.MapKomitentInsertUpdateFromDTO(new Komitent());
                _context.Komitenti.Add(komitent);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created,
                    komitent.MapKomitentReadToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPut]
        [Route("{sifra_komitenta:int}")]
        public IActionResult Put(int sifra_komitenta, KomitentDTOInsertUpdate komitentDTO)
        {
            if (sifra_komitenta <= 0 || !ModelState.IsValid || komitentDTO == null)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var komitentIzBaze = _context.Komitenti.Find(sifra_komitenta);
                if (komitentIzBaze == null)
                {
                    return BadRequest("Ne postoji komitent pod šifrom " + sifra_komitenta + " u bazi");
                }

                var komitent = komitentDTO.MapKomitentInsertUpdateFromDTO(komitentIzBaze);


                _context.Komitenti.Update(komitent);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK,
                    komitent.MapKomitentInsertUpdatedToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }


        [HttpDelete]
        [Route("{sifra_komitenta:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra_komitenta)
        {
            if (!ModelState.IsValid || sifra_komitenta <= 0)
            {
                return BadRequest();
            }

            try
            {
                var komitentIzBaze = _context.Komitenti.Find(sifra_komitenta);

                if (komitentIzBaze == null)
                {
                    return BadRequest("Ne postoji komitent pod šifrom " + sifra_komitenta + " u bazi");
                }

                _context.Komitenti.Remove(komitentIzBaze);
                _context.SaveChanges();

                return new JsonResult(new { poruka = "Obrisan komitent pod šifrom " + sifra_komitenta });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }

    }
}