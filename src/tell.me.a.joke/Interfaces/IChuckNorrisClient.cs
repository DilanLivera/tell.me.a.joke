using System.Threading.Tasks;
using tell.me.a.joke.Models;

namespace tell.me.a.joke.Interfaces
{
    public interface IChuckNorrisClient
    {
        Task<ChuckNorrisJoke> GetARandomJoke();
    }
}