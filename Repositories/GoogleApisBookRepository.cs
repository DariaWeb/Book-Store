using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BookStore.Helpers;
using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Models.Responses;
using Newtonsoft.Json;

namespace BookStore.Repositories
{
  public class GoogleApisBookRepository : IBookRepository
  {
    private static HttpClient _httpClient = new HttpClient
    {
      DefaultRequestHeaders = { Accept = { new MediaTypeWithQualityHeaderValue("application/json") } }
    };

        public async Task<IEnumerable<BookInfo>> GetBooks(string searchPhrase = "text")
        {
            var response = await _httpClient.GetStringAsync("https://www.googleapis.com/books/v1/volumes?maxResults=40&q=" + searchPhrase);

            var allBooks = JsonConvert.DeserializeObject<GoogleApiBookResponse>(response);
            var result = allBooks.Items.Select(b => new BookInfo
            {
                Authors = String.Join(", ", b.VolumeInfo.Authors),
                Description = b.VolumeInfo.Description,
                PublishedDate = b.VolumeInfo.PublishedDate,
                Title = b.VolumeInfo.Title,
                Image = b.VolumeInfo.ImageLinks.Thumbnail

            });
            return result;

        }
  }
}
