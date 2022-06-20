using System;
namespace InstaPrep.Models
{
	public class Ingredient
	{
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Measure { get; set; } = string.Empty;

        public Ingredient()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

