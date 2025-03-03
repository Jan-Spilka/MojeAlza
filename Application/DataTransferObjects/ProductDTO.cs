using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects
{
    public class ProductDTO : ProductDescriptionDTO
    {
        /// <summary>
        /// The product unique identificator.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// The product name.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The product image resource identificator.
        /// </summary>
        [Required]
        [Url]
        public string ImgUri { get; set; } = string.Empty;

        /// <summary>
        /// The poduct price.
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Determines whether the specified object is valid.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (ValidationResult validationResult in base.Validate(validationContext))
            {
                yield return validationResult;
            }

            // TODO: We can add validation for Name length and price value
        }
    }
}
