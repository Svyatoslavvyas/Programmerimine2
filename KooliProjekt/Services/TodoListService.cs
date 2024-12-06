using KooliProjekt.Data;
using KooliProjekt.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ApplicationDbContext _context;

        public TodoListService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Метод для получения списка TodoList с пагинацией
        public async Task<PagedResult<TodoList>> List(int page, int pageSize)
        {
            // Получаем общее количество элементов
            var totalCount = await _context.TodoLists.CountAsync();

            // Получаем элементы с учетом пагинации
            var items = await _context.TodoLists
                                      .Skip((page - 1) * pageSize)  // Пропускаем элементы на предыдущих страницах
                                      .Take(pageSize)               // Берем только нужное количество элементов
                                      .ToListAsync();

            return new PagedResult<TodoList>
            {
                TotalCount = totalCount,
                Items = items
            };
        }

        // Метод для получения конкретного TodoList по ID
        public async Task<TodoList> Get(int id)
        {
            return await _context.TodoLists.FirstOrDefaultAsync(m => m.Id == id);
        }

        // Метод для сохранения TodoList (для создания или обновления)
        public async Task Save(TodoList list)
        {
            if (list.Id == 0)
            {
                _context.Add(list);  // Если новый элемент, то добавляем
            }
            else
            {
                _context.Update(list);  // Если обновление существующего элемента
            }

            await _context.SaveChangesAsync();
        }

        // Метод для удаления TodoList
        public async Task Delete(int id)
        {
            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList != null)
            {
                _context.TodoLists.Remove(todoList);
                await _context.SaveChangesAsync();
            }
        }
    }
}
