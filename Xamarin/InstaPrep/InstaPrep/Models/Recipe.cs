using System;
using System.Collections.Generic;

namespace InstaPrep.Models
{
    public class Recipe
    {
        public string Id { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; } = 1;
        public string Duration { get; set; } = string.Empty;
        public string Effort { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public List<Ingredient> Ingredients = new List<Ingredient>();

        public Recipe()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
