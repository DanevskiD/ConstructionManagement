using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Requests.PackageDocument
{
    public class CreatePackageDocumentRequest
    {
        public CreatePackageDocumentRequest(Guid documentUid) 
        { 
            DocumentUid = documentUid;
        }
        public Guid DocumentUid { get; }
    }
}
