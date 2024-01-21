using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Responses.Package
{
    public class GetPackagesResponse
    {
        public GetPackagesResponse(Guid uid, string name, int packageFK)
        {
            Uid = uid;
            Name = name;
            PackageFK = packageFK;
        }

        public Guid Uid { get; }

        public string Name { get; }
        public int PackageFK { get; }
    }
}
