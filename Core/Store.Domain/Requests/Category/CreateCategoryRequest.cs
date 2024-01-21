using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Requests.Category
{
    public class CreateCategoryRequest
    {
        public CreateCategoryRequest(string name)
        {
            Name = name;
        }
    
        public string Name { get; }
    }
}
