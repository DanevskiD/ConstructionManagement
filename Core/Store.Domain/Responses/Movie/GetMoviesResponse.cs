using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Responses.Movie
{
    public class GetMoviesResponse
    {
        public GetMoviesResponse(Guid uid, string name, int year, string producerName, int categoryFK)
        {
            Uid = uid;
            Name = name;
            Year = year;
            ProducerName = producerName;
            CategoryFK = categoryFK;
        }

        public Guid Uid { get; }

        public string Name { get; }
        public int Year { get; }
        public string ProducerName { get; }
        public int CategoryFK { get; }
    }
}
