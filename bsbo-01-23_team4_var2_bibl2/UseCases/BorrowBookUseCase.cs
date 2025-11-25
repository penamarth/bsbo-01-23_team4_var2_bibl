using bsbo_01_23_team4_var2_bibl2.Domain;
using bsbo_01_23_team4_var2_bibl2.Repository;

namespace bsbo_01_23_team4_var2_bibl2.UseCases;

public class BorrowBookUseCase : BaseUseCase
{
    public BorrowBookUseCase(ILibraryRepository repo) : base(repo) {}

    public override void Execute()
    {
        Console.Write("Введите ID книги: ");
        if (!int.TryParse(Console.ReadLine(), out int bookId)) return;

        var book = repository.GetBookById(bookId);
        if (book == null)
        {
            Console.WriteLine("Книга не найдена.");
            return;
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine("Книга уже выдана.");
            return;
        }

        Console.Write("Введите ID читателя: ");
        if (!int.TryParse(Console.ReadLine(), out int readerId)) return;

        var reader = repository.GetReaderById(readerId);
        if (reader == null)
        {
            Console.WriteLine("Читатель не найден.");
            return;
        }

        book.MarkAsBorrowed();
        repository.UpdateBook(book);

        var loan = new Loan(book.Id, reader.Id);
        repository.AddLoan(loan);

        Console.WriteLine($"Книга \"{book.Title}\" выдана читателю {reader.Name}.");
    }
}