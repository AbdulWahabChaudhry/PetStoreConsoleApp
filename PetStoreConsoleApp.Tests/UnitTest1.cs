using System.Collections.Generic;
using System.Linq;
using Xunit;
using PetStoreConsole;
using PetStoreConsole.Models;

namespace PetStoreConsole.Tests
{
    public class PetStoreServiceTests
    {
        [Fact]
        public void GroupPetsByCategory_ReverseAlphabetical_SimpleTest()
        {
            // Arrange: We create a small list of Pets with different category names
            var pets = new List<Pet>
            {
                new Pet { Id = 1, Name = "Charlie", Category = new Category { Name = "Dogs" } },
                new Pet { Id = 2, Name = "Buddy",   Category = new Category { Name = "Dogs" } },
                new Pet { Id = 3, Name = "Ziggy",   Category = new Category { Name = "Cats" } },
                new Pet { Id = 4, Name = "Max",     Category = new Category { Name = "Dogs" } },
                new Pet { Id = 5, Name = "Oscar",   Category = null } // category is unknown
            };

            // Act: Group by category name (or "Unknown"), then sort each group in reverse alphabetical order
            var grouped = pets
                .GroupBy(p => p.Category?.Name ?? "Unknown")
                .OrderBy(g => g.Key);

            // We'll pick the "Dogs" category from the results
            var dogsGroup = grouped.FirstOrDefault(g => g.Key == "Dogs");
            var dogsSorted = dogsGroup.OrderByDescending(p => p.Name).ToList();

            // Assert: We expect "Max" -> "Charlie" -> "Buddy" in reverse alphabetical order
            Assert.Equal("Max", dogsSorted[0].Name);
            Assert.Equal("Charlie", dogsSorted[1].Name);
            Assert.Equal("Buddy", dogsSorted[2].Name);
        }
    }
}
