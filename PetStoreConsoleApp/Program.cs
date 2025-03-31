using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // The URL to get only "available" pets from the PetStore API
                const string petStoreUrl = "https://petstore.swagger.io/v2/pet/findByStatus?status=available";

                // Create an instance of our PetStoreService
                var petStoreService = new PetStoreService();

                // Fetch the list of available pets
                var availablePets = await petStoreService.GetAvailablePetsAsync(petStoreUrl);

                // Group pets by Category name, defaulting to "Unknown" if null
                var groupedPets = availablePets
                    .GroupBy(pet => pet.Category?.Name ?? "Unknown")
                    .OrderBy(g => g.Key);

                foreach (var group in groupedPets)
                {
                    Console.WriteLine($"Category: {group.Key}");

                    // Sort pets in reverse alphabetical order by name
                    var sortedPets = group.OrderByDescending(p => p.Name);

                    foreach (var pet in sortedPets)
                    {
                        Console.WriteLine($"   {pet.Name} (ID: {pet.Id})");
                    }

                    Console.WriteLine(); // Blank line after each category
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching data from Pet Store:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
