using Mapster;
using Microsoft.EntityFrameworkCore;
using ThreeTee.Application.Models;

namespace ThreeTee.Application.Mappings;

public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);

    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, TypeAdapterConfig configuration) where TDestination : class
        => queryable.ProjectToType<TDestination>(configuration).AsNoTracking().ToListAsync();
}