using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Responses.Category
{
    public class GetCategoriesResponse
    {
        public GetCategoriesResponse(Guid uid, string name)
        {
            Uid = uid;
            Name = name;
        }
    
        public Guid Uid { get; }

        public string Name { get; }
    }
}
