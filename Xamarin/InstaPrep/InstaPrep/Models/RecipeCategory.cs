using System;
namespace InstaPrep.Models
{
	public class RecipeCategory
	{
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public RecipeCategory()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

