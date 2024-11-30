using Api.Controllers.Base;
using Api.Mappers;
using Application.Categories;
using Asp.Versioning;
using Contracts.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1;

[ApiVersion("1.0")]
public class CategoriesController(
    CategoriesCreator categoriesCreator
) : JsonApiControllerBase
{
    /// <summary>
    ///     Creates a new category.
    /// </summary>
    /// <param name="request">Category data.</param>
    /// <returns>Returns the category already created.</returns>
    /// <response code="201">Category created successfully.</response>
    /// <response code="409">Category already exists.</response>
    /// <response code="500">Internal server error.</response>
    [MapToApiVersion("1.0")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CreateCategoryResponse>> Create([FromBody] CreateCategoryRequest request)
    {
        // TODO: handle corresponding errors. Waiting to get the middl
        var categoryCreated = await categoriesCreator.Invoke(request.FundId, request.Name);
        var responseData = categoryCreated.MapToDto();
        return CreatedAtAction(nameof(Create), new { fundId = categoryCreated.Id }, responseData);
    }
}