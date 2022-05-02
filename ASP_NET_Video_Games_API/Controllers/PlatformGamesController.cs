using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Video_Games_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformGamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlatformGamesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult GetGamesCount()
        {
            var allPlatforms = _context.VideoGames.Select(vg => vg.Platform).Distinct().ToList();
            List<object> allTimeGames = new List<object>();
        
                    foreach(var platform in allPlatforms)
            {
                var toAdd = _context.VideoGames.Where(vg => vg.Platform == platform).ToList().Count();

        allTimeGames.Add(toAdd);
            }

            return Ok(allTimeGames);
}
    }
}
