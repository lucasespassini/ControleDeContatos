using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<ContatoModel> Contatos { get; set; }

        public BancoContext(DbContextOptions<BancoContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conexaoString = _configuration.GetConnectionString(name: "ConexaoMysql");
            optionsBuilder.UseMySql(conexaoString, ServerVersion.AutoDetect(conexaoString)).UseLowerCaseNamingConvention();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
