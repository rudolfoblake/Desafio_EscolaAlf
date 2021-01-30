using System;
using System.Threading.Tasks;
using EscolaAlf_webAPI.Context;
using EscolaAlf_webAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAlf_webAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoProvaController : ControllerBase
    {

        private readonly IRepository _repositorio;
        public AlunoProvaController(IRepository repositorio)
        {
            _repositorio = repositorio;            
        }

        [HttpGet("{alunoProvaId}")]
        public async Task<IActionResult> Get(int alunoProvaId)
        {
            try
            {
                var result = await _repositorio.GetAlunoProvaById(alunoProvaId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{alunoProvaId}")]
        public async Task<IActionResult> Put(int alunoProvaId, AlunoProva alunoProva)
        {
            try
            {
                var alunoProvaCadastrada = await _repositorio.GetAlunoProvaById(alunoProvaId);

                if (alunoProvaCadastrada == null)
                {
                    return BadRequest("Uma prova deve ser cadastrada!!");
                }

                _repositorio.Update(alunoProva);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(alunoProva);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(AlunoProva alunoProva)
        {
            try
            {
                _repositorio.Add(alunoProva);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(alunoProva);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{alunoProvaId}")]
        public async Task<IActionResult> Delete(int alunoProvaId)
        {
            try
            {
                var alunoProvaCadastrada = await _repositorio.GetAlunoProvaById(alunoProvaId);

                if (alunoProvaCadastrada == null)
                {
                    return NotFound();
                }
                _repositorio.Delete(alunoProvaCadastrada);

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