using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Config
{
    public class ContextBase : DbContext
    {

        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }
     
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StringConnectionConfig());
            }
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        //public DbSet<Endereco> Endereco { get; set; }

        private string StringConnectionConfig()
        {
            string strConf = "server=DESKTOP-S8VP4K4\\SQLEXPRESS;User Id=sa;password=123456;Persist Security Info=True;database=DDDTesteCore";
            //string strConf = "Server=(localdb)\\mssqllocaldb;Database=DDDTesteCore;Trusted_Connection=True;";
            return strConf;
        }
    }
}
