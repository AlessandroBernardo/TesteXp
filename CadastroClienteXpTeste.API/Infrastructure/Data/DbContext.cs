using CadastroClienteXpTeste.API.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CadastroClienteXpTeste.API.Infrastructure.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }        
        public DbSet<Email> Emails { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {                
        //         optionsBuilder.UseSqlServer("Server=db,1433;Database=MyApiDB;User Id=sa;Password=Ciatech@098820;")                              
        //                       .EnableSensitiveDataLogging();
        //     }
        // }
    
    }

    
}
