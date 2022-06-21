using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaPrep.Models;

namespace InstaPrep.Services
{
    public class MockDataStore : IDataStore<Recipe>
    {
        readonly List<Recipe> items;

        public MockDataStore()
        {
            items = new List<Recipe>()
        {
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/H4fqk2mwQtlil9fc2FBrUrz8zYU=/648x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2007__03__salmon-moqueca-vertical-a-1600-d79c82bba5fb48c09de050fc0dbbfa6f.jpg",
                Title = "Brazilian Salmon Stew  (Moqueca)",
                Duration = "1-2 Hours",
                Effort = "Easy",
                Rating = 1,
                Ingredients = new List<Ingredient>()
                {
                    new Ingredient()
                    {
                        Title = "Garlic",
                        Measure = "4 cloves"
                    },
                    new Ingredient()
                    {
                        Title = "Lime Juice",
                        Measure = "2 tbsp"
                    },
                    new Ingredient()
                    {
                        Title = "Salt",
                        Measure = "3/4 tsp"
                    }
                }
            },
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/Cq-nXMpurSH2lkL5olkG1tIBeTE=/648x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2016__07__zucchini-noodle-chicken-pesto-bowl-vertical-a-1600-51560a436ab14af087d11aad2f9d2e3e.jpg",
                Title = "Zucchini Noodle Chicken Pesto Bowl",
                Duration = "1 Hour",
                Effort = "Easy",
                Rating = 3
            },
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/b8GgK0mUbud6yc3kLSRYPHKUVXw=/648x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2020__09__Cauliflower-Bolognese-LEAD-3-fe948fa876eb4cf79e7a35d31d547d01.jpg",
                Title = "Roasted Cauliflower and Mushroom Bolognese",
                Duration = "1-2 Hours",
                Effort = "Medium",
                Rating = 2
            },
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/aSVwF5cLIPsxTV6Shh41yTfJzQI=/736x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2014__09__apple-pie-horiz-a-1800-1ffab9404eb04308a8149c7d69a52472.jpg",
                Title = "Homemade Apple Pie",
                Duration = "3 Hours",
                Effort = "Hard",
                Rating = 2
            }
        };
        }

        public async Task<bool> AddItemAsync(Recipe item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Recipe item)
        {
            var oldItem = items.Where((Recipe arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Recipe arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Recipe> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Recipe>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
