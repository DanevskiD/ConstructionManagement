using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Requests.Package
{
    public class CreatePackageRequest
    {
        public CreatePackageRequest(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
