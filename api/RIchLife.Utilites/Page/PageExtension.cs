using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RIchLife.Utilites.Page
{
    public static class PageExtension
    {
        public static PageResponse<TRes> GetPage<T, TRes>(this IQueryable<T> query, IPageRequest page,
            Expression<Func<T, TRes>> action)
        {
            var res = new PageResponse<TRes>();
            res.Count = query.Count();
            res.Current = page.Skip / page.Take + 1;
            res.Size = page.Take;
            res.Data = query.Page(page).Select(action).ToList();
            return res;
        }

        public static async Task<PageResponse<TRes>>
            GetPageAsync<T, TRes>(this IQueryable<T> query, IPageRequest page, Expression<Func<T, TRes>> action)
        {
            var res = new PageResponse<TRes>();
            res.Count = await query.CountAsync();
            res.Current = page.Skip / page.Take + 1;
            res.Size = page.Take;
            res.Data = await query.Page(page)
                .Select(action).ToListAsync();
            return res;
        }

        public static IQueryable<T> Page<T>(this IQueryable<T> query, IPageRequest page)
        {
            if (page == null)
                return query;
            query = query.Skip(page.Skip);
            query = query.Take(page.Take);
            return query;
        }
    }
}