using la_mia_pizzeria_static.Validation;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }

        [Required(ErrorMessage = "In nome della pizza e' obbligatorio")]
        [StringLength(50)]
        public string? Name { get; set; }

        
        
        [Required(AllowEmptyStrings = false , ErrorMessage = "La descrizione della pizza e' obbligatoria")]
        [FiveWordsValidation]
        public string Description { get; set; }

        [Required(ErrorMessage = "L'immagine e' obbligatoria")]
        [Url]
        public string? ImgPath { get; set; }

        [Required(ErrorMessage = "Il prezzo e' obbligatorio")]
        [Range(1,30, ErrorMessage = "Il prezzo della pizza deve essere incluso tra 1 e 30 euro")]
        public decimal Price { get; set; }

        public int? CategoryId { get; set; } = null;
        public Category? Category { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
    }
}