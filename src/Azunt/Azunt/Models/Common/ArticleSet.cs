using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a generic data container for paginated or grouped results.
/// </summary>
/// <typeparam name="T">The type of items in the result set.</typeparam>
/// <typeparam name="V">The type of the total count (e.g., int, long).</typeparam>
public class ArticleSet<T, V>
{
    /// <summary>
    /// Gets or sets the collection of items.
    /// </summary>
    public IEnumerable<T> Items { get; set; }

    /// <summary>
    /// Gets or sets the total count of items (e.g., for pagination).
    /// </summary>
    public V TotalCount { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArticleSet{T, V}"/> class
    /// with an empty items list and default total count.
    /// </summary>
    public ArticleSet()
    {
        Items = Enumerable.Empty<T>();
        TotalCount = default(V);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ArticleSet{T, V}"/> class
    /// with the specified items and total count.
    /// </summary>
    /// <param name="items">The items to include in the result set.</param>
    /// <param name="totalCount">The total count of items.</param>
    public ArticleSet(IEnumerable<T> items, V totalCount)
    {
        Items = items ?? Enumerable.Empty<T>();
        TotalCount = totalCount;
    }
}
