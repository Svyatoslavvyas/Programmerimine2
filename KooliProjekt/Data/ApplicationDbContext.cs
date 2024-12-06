using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Models; // Не забывайте добавить это пространство имен

namespace KooliProjekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Добавьте DbSet для TodoList и TodoItem
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
