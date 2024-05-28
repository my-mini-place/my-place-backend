using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PagedList<T>
    {
        public PagedList(List<T> items, int totalCount, int pageIndex, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public bool HasNextPage => PageIndex * PageSize < TotalCount;
        public bool HasPreviousPage => PageIndex > 1;


        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int pagaIndex, int pageSize)
        {
            int TotalCount = await query.CountAsync();
            var items = await query.Skip((pagaIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new(items, TotalCount, pagaIndex, pageSize);
        }
    }
}
