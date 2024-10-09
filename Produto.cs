using System.ComponentModel.DataAnnotations;

namespace Estoque.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Patrimonio { get; set; }

        [Range(0, 10000)]
        public int Quantidade { get; set; }

        [Range(0, 10000)]
        public int MinQuantidade { get; set; }

        [Range(1, 10000)]
        public int MaxQuantidade { get; set; }

        [Range(0, 100000)]
        public decimal Preco { get; set; }

        // Custom validation logic
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Quantidade < MinQuantidade || Quantidade > MaxQuantidade)
            {
                yield return new ValidationResult(
                    "Quantity must be between MinQuantity and MaxQuantity",
                    new[] { nameof(Quantidade) });
            }
        }
    }
}


