using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookInfo>> GetBooks(string searchPhrase);
    }
}
