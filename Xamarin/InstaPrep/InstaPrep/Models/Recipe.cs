﻿using System;
using System.Collections.Generic;

namespace InstaPrep.Models
{
    public class Recipe
    {
        public string Id { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Effort { get; set; } = string.Empty;

        public List<Ingredient> Ingredients = new List<Ingredient>();
    }
}