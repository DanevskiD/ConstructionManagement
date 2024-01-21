using Microsoft.AspNetCore.Mvc;
using Store.Domain.Interface;
using Store.Domain.Requests.Category;
using Store.Domain.Responses.Category;

namespace Store.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCategoriesResponse>>> GetCategoriesAsync() 
        {
            List<GetCategoriesResponse> categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest request)
        {
            await _categoryService.CreateCategoryAsync(request);
            return Ok();
        }
    }
}
