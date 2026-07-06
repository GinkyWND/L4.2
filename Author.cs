using System.Collections.Generic;

namespace EFConsoleApp
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;

        // Навигационное свойство: связь "один-ко-многим"
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
