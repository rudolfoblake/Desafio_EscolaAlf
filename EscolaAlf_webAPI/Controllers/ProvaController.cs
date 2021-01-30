using System;
using System.Threading.Tasks;
using EscolaAlf_webAPI.Context;
using EscolaAlf_webAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAlf_webAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProvaController : ControllerBase
    {
        private readonly IRepository _repositorio;
        public ProvaController(IRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("{provaId}")]
        public async Task<IActionResult> Get(int provaId)
        {
            try
            {
                var result = await _repositorio.GetProvaById(provaId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{provaId}")]
        public async Task<IActionResult> Put(int provaId, Prova prova)
        {
            try
            {
                var provaCadastrada = await _repositorio.GetProvaById(provaId);
                if (provaCadastrada == null)
                {
                    return NotFound();
                }
                _repositorio.Update(provaCadastrada);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(prova);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Prova prova)
        {
            try
            {
                _repositorio.Add(prova);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(prova);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{provaId}")]
        public async Task<IActionResult> Delete(int provaId)
        {
            try
            {
                var provaCadastrada = await _repositorio.GetProvaById(provaId);
                if (provaCadastrada == null)
                {
                    return NotFound();
                }
                _repositorio.Delete(provaCadastrada);

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

        
