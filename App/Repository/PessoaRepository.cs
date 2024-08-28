using App.Models;

namespace App.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
       protected readonly PessoaContext _pessoaContext;

       public PessoaRepository(PessoaContext pessoaContext)
       {
          _pessoaContext = pessoaContext;
       }

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