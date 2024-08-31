using App.Models;

namespace App.Repository
{
    public class PessoaRepository(PessoaContext pessoaContext) : IPessoaRepository
    {
       protected readonly PessoaContext _pessoaContext = pessoaContext;

        public Pessoa AddPessoa(Pessoa pessoa)
       {
          _pessoaContext.Pessoas.Add(pessoa);
          _pessoaContext.SaveChanges();

          return pessoa;
       }

        public IEnumerable<Pessoa> GetPessoas()
       {

          return _pessoaContext.Pessoas;
          
       }
    }
}