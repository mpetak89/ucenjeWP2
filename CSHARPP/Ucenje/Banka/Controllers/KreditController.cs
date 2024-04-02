using Banka.Data;
using Banka.Extension;
using Banka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text;


namespace Banka.Controllers

{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KreditController : ControllerBase
    {
        private readonly BankaContext _context;

        public KreditController(BankaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Dohvaća sve kredite
        /// </summary>
        /// <response code="200">Sve OK, ako nema podataka content-length: 0 </response>
        /// <response code="400">Zahtjev nije valjan</response>
        /// <response code="503">Baza na koju se spajam nije dostupna</response>

        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var krediti = _context.Krediti.ToList();
                if (krediti == null || krediti.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(krediti.MapKreditReadList());
            }
            catch (Exception ex)

            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }


        }
        [HttpGet]
        [Route("{sifra_kredita:int}")]
        public IActionResult GetBySifra(int sifra_kredita)
        {
            if (!ModelState.IsValid || sifra_kredita <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var kredit= _context.Krediti.Find(sifra_kredita);
                if (kredit == null)
                {
                    return new EmptyResult();

                }
                return new JsonResult(kredit.MapKreditInsertUpdatedToDTO());
            }
            catch (Exception ex)

            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }


        }

        [HttpPost]
        public IActionResult Post(KreditDTOInsertUpdate kreditDTO)
        {
            if (!ModelState.IsValid || kreditDTO == null)
            {
                return BadRequest();
            }
            try
            {
                var kredit = kreditDTO.MapKreditInsertUpdateFromDTO(new Kredit());
                _context.Krediti.Add(kredit);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, 
                    kredit.MapKreditReadToDTO());
                            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }
        [HttpPut]
        [Route("{sifra_kredita:int}")]

        public IActionResult Put(int sifra_kredita, KreditDTOInsertUpdate kreditDTO)
        {
            if (sifra_kredita <= 0 || !ModelState.IsValid || kreditDTO == null)
            {
                return BadRequest();
            }
            try
            {
                var kreditizbaze = _context.Krediti.Find(sifra_kredita);
                if (kreditizbaze == null)
                {
                    return BadRequest("Ne postoji kredit pod šifrom " + sifra_kredita + " u bazi");
                }


                var kredit=kreditDTO.MapKreditInsertUpdateFromDTO(kreditizbaze);
                
                _context.Krediti.Update(kredit); 
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, kredit.MapKreditReadToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);


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
        }

    }

        }


