// Папка Models, файл TodoItem.cs
namespace KooliProjekt.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public int TodoListId { get; set; } // Внешний ключ для связи с TodoList
        public TodoList TodoList { get; set; } // Навигационное свойство
    }
}
