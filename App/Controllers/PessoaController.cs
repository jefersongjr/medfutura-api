namespace App.Controllers;

using App.Models;
using App.Repository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase // controladores de API
{
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaController(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    [HttpPost]
    public IActionResult Add([FromBody] Pessoa pessoa)
    {
        if (pessoa == null ||
            pessoa.Nascimento == null ||
            string.IsNullOrWhiteSpace(pessoa.Nome) ||
            string.IsNullOrWhiteSpace(pessoa.Apelido))
        {
            return StatusCode(422, "Campos obrigatórios ausentes ou inválidos.");
        }

        try
        {
            _pessoaRepository.AddPessoa(pessoa);
            return CreatedAtAction(nameof(Add), new { id = pessoa.Id }, pessoa);
        }
        catch (Exception e)
        {
            return BadRequest($"Erro ao processar a requisição: {e.Message}");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var pessoa = _pessoaRepository.GetPessoaById(id);

        if (pessoa == null)
        {
            return NotFound("Pessoa não encontrada.");
        }

        return Ok(pessoa);
    }


    [HttpGet]
    public IActionResult Search([FromQuery] string? t)
    {
        if (string.IsNullOrWhiteSpace(t))
        {
            return BadRequest("Termo de busca não informado.");
        }

        var pessoas = _pessoaRepository.SearchPessoas(t);

        if (pessoas == null || !pessoas.Any())
        {
            return Ok(new List<Pessoa>());
        }

        return Ok(pessoas);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Pessoa pessoa)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(422, "Campos obrigatórios ausentes ou inválidos.");
        }

        if (pessoa == null)
        {
            return StatusCode(422, "Objeto pessoa não pode ser nulo.");
        }

        var updatedPessoa = _pessoaRepository.UpdatePessoa(id, pessoa);

        if (updatedPessoa == null)
        {
            return NotFound("Pessoa não encontrada.");
        }

        return Ok(updatedPessoa);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _pessoaRepository.DeletePessoa(id);

        if (!isDeleted)
        {
            return BadRequest("Não foi possível excluir a pessoa. O ID pode não existir.");
        }

        return NoContent();
    }
}

