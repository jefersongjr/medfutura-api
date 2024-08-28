using Microsoft.EntityFrameworkCore;
using App.Models;
using DotNetEnv;

namespace App.Repository {

    public class PessoaContext : DbContext, IPessoaContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options) {}
        public DbSet<Pessoa> Pessoas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          if(!optionsBuilder.IsConfigured) 
          {
            DotNetEnv.Env.Load();

                var host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
                var port = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432";
                var database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "postgres";
                var username = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "root";
                var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "mypassword";

            var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};TrustServerCertificate=True;";
            optionsBuilder.UseNpgsql(connectionString);
          }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Pessoa>().ToTable("pessoas");
        }

    };
}