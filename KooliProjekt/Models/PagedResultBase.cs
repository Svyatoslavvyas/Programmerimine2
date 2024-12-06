namespace KooliProjekt.Models
{
    public class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int RowCount { get; set; }
        public int FirstRowOnPage => (CurrentPage - 1) * 10 + 1;  // Пример: 10 элементов на странице
        public int LastRowOnPage => Math.Min(CurrentPage * 10, RowCount);  // Ограничиваем по количеству строк

        // Другие свойства, связанные с пагинацией, можно добавить по необходимости
    }
}
