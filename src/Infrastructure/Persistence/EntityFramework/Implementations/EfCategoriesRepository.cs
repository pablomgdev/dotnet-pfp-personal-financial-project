using Application.Shared;
using Domain.Categories.Models;
using Domain.Categories.Repositories;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityFramework.Implementations;

public class EfCategoriesRepository(
    PfpTransactionsApiDatabaseContext context,
    TextNormalizer textNormalizer
) : ICategoriesRepository
{
    public async Task<Category> Create(Category category)
    {
        var categoryToCreate = category.MapToInfrastructureModel();
        if (categoryToCreate == null) return category;
        categoryToCreate.CreatedDate ??= DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
        categoryToCreate.UpdatedDate ??= categoryToCreate.CreatedDate;
        await context.Categories.AddAsync(categoryToCreate);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<bool> Exists(Category category)
    {
        var normalizedCategoryName = textNormalizer.Normalize(category.Name);
        return await context.Categories.AnyAsync(c => normalizedCategoryName.Equals(c.Name.ToLower()));
    }
}