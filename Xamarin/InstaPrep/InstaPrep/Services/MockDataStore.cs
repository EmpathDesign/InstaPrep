using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var defaultIngredients = new ObservableCollection<Ingredient>()
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
                },
                new Ingredient()
                {
                    Title = "Onions",
                    Measure = "2 medium"
                },
                new Ingredient()
                {
                    Title = "Tomatoes",
                    Measure = "3 medium"
                },
                new Ingredient()
                {
                    Title = "Coconut Milk",
                    Measure = "14 oz"
                },
                new Ingredient()
                {
                    Title = "Green Bell Pepper",
                    Measure = "1 large"
                }
            };

            items = new List<Recipe>()
        {
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/H4fqk2mwQtlil9fc2FBrUrz8zYU=/648x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2007__03__salmon-moqueca-vertical-a-1600-d79c82bba5fb48c09de050fc0dbbfa6f.jpg",
                Title = "Brazilian Salmon Stew  (Moqueca)",
                Duration = "1-2 Hours",
                Effort = "Easy",
                Category = "Dinner",
                Rating = 1,
                Ingredients = defaultIngredients
            },
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/Cq-nXMpurSH2lkL5olkG1tIBeTE=/648x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2016__07__zucchini-noodle-chicken-pesto-bowl-vertical-a-1600-51560a436ab14af087d11aad2f9d2e3e.jpg",
                Title = "Zucchini Noodle Chicken Pesto Bowl",
                Duration = "1 Hour",
                Effort = "Easy",
                Category = "Dinner",
                Rating = 3,
                Ingredients = defaultIngredients
            },
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/b8GgK0mUbud6yc3kLSRYPHKUVXw=/648x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2020__09__Cauliflower-Bolognese-LEAD-3-fe948fa876eb4cf79e7a35d31d547d01.jpg",
                Title = "Roasted Cauliflower and Mushroom Bolognese",
                Duration = "1-2 Hours",
                Effort = "Medium",
                Category = "Dinner",
                Rating = 2,
                Ingredients = defaultIngredients
            },
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/rEdXZcMbkXMjKRnjWOG4-el-vdM=/736x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2007__11__indian-pudding-horiz-b-1500-6869491988a74d25a32a639c91a21b8d.jpg",
                Title = "Biscuits and Gravy",
                Duration = "35 Mins",
                Effort = "Easy",
                Category = "Breakfast",
                Rating = 2,
                Ingredients = defaultIngredients
            },
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/aSVwF5cLIPsxTV6Shh41yTfJzQI=/736x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2014__09__apple-pie-horiz-a-1800-1ffab9404eb04308a8149c7d69a52472.jpg",
                Title = "Homemade Apple Pie",
                Duration = "3 Hours",
                Effort = "Hard",
                Category = "Dessert",
                Rating = 1,
                Ingredients = defaultIngredients
            },
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/BAqLjRxK033r3pGPnwALHJ80_CY=/648x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2019__05__Skillet-Chicken-Enchiladas-LEAD-1-3d326763d3124f85aaa4f8e2c31e0b82.jpg",
                Title = "Chicken Skillet Enchiladas",
                Duration = "30 mins",
                Effort = "Easy",
                Category = "Lunch",
                Rating = 3,
                Ingredients = defaultIngredients
            },
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/3VuNE13QbPX2dDsoMcp_4qg6OBg=/648x0/filters:no_upscale():max_bytes(150000):strip_icc()/Simply-Recipes-Grilled-Carrot-Dogs-LEAD-03-db0d312473e640aabdb547483bce7a57.jpg",
                Title = "Grilled Carrot Dogs",
                Duration = "20 Mins",
                Effort = "Easy",
                Category = "Lunch",
                Rating = 1,
                Ingredients = defaultIngredients
            },
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/rEdXZcMbkXMjKRnjWOG4-el-vdM=/736x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2007__11__indian-pudding-horiz-b-1500-6869491988a74d25a32a639c91a21b8d.jpg",
                Title = "Indian Pudding",
                Duration = "3 Hours",
                Effort = "Hard",
                Category = "Dessert",
                Rating = 3,
                Ingredients = defaultIngredients
            },
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/DFSfnV2aoG9TpytLRp8JTd5TBBM=/648x0/filters:no_upscale():max_bytes(150000):strip_icc()/Simply-Recipes-Biscuits-and-Gravy-LEAD-06-bfe0bb039e0d4fbdb7e54631520bd0b3.jpg",
                Title = "Biscuits and Gravy",
                Duration = "35 Mins",
                Effort = "Easy",
                Category = "Breakfast",
                Rating = 2,
                Ingredients = defaultIngredients
            },
            new Recipe()
            {
                ImageUrl = "https://www.simplyrecipes.com/thmb/bNcU9U1FIwiOX9udpMzvry-EKu0=/648x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2015__03__spinach-artichoke-quiche-vertical-600-4314be8d4e534c15a9f817d96822e31f.jpg",
                Title = "Spinach and Artichoke Quiche",
                Duration = "3 Hours",
                Effort = "Hard",
                Category = "Breakfast",
                Rating = 3,
                Ingredients = defaultIngredients
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
