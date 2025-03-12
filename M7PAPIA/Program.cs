using System;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace M7PAPIA
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Pokemon> recents = [];
            bool continuing = true;
            do
            {
                try
                {
                    Console.WriteLine("Welcome to The Pokedex! Enter a pokemon NAME or ID (no preceding zeros):");
                    string name_or_id = (Console.ReadLine()).ToLower();
                    if (name_or_id == "") throw new Exception();

                    using HttpClient client = new();
                    string url = $"https://pokeapi.co/api/v2/pokemon/{name_or_id}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var deserialized = JsonConvert.DeserializeObject<Pokemon>(jsonResponse);
                    recents.Add(deserialized);
                }
                catch (NetworkInformationException)
                {
                    Console.WriteLine("CANNOT CONNECT TO pokeapi.co!");
                }
                catch (JsonException)
                {
                    Console.WriteLine("The entered NAME/ID couldn't be retrieved. Try Again.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Either your entered NAME/ID is wrong, or a general exception occured. Try Again.");
                }

                Console.WriteLine($"{String.Join("\n", recents)}\n");
            }
            while (continuing);
        }
    }
}