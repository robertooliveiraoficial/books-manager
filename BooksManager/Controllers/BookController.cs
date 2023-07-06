using BooksManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BooksManager.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    #region Declarações
    private static List<Book> books = new List<Book>();
    private static string urlJson = "https://raw.githubusercontent.com/timeiagro/BackendProvaConceitoTimeIAGRO/main/books.json";
    #endregion

    [HttpGet("GetBooks")]
    public async Task<List<Book>> JsonForBooks()
    {
        var getJson = string.Empty;
        var getJsonFile = await new HttpClient().GetStringAsync(urlJson);
        books = JsonSerializer.Deserialize<List<Book>>(getJsonFile)!;
        return books;
    }

    [HttpGet("OrderByPriceAsc")]
    public async Task<List<Book>> GetBooksOrderByPriceAsc()
    {
        var getJson = string.Empty;
        var getJsonFile = await new HttpClient().GetStringAsync(urlJson);

        books = JsonSerializer.Deserialize<List<Book>>(getJsonFile)!;
        
        return books.OrderBy(b => b.Preco).ToList();
    }

    [HttpGet("OrderByPriceDesc")]
    public async Task<List<Book>> GetBooksOrderByPriceDesc()
    {
        var getJson = string.Empty;
        var getJsonFile = await new HttpClient().GetStringAsync(urlJson);

        books = JsonSerializer.Deserialize<List<Book>>(getJsonFile)!;
        return books.OrderByDescending(b => b.Preco).ToList();            
    }

    [HttpGet("GetBooksByAuthorName")]
    public async Task<List<Book>> GetBooksByAuthorName(string author)
    {
        var getJson = string.Empty;
        var getJsonFile = await new HttpClient().GetStringAsync(urlJson);

        books = JsonSerializer.Deserialize<List<Book>>(getJsonFile)!;

        return books.Where(b => b.Especificacoes!.Autor!.Contains(author)).ToList();
    }

    [HttpGet("GetBooksByBookName")]
    public async Task<List<Book>> GetBooksByBookName(string bookName)
    {
        var getJson = string.Empty;
        var getJsonFile = await new HttpClient().GetStringAsync(urlJson);

        books = JsonSerializer.Deserialize<List<Book>>(getJsonFile)!;

        return books.Where(b => b.Nome!.Contains(bookName)).ToList();
    }

    [HttpGet("GetBooksByGenre")]
    public async Task<List<Book>> GetBooksByGenre(string genre)
    {
        var getJson = string.Empty;
        var getJsonFile = await new HttpClient().GetStringAsync(urlJson);

        books = JsonSerializer.Deserialize<List<Book>>(getJsonFile)!;

        return books.Where(b => b.Especificacoes!.Genres!.ToString()!.Contains(genre)).ToList();
    }    
}
