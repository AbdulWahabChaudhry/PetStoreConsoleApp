using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PetStoreConsole.Models;

namespace PetStoreConsole
{
    public class PetStoreService
    {
        private readonly HttpClient _httpClient;

        public PetStoreService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Fetches the list of pets that have status=available from the given URL.
        /// </summary>
        /// <param name="url">The PetStore endpoint URL for fetching available pets.</param>
        /// <returns>A list of Pet objects.</returns>
        public async Task<List<Pet>> GetAvailablePetsAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var jsonContent = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON into a list of Pet objects
            var pets = JsonSerializer.Deserialize<List<Pet>>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Just in case we get null from the deserializer
            return pets ?? new List<Pet>();
        }
    }
}
