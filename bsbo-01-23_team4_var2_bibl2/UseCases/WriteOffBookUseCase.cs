using bsbo_01_23_team4_var2_bibl2.Repository;

namespace bsbo_01_23_team4_var2_bibl2.UseCases;

public class WriteOffBookUseCase : BaseUseCase
{

    public WriteOffBookUseCase(ILibraryRepository repo) : base(repo) {}
    public override void Execute()
    {
        Console.Write("Введите ID книги для списания: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;

        var book = repository.GetBookById(id);
        if (book == null)
        {
            Console.WriteLine("Книга не найдена.");
            return;
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine("Нельзя списать книгу, которая сейчас выдана.");
            return;
        }

        repository.RemoveBook(book);
        Console.WriteLine($"Книга \"{book.Title}\" Списана из фонда.");
    }
}
