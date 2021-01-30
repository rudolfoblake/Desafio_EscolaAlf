using System;
using System.Threading.Tasks;
using EscolaAlf_webAPI.Context;
using EscolaAlf_webAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAlf_webAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlternativaController : ControllerBase
    {
        private readonly IRepository _repositorio;
        public AlternativaController(IRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("{alternativaId}")]
        public async Task<IActionResult> Get(int alternativaId)
        {
            try
            {
                var result = await _repositorio.GetAlternativaById(alternativaId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{alternativaId}")]
        public async Task<IActionResult> Put(int alternativaId, Alternativa alternativa)
        {
            try
            {
                var alternativaCadastrada = await _repositorio.GetAlternativaById(alternativaId);
                if (alternativaCadastrada == null)
                {
                    return NotFound();
                }
                _repositorio.Update(alternativaCadastrada);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(alternativa);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Alternativa alternativa)
        {
            try
            {
                _repositorio.Add(alternativa);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(alternativa);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{alternativaId}")]
        public async Task<IActionResult> Delete(int alternativaId)
        {
            try
            {
                var alternativaCadastrada = await _repositorio.GetAlternativaById(alternativaId);
                if (alternativaCadastrada == null)
                {
                    return NotFound();
                }
                _repositorio.Delete(alternativaCadastrada);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(
                        new
                        {
                            message = "Deletado!!"
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }


    }
}