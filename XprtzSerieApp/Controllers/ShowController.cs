using Microsoft.AspNetCore.Mvc;
using XprtzSerieApp.Database;
using XprtzSerieApp.Database.ResponseData;

namespace XprtzSerieApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowController : ControllerBase
    {
        private readonly IShowRepository _showRepository;

        public ShowController(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        [HttpGet("show")]
        public async Task<Show?> Search(string name)
        {
            return await _showRepository.GetShowAsync(name);
        }

        [HttpGet("shows")]
        public IEnumerable<Show> GetAllShows()
        {
            return _showRepository.GetAllShowsOrderedByPremiered();
        }

        [HttpPost]
        public void PostShow([FromBody] Show show)
        {
            _showRepository.SaveShow(show);
        }
        
        [HttpPut]
        public void UpdateShow([FromBody] Show show)
        {
            _showRepository.UpdateShow(show);
        }
        
        [HttpDelete]
        public void DeleteShow(int showId)
        {
            _showRepository.RemoveShow(showId);
        }
    }
}