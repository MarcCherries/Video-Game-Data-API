using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Video_Games_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RankController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet]

        public IActionResult GetTop100()
        {
            var top100 = _context.VideoGames.Where(vg => vg.Rank < 101).OrderByDescending(vg => vg.Rank);


            return Ok(top100);
                }
    }

}
