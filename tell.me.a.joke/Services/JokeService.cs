using System.Threading.Tasks;
using tell.me.a.joke.Interfaces;
using tell.me.a.joke.Models;

namespace tell.me.a.joke.Services
{
    public class JokeService : IJokeService
    {
        private readonly IChuckNorrisClient _chuckNorrisClient;

        public JokeService(IChuckNorrisClient chuckNorrisClient)
        {
            _chuckNorrisClient = chuckNorrisClient;
        }

        public async Task<string> GetAJoke()
        {
            ChuckNorrisJoke chuckNorrisJoke = await _chuckNorrisClient.GetARandomJoke();

            return chuckNorrisJoke?.Joke;
        }
    }
}
