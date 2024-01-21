using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Responses.PackageDocument
{
    public class GetPackageDocumentsResponse
    {
        public GetPackageDocumentsResponse(Guid uid, int packageFK, int documentFK) 
        {
            Uid = uid;
            PackageFK = packageFK;
            DocumentFK = documentFK;
        }
        public Guid Uid { get; }
        public int PackageFK { get; }
        public int DocumentFK { get; }
    }
}
