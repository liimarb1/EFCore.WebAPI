﻿using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        private readonly IEFCoreRepository _repo;
        public BatalhaController(IEFCoreRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<Batalha>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var herois = await _repo.GetAllHerois();

                return Ok(herois);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");

            }
        }


        // GET api/<Batalha>/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Batalha
        [HttpPost]
        public async Task<IActionResult> Post(Batalha model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangeAsync())
                {
                    return Ok("BAZINGA");
                }
                              
            }

            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Salvou");
        }

        // PUT api/Batalha/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Batalha model)
        {
            try
            {
                if (_repo.GetHeroiById(id) != null)
                    
                {
                    _context.Update(model);
                    _context.SaveChanges();

                    return Ok("BAZINGA");
                }
                return Ok("Não Encontrado!");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
    

        // DELETE api/<Batalha/5
        [HttpDelete("{id}")]
        public async void Delete(int id, Batalha model)
        {
            //try
            //{
            //    if (_context.Batalhas
            //        .AsNoTracking()
            //        .FirstOrDefault(h => h.Id == id) != null)
            //    {
            //        _context.Update(model);
            //        _context.SaveChanges();

            return Ok("BAZINGA");
            //    }
            //    return Ok("Não Encontrado!");

            //}
            //catch (Exception ex)
            //{
            //    return BadRequest($"Erro: {ex}");
            //}
        }
    }
}
