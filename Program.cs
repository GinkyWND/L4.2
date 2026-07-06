using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext db = new AppDbContext())
            {
                // 1. Создаем БД (если её еще нет)
                db.Database.EnsureCreated();

                // 2. Наполняем БД данными, если она пуста
                if (!db.Authors.Any())
                {
                    Console.WriteLine("Заполнение базы данных начальными данными...");

                    var author1 = new Author { Name = "Дж. Р. Р. Толкин", Country = "Великобритания" };
                    var author2 = new Author { Name = "Федор Достоевский", Country = "Россия" };

                    db.Authors.AddRange(author1, author2);

                    db.Books.AddRange(
                        new Book { Title = "Хоббит", Year = 1937, Genre = "Фэнтези", Author = author1 },
                        new Book { Title = "Властелин Колец", Year = 1954, Genre = "Фэнтези", Author = author1 },
                        new Book { Title = "Преступление и наказание", Year = 1866, Genre = "Роман", Author = author2 },
                        new Book { Title = "Идиот", Year = 1869, Genre = "Роман", Author = author2 }
                    );

                    db.SaveChanges();
                    Console.WriteLine("Данные успешно сохранены!\n");
                }

                // 3. Запрос с использованием EF (Eager Loading через Include)
                // Загружаем книги вместе со связанными авторами
                var detailedBooks = db.Books
                    .Include(b => b.Author)
                    .OrderBy(b => b.Year)
                    .ToList();

                // 4. Вывод подробной информации
                Console.WriteLine("====== ПОДРОБНАЯ ИНФОРМАЦИЯ О КНИГАХ И АВТОРАХ ======");
                foreach (var book in detailedBooks)
                {
                    Console.WriteLine($"Книга: \"{book.Title}\" ({book.Year} г.)");
                    Console.WriteLine($"Жанр:  {book.Genre}");
                    Console.WriteLine($"Автор: {book.Author.Name} (Страна: {book.Author.Country})");
                    Console.WriteLine(new string('-', 50));
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
