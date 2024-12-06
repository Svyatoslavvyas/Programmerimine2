namespace KooliProjekt.Models
{
    public class PagedResult<T>
    {
        public int TotalCount { get; set; } // Общее количество элементов
        public List<T> Items { get; set; }  // Список элементов текущей страницы

        public PagedResult()
        {
            Items = new List<T>(); // Инициализируем список
        }
    }
}
