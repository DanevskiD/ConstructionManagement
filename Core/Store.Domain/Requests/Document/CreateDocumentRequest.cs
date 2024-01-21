using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Requests.Document
{
    public class CreateDocumentRequest
    {
        public CreateDocumentRequest(string name, string description) 
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
    }
}
