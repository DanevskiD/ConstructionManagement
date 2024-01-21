using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance.Entities
{
    public class Movie : BaseEntity
    {
        public Movie(int id, Guid uid, DateTime? deletedOn, string name, int year, string producerName, int categoryFK)
            : base(id, uid, deletedOn)
        {
            Name = name;
            Year = year;
            ProducerName = producerName;
            CategoryFK = categoryFK;
        }
        public string Name { get; set; }
        public int Year { get; set; }
        public string ProducerName { get; set; }
        public int CategoryFK { get; set; }
     }
}
