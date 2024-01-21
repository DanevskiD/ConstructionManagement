using Microsoft.EntityFrameworkCore;
using Store.Domain.Interface;
using Store.Domain.Requests.Category;
using Store.Domain.Responses.Category;
using Store.Persistance.Entities;
using Store.Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCategoryAsync(CreateCategoryRequest request)
        {
            Category category = new Category(default, Guid.NewGuid(), null, request.Name);

            _unitOfWork.Categories.Insert(category);

            await _unitOfWork.SaveAsync();
        }

        public async Task<List<GetCategoriesResponse>> GetCategoriesAsync()
        {
            return await _unitOfWork.Categories.All().Select(x => new GetCategoriesResponse(x.Uid, x.Name)).ToListAsync();
        }
    }
}
