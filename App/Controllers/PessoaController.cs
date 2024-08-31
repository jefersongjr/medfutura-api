namespace App.Controllers;

using App.Models;
using App.Repository;
using App.Exceptions;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaRepository _pessoaRepository;

    // Construtor da classe
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
}
