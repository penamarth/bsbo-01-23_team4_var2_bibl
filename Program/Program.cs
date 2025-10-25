using System;
using System.Collections.Generic;

class Program
{
    static List<Book> books = new List<Book>();
    static List<Reader> readers = new List<Reader>();
    static List<Loan> loans = new List<Loan>();
    
    static void Main()
    {
        // Тестовые данные
        books.Add(new Book { Id = 1, Title = "Война и мир", Author = "Толстой" });
        readers.Add(new Reader { Id = 1, Name = "Иван Иванов" });
        
        Console.WriteLine("БИБЛИОТЕКА");
        
        while (true)
        {
            Console.WriteLine("\n1 - Выдать книгу (Никита)");
            Console.WriteLine("2 - Вернуть книгу (Юра)");
            Console.WriteLine("3 - Добавить книгу (Даша)");
            Console.WriteLine("4 - Списать книгу (Лиана)");
            Console.Write("Выберите: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    BorrowBookUseCase.Execute(books, readers, loans);
                    break;
                case "2":
                    ReturnBookUseCase.Execute(books, readers, loans);
                    break;
                case "3":
                    AddBookUseCase.Execute(books);
                    break;
                case "4":
                    WriteOffBookUseCase.Execute(books);
                    break;
            }
        }
    }
}

public class Book
{
    public int Id;
    public string Title = "";
    public string Author = "";
    public bool IsAvailable = true;
}

public class Reader
{
    public int Id;
    public string Name = "";
}

public class Loan
{
    public int BookId;
    public int ReaderId;
}
