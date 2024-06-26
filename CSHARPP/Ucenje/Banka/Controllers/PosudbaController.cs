﻿using Banka.Data;
using Banka.Extension;
using Banka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Banka.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class PosudbaController : ControllerBase
    {

        private readonly BankaContext _context;

        public PosudbaController(BankaContext context)
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
                var lista = _context.Posudbe;
                //.Include(g => g.Kredit)
                //    .Include(g => g.Komitent)
                ////    .ToList();
                ////if (lista == null || lista.Count == 0)
                //{
                //    return new EmptyResult();
                //}
                return new JsonResult(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }

        [HttpGet]
        [Route("{sifra_posudbe:int}")]
        public IActionResult GetBySifra(int sifra_posudbe)
        {
            if (!ModelState.IsValid || sifra_posudbe <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var posudba = _context.Posudbe.Find(sifra_posudbe);
                if (posudba == null)
                {
                    return new EmptyResult();

                }
                return new JsonResult(posudba.MapPosudbaReadToDTO());
            }
            catch (Exception ex)

            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }


        }

        [HttpPost]
        public IActionResult Post(Posudba entitet)
        {
            if (!ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }
            try
            {
                _context.Posudbe.Add(entitet);
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
        [Route("{sifra_posudbe:int}")]
        public IActionResult Put(int sifra_posudbe, Posudba entitet)
        {
            if (sifra_posudbe <= 0 || !ModelState.IsValid || entitet == null)
            {
                return BadRequest();
            }
            try
            {

                var entitetIzBaze = _context.Posudbe.Find(sifra_posudbe);

                if (entitetIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra_posudbe);
                }

                entitetIzBaze.sifra_posudbe = entitet.sifra_posudbe;
                entitetIzBaze.datum_podizanja = entitet.datum_podizanja;
                entitetIzBaze.datum_vracanja = entitet.datum_vracanja;
                entitetIzBaze.iznos = entitet.iznos;
                entitetIzBaze.kamata = entitet.kamata;

                _context.Posudbe.Update(entitetIzBaze);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, entitetIzBaze);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }


        [HttpDelete]
        [Route("{sifra_posudbe:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra_posudbe)
        {
            if (!ModelState.IsValid || sifra_posudbe <= 0)
            {
                return BadRequest();
            }

            try
            {
                var entitetIzbaze = _context.Posudbe.Find(sifra_posudbe);

                if (entitetIzbaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra_posudbe);
                }

                _context.Posudbe.Remove(entitetIzbaze);
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