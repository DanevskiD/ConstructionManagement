using Store.Domain.Requests.Movie;
using Store.Domain.Responses.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Interface
{
    public interface IMovieService
    {
        Task<List<GetMoviesResponse>> GetMoviesAsync();

        Task CreateMovieAsync(CreateMovieRequest request);
    }
}
