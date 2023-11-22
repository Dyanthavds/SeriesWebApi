using XprtzSerieApp.Database.ResponseData;

namespace SynchronizeShows.Services.Interfaces
{
    public interface ITvMazeApiService
    {
        Task<List<Show>> GetDataFromApiAsync();
    }
}