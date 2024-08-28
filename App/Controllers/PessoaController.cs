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

    [HttpGet]
    public IEnumerable<Pessoa> Get()
    {
        return _pessoaRepository.GetPessoas();
    }
}