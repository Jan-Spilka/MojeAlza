using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects
{
    public class ProductDescriptionDTO : IValidatableObject
    {
        /// <summary>
        /// Gets or sets product description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Determines whether the specified object is valid.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // TODO: We should implement validation - check length (if it is defined by database column), check for invalid characters maybe?
            if (this.Description?.Length > 4000)
            {
                yield return new ValidationResult("Description cannot exceed 4000 characters.", [nameof(this.Description)]);
            }
        }
    }
}
