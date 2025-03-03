namespace Application.DataTransferObjects
{
    public class PageResultDTO<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageResultDTO<typeparamref name="T"/>"/> class.
        /// </summary>
        /// <param name="items">The items in page.</param>
        /// <param name="itemsCountTotal">The count of all items.</param>
        /// <param name="pageSize">The size of page.</param>
        public PageResultDTO(List<T> items, int itemsCountTotal, int pageSize)
        {
            this.Items = items;
            this.ItemCountTotal = itemsCountTotal;
            this.PagesCount = (int)Math.Ceiling(itemsCountTotal / (double)pageSize);
        }

        /// <summary>
        /// Gets items in page.
        /// </summary>
        public List<T> Items { get; }

        /// <summary>
        /// Get all items count.
        /// </summary>
        public int ItemCountTotal { get; }

        /// <summary>
        /// Gets all pages count.
        /// </summary>
        public int PagesCount { get; }
    }
}
