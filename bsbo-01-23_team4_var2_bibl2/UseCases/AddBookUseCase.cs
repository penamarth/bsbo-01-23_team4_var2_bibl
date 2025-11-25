using bsbo_01_23_team4_var2_bibl2.Domain;
using bsbo_01_23_team4_var2_bibl2.Repository;

namespace bsbo_01_23_team4_var2_bibl2.UseCases;

public class AddBookUseCase : BaseUseCase
{
    public AddBookUseCase(ILibraryRepository repo) : base(repo) {}

    public override void Execute()
    {
        Console.Write("Введите название книги: ");
        string? title = Console.ReadLine();
        Console.Write("Введите автора: ");
        string? author = Console.ReadLine();

        int newId = repository.GetAllBooks().Any() ? repository.GetAllBooks().Max(b => b.Id) + 1 : 1;

        var book = new Book(newId, title ?? "Без названия", author ?? "Неизвестен");
        repository.AddBook(book);

        Console.WriteLine($"Книга \"{book.Title}\" успешно добавлена.");
    }
}