namespace Nucleus.Application.Common.Models;

public class PaginatedList<T>
{
    const int DefaultPageNumber = 1;
    private const int DefaultPageSize = 10;
    public IReadOnlyCollection<T> Items { get; }
    public int PageNumber { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }

    public PaginatedList(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }

    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int? pageNumber = DefaultPageNumber, int? pageSize = DefaultPageSize)
    {
        var count = await source.CountAsync();
        
        // Set Defaults if null
        pageNumber ??= DefaultPageNumber;
        pageSize ??= DefaultPageSize;
        
        var items = await source.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync();

        return new PaginatedList<T>(items, count, pageNumber.Value, pageSize.Value);
    }
}
