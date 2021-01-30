using System;
using System.Threading.Tasks;
using EscolaAlf_webAPI.Context;
using EscolaAlf_webAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAlf_webAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class QuestaoController : ControllerBase
    {
        private readonly IRepository _repositorio;
        public QuestaoController(IRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("{questaoId}")]
        public async Task<IActionResult> Get(int questaoId)
        {
            try
            {
                var result = await _repositorio.GetQuestaoById(questaoId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{questaoId}")]
        public async Task<IActionResult> Put(int questaoId, Questao questao)
        {
            try
            {
                var questaoCadastrada = await _repositorio.GetQuestaoById(questaoId);
                if (questaoCadastrada == null)
                {
                    return NotFound();
                }
                _repositorio.Update(questaoCadastrada);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(questao);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Questao questao)
        {
            try
            {
                _repositorio.Add(questao);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(questao);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("{questaoId}")]
        public async Task<IActionResult> Delete(int questaoId)
        {
            try
            {
                var questaoCadastrada = await _repositorio.GetQuestaoById(questaoId);
                if (questaoCadastrada == null)
                {
                    return NotFound();
                }
                _repositorio.Delete(questaoCadastrada);

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

        
