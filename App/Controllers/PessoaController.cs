namespace App.Controllers;

using App.Models;
using App.Repository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase 
{
    protected readonly IPessoaRepository _pessoaRepository;
    public PessoaController(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    [HttpPost]
    public IActionResult Add([FromBody]Pessoa pessoa)
    {
        return Created("", _pessoaRepository.AddPessoa(pessoa));
    }
}