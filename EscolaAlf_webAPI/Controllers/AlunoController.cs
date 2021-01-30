using System;
using EscolaAlf_webAPI.Models;
using System.Threading.Tasks;
using EscolaAlf_webAPI.Context;
using Microsoft.AspNetCore.Mvc;


namespace EscolaAlf_webAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repositorio;
        public AlunoController(IRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repositorio.GetAllAlunosAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("situacao/{situacao}")]
        public async Task<IActionResult> Get(string situacao)
        {
            try
            {
                var result = await _repositorio.GetAlunoBySituacao(situacao);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{alunoId}")]
        public async Task<IActionResult> Get(int alunoId)
        {
            try
            {
                var result = await _repositorio.GetAlunoById(alunoId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{alunoId}")]
        public async Task<IActionResult> Put(int alunoId, Aluno aluno)
        {
            try
            {
                var alunoCadastrado = await _repositorio.GetAlunoById(alunoId);
                
                if (alunoCadastrado == null)
                {
                    return NotFound();
                }
                _repositorio.Update(alunoCadastrado);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(aluno);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno aluno)
        {
            try
            {
                _repositorio.Add(aluno);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(aluno);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{alunoId}")]
        public async Task<IActionResult> Delete(int alunoId)
        {
            try
            {
                var alunoCadastrado = await _repositorio.GetAlunoById(alunoId);
                if (alunoCadastrado == null)
                {
                    return NotFound();
                }
                _repositorio.Delete(alunoCadastrado);

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