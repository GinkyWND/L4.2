namespace EFConsoleApp
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Year { get; set; }
        public string Genre { get; set; } = null!;

        // Внешний ключ для связи с автором
        public int AuthorId { get; set; }
        // Навигационное свойство
        public Author Author { get; set; } = null!;
    }
}
