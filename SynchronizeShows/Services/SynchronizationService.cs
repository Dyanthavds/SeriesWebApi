using SynchronizeShows.Services.Interfaces;
using XprtzSerieApp.Database;

namespace SynchronizeShows.Services
{
    public class SynchronizationService : ISynchronizationService
    {
        private readonly ITvMazeApiService _tvMazeApiService;
        private readonly IShowRepository _showRepository;

        public SynchronizationService(ITvMazeApiService tvMazeApiService, IShowRepository showRepository)
        {
            _tvMazeApiService = tvMazeApiService;
            _showRepository = showRepository;
        }

        public async Task SynchronizeAsync()
        {
            var data = await _tvMazeApiService.GetDataFromApiAsync();
            await _showRepository.SaveShowsAsync(data);           
        }
    }
}
