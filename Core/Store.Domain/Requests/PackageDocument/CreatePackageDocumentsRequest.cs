using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Requests.PackageDocument
{
    public class CreatePackageDocumentsRequest
    {
        public CreatePackageDocumentsRequest(List<Guid> documentsUids)
        {
            DocumentsUids = documentsUids;
        }
        public List<Guid> DocumentsUids { get; }
    }
}
