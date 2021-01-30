using System;
using System.Threading.Tasks;
using EscolaAlf_webAPI.Context;
using EscolaAlf_webAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAlf_webAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RespostaAlunoController : ControllerBase
    {
        private readonly IRepository _repositorio;
        public RespostaAlunoController(IRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("{respostaAlunoId}")]
        public async Task<IActionResult> Get(int respostaAlunoId)
        {
            try
            {
                var result = await _repositorio.GetRespostaAlunoById(respostaAlunoId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(RespostaAluno respostaAluno)
        {
            try
            {
                _repositorio.Add(respostaAluno);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(respostaAluno);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("{respostaAlunoId}")]
        public async Task<IActionResult> Put(int respostaAlunoId, RespostaAluno respostaAluno)
        {
            try
            {
                var respostaAlunoCadastrada = await _repositorio.GetRespostaAlunoById(respostaAlunoId);
                if (respostaAlunoCadastrada == null)
                {
                    return NotFound();
                }
                _repositorio.Update(respostaAlunoCadastrada);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(respostaAluno);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{respostaAlunoId}")]
        public async Task<IActionResult> Delete(int respostaAlunoId)
        {
            try
            {
                var respostaAlunoCadastrada = await _repositorio.GetRespostaAlunoById(respostaAlunoId);
                if (respostaAlunoCadastrada == null)
                {
                    return NotFound();
                }
                _repositorio.Delete(respostaAlunoCadastrada);

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