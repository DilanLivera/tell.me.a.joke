using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using tell.me.a.joke.Interfaces;

namespace tell.me.a.joke.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly IJokeService _jokeService;

        public JokesController(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync()
        {
            var joke = await _jokeService.GetAJoke();

            return new OkObjectResult(joke);
        }
    }
}
