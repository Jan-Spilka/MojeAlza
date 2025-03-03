namespace Core.Models
{
    public class Product
    {
        /// <summary>
        /// The product unique identificator.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The product name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The product image resource identificator.
        /// </summary>
        public string ImgUri { get; set; } = string.Empty;

        /// <summary>
        /// The poduct price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The product description.
        /// </summary>
        public string? Description { get; set; }
    }
}
