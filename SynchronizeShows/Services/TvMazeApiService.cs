using Microsoft.Extensions.Configuration;
using SynchronizeShows.Services.Interfaces;
using XprtzSerieApp.Database.Entities;
using XprtzSerieApp.Database.ResponseData;

namespace SynchronizeShows.Services
{
    public class TvMazeApiService : ITvMazeApiService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public TvMazeApiService(IConfiguration configuration)
        {
            _apiKey = configuration["TvMazeSeriesKey"];
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://www.tvmaze.com/")
            };
        }

        public async Task<List<Show>> GetDataFromApiAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}search/shows");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<Show>();
        }
    }
}
