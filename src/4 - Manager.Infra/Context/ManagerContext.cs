using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Context{
    public class ManagerContext : DbContext{
        public ManagerContext()
        {}

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {}
        
         protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer(@"Server=tcp:apigerenciamento.database.windows.net,1433;Database=apigerenciamento;User ID=GerenciamentoAdmin;Password=Passapi36;Trusted_Connection=False;Encrypt=True;");
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap()); 
        }
    }
}
       
