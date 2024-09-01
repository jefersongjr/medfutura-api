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

      public IEnumerable<Pessoa> SearchPessoas(string termo)
      {
         return _pessoaContext.Pessoas
             .Where(p => p.Nome.Contains(termo) ||
                         p.Apelido.Contains(termo) ||
                         p.Stack.Any(s => s.Contains(termo)))
             .ToList();
      }

      public Pessoa? UpdatePessoa(int id, Pessoa pessoa)
      {
         var existingPessoa = _pessoaContext.Pessoas.Find(id);
         if (existingPessoa == null)
         {
            return null;
         }

         existingPessoa.Nome = pessoa.Nome;
         existingPessoa.Apelido = pessoa.Apelido;
         existingPessoa.Nascimento = pessoa.Nascimento;
         existingPessoa.Stack = pessoa.Stack;

         _pessoaContext.Pessoas.Update(existingPessoa);
         _pessoaContext.SaveChanges();

         return existingPessoa;
      }
   }
}