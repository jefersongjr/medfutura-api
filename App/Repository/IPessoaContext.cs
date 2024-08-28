using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Repository
{
    public interface IPessoaContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public int SaveChanges();
    }
}