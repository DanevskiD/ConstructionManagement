using Store.Domain.Requests.Category;
using Store.Domain.Responses.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Interface
{
    public interface ICategoryService
    {
        Task<List<GetCategoriesResponse>> GetCategoriesAsync();

        Task CreateCategoryAsync(CreateCategoryRequest request);
    }
}
