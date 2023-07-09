using System;
using Microsoft.EntityFrameworkCore;

namespace HomeExpenses.Tracking.Application.Shared.DTOs
{
	public class PaginatedList<T> where T : class
    {

        public IReadOnlyCollection<T> Items { get; }
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public PaginatedList(IReadOnlyCollection<T> items, int pageNumber, int pageSize, int totalCount)
        {
            Items = items;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize); ;
            TotalCount = totalCount;
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> itemsSource, int pageNumber, int pageSize)
        {
            var total = await itemsSource.CountAsync();
            var items = await itemsSource.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, pageNumber, pageSize, total);
        }
	}
}

