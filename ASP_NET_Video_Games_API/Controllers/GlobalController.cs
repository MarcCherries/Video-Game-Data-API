using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Video_Games_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GlobalController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetVideoGamesSince2013()
        {
            var videoGamePublishers = _context.VideoGames.Where(vg => vg.Year >= 2013).Select(vg => vg.Platform).Distinct().ToList();
            List<object> gameData = new List<object>();



            foreach (var videoGame in videoGamePublishers)
            {
                var toAdd = _context.VideoGames.Where(vg => vg.Year >= 2013 && vg.Platform == videoGame).Select(vg => vg.GlobalSales).Sum();
                gameData.Add(toAdd);
            }
            return Ok(gameData);
        }
    }
}
