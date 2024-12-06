// Папка Models, файл TodoList.cs
namespace KooliProjekt.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<TodoItem> Items { get; set; } // Связь с TodoItem
    }
}
