using XprtzSerieApp.Database.ResponseData;

namespace XprtzSerieApp.Database
{
    public interface IShowRepository
    {
        public IQueryable<Show> GetAllShowsOrderedByPremiered();
        public Task<Show?> GetShowAsync(string name);
        public Task SaveShow(Show newShow);
        public Task RemoveShow(int id);
        public Task UpdateShow(Show show);
        public Task SaveShowsAsync(List<Show> data);
    }
}