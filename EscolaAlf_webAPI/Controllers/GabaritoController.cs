using System;
using System.Threading.Tasks;
using EscolaAlf_webAPI.Context;
using EscolaAlf_webAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAlf_webAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GabaritoController : ControllerBase
    {
        private readonly IRepository _repositorio;
        public GabaritoController(IRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("{gabaritoId}")]
        public async Task<IActionResult> Get(int gabaritoId)
        {
            try
            {
                var result = await _repositorio.GetGabaritoById(gabaritoId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        
        [HttpPut("{gabaritoId}")]
        public async Task<IActionResult> Put(int gabaritoId, Gabarito gabarito)
        {
            try
            {
                var gabaritoCadastrado = await _repositorio.GetGabaritoById(gabaritoId);

                if (gabaritoCadastrado == null)
                {
                    return NotFound();
                }
                _repositorio.Update(gabaritoCadastrado);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(gabarito);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Gabarito gabarito)
        {
            try
            {
                _repositorio.Add(gabarito);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(gabarito);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{gabaritoId}")]
        public async Task<IActionResult> Delete(int gabaritoId)
        {
            try
            {
                var gabaritoCadastrado = await _repositorio.GetGabaritoById(gabaritoId);
                
                if (gabaritoCadastrado == null)
                {
                    return NotFound();
                }
                _repositorio.Delete(gabaritoCadastrado);

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