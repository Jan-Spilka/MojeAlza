namespace Core.Models
{
    public class PaginatedList<T> : List<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedList<typeparamref name="T"/>"/> class.
        /// </summary>
        /// <param name="collection">The collection items.</param>
        /// <param name="itemsCountTotal">The count of all items.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The size of page.</param>
        public PaginatedList(IEnumerable<T> collection, int itemsCountTotal, int pageIndex, int pageSize)
            : base(collection)
        {
            this.ItemsCountTotal = itemsCountTotal;
            this.PageIndex = pageIndex;
            this.PagesCount = (int)Math.Ceiling(itemsCountTotal / (double)pageSize);
        }

        /// <summary>
        /// Get all items count.
        /// </summary>
        public int ItemsCountTotal { get; }

        /// <summary>
        /// Gets page index.
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        /// Gets all pages count.
        /// </summary>
        public int PagesCount { get; }

        /// <summary>
        /// Gets value indicating whether is another page available before this page.
        /// </summary>
        public bool HasPreviousPage => this.PageIndex > 1;

        /// <summary>
        /// Gets value indicating whether is another page available after this page.
        /// </summary>
        public bool HasNextPage => this.PageIndex < PagesCount;
    }
}
