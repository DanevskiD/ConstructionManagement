using Microsoft.EntityFrameworkCore;
using Store.Domain.Interface;
using Store.Domain.Requests.Movie;
using Store.Domain.Responses.Movie;
using Store.Persistance.Entities;
using Store.Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateMovieAsync(CreateMovieRequest request)
        {
            Movie movie = new Movie(default, Guid.NewGuid(), null, request.Name, request.Year, request.ProducerName, request.CategoryFK);

            _unitOfWork.Movies.Insert(movie);

            await _unitOfWork.SaveAsync();
        }

        public async Task<List<GetMoviesResponse>> GetMoviesAsync()
        {
            return await _unitOfWork.Movies.All().Select(x => new GetMoviesResponse(x.Uid, x.Name, x.Year, x.ProducerName, x.CategoryFK)).ToListAsync();
        }
    }
}
