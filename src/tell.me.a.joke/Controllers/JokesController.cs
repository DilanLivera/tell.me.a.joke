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

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var joke = await _jokeService.GetAJoke();

            return Ok(joke);
        }
    }
}
