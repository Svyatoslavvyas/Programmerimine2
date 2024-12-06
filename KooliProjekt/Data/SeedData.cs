using Microsoft.AspNetCore.Identity;
using KooliProjekt.Models; // Не забудьте добавить правильное пространство имен для ваших моделей
using System.Linq;
using System.Threading.Tasks;

namespace KooliProjekt.Data
{
    public static class SeedData
    {
        public static async Task Generate(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            // Проверяем, есть ли уже данные в базе
            if (context.TodoLists.Any())
            {
                return; // Если данные уже есть, выходим из метода
            }

            // Если данных нет, создаём нового пользователя
            var user = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@example.com",
                EmailConfirmed = true, // Устанавливаем EmailConfirmed в true, чтобы не требовать подтверждения
            };

            // Создаём администратора
            var userCreationResult = await userManager.CreateAsync(user, "Password123!");
            if (!userCreationResult.Succeeded)
            {
                throw new Exception("Не удалось создать администратора.");
            }

            // Добавляем TodoLists с элементами
            var list = new TodoList { Title = "List 1" };
            list.Items = new List<TodoItem>  // Инициализация коллекции Items
            {
                new TodoItem { Title = "Item 1.1" },
                new TodoItem { Title = "Item 1.2" }
            };

            // Добавляем новый список в контекст
            context.TodoLists.Add(list);

            // Сохраняем изменения в базе данных
            await context.SaveChangesAsync();
        }
    }
}
