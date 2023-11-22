using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XprtzSerieApp.Extensions;

using Show = XprtzSerieApp.Database.ResponseData.Show;
using ShowEntity = XprtzSerieApp.Database.Entities.ShowEntity;

namespace XprtzSerieApp.Database
{
    public class ShowRepository : IShowRepository
    {
        private readonly ShowContext _showContext;
        private readonly IMapper _mapper;

        public ShowRepository(ShowContext showContext)
        {
            _showContext = showContext;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
        }

        public IQueryable<ShowEntity> GetAllShows() => _showContext.Shows;
        public IQueryable<Show> GetAllShowsOrderedByPremiered() => _showContext.Shows.OrderByDescending(s => s.Premiered).Select(s => _mapper.Map<Show>(s));

        public async Task<Show?> GetShowAsync(string name)
        {
            var show = await GetAllShows().FirstOrDefaultAsync(s => s.Name == name);

            if (show == null)
            {
                Console.WriteLine($"Could not find show with name {name}");
                return null;
            }

            return _mapper.Map<Show>(show);
        }

        public async Task SaveShowsAsync(List<Show> data)
        {
            var dataEntities = data.Select(s => _mapper.Map<ShowEntity>(s));
            _showContext.Shows.AddRange(dataEntities);
            await _showContext.SaveChangesAsync();

            Console.WriteLine($"All shows saved successfully");
        }

        public async Task SaveShow(Show newShow)
        {
            var newShowEntity = _mapper.Map<ShowEntity>(newShow);
            _showContext.Shows.Add(newShowEntity);
            await _showContext.SaveChangesAsync();
        }

        public async Task UpdateShow(Show show)
        {
            var showToUpdate = await _showContext.Shows.FindAsync(show.Id);

            if (showToUpdate == null)
            {
                Console.WriteLine($"Show with ID {show.Id} does not exist");
                return;
            }

            _mapper.Map(show, showToUpdate);
            await _showContext.SaveChangesAsync();
            Console.WriteLine($"Show with ID {show.Id} was updated successfully!");
        }

        public async Task RemoveShow(int id)
        {
            var showToRemove = await _showContext.Shows.FindAsync(id);

            if (showToRemove == null)
            {
                Console.WriteLine($"Show with ID {id} does not exist");
                return;
            }

            _showContext.Shows.Remove(showToRemove);
            await _showContext.SaveChangesAsync();
            Console.WriteLine($"Show with ID {id} was removed successfully!");
        }
    }
}
