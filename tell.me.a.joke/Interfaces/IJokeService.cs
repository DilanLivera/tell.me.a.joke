using System.Threading.Tasks;

namespace tell.me.a.joke.Interfaces
{
    public interface IJokeService
    {
        Task<string> GetAJoke();
    }
}