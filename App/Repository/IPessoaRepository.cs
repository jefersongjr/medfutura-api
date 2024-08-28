using App.Models;

namespace App.Repository
{
   public interface IPessoaRepository
   {
    Pessoa AddPessoa(Pessoa pessoa);

    IEnumerable<Pessoa> GetPessoas();
   } 
}