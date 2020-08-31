using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using tell.me.a.joke.Interfaces;
using tell.me.a.joke.Models;

namespace tell.me.a.joke.HttpClients
{
    public class ChuckNorrisClient : IChuckNorrisClient
    {
        private readonly HttpClient _client;

        public ChuckNorrisClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<ChuckNorrisJoke> GetARandomJoke()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "jokes/random");
            using var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var joke = await response.Content.ReadFromJsonAsync<RandomChuckNorrisJoke>();
                    return joke.Value;
                }
                catch (NotSupportedException)
                {
                    Console.WriteLine("The content type is not supported.");
                }
                catch (JsonException)
                {
                    Console.WriteLine("Invalid JSON.");
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            return null;
        }
    }
}
