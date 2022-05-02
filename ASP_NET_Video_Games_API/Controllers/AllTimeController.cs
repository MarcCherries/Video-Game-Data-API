using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Video_Games_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllTimeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AllTimeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllTimeSales()
        {
            var allPlatforms = _context.VideoGames.Select(vg => vg.Platform).Distinct().ToList();
            List<object> allTimeSales = new List<object>();

            foreach(var platform in allPlatforms)
            {
                var toAdd = _context.VideoGames.Where(vg => vg.Platform == platform).Select(vg => vg.GlobalSales).Sum();
              
                allTimeSales.Add(toAdd);
            }

            return Ok(allTimeSales);
        }
    }

}
