using bsbo_01_23_team4_var2_bibl2.Repository;

namespace bsbo_01_23_team4_var2_bibl2.UseCases;

public class ReturnBookUseCase : BaseUseCase
{
    public ReturnBookUseCase(ILibraryRepository repo) : base(repo) {}

    public override void Execute()
    {
        Console.Write("Введите ID книги: ");
        if (!int.TryParse(Console.ReadLine(), out int bookId)) return;

        var loan = repository.GetActiveLoanByBookId(bookId);
        if (loan == null)
        {
            Console.WriteLine("Эта книга не числится выданной.");
            return;
        }

        loan.MarkAsReturned();
        repository.UpdateLoan(loan);

        var book = repository.GetBookById(bookId);
        if (book != null)
        {
            book.MarkAsReturned();
            repository.UpdateBook(book);
        }

        Console.WriteLine("Книга успешно возвращена.");
    }
}