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

      public Pessoa? GetPessoaById(int id)
      {
         return _pessoaContext.Pessoas.Find(id);
      }
   }
}