using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Requests.Movie
{
    public class CreateMovieRequest
    {
        public CreateMovieRequest(string name, int year, string producerName, int categoryFK)
        {
            Name = name;
            Year = year;
            ProducerName = producerName;
            CategoryFK = categoryFK;
        }

        public string Name { get; }
        public int Year { get; }
        public string ProducerName { get; }
        public int CategoryFK { get; }
    }
}
