using Microsoft.EntityFrameworkCore;
using web_api_lista_funcionarios.Models;


namespace web_api_lista_funcionarios.DataContext {
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}
