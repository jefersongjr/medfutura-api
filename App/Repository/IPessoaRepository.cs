using App.Models;

namespace App.Repository
{
    public interface IPessoaRepository
    {
        Pessoa AddPessoa(Pessoa pessoa);
        
        Pessoa? GetPessoaById(int id);
        
        IEnumerable<Pessoa> SearchPessoas(string termo);

        Pessoa? UpdatePessoa(int id, Pessoa pessoa);
    }
}