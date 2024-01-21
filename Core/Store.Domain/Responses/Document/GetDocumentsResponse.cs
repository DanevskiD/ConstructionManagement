using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Responses.Document
{
    public class GetDocumentsResponse
    {
        public GetDocumentsResponse(Guid uid, string name, string description, int projectFK) 
        {
            Uid = uid;
            Name = name;
            Description = description;
            ProjectFK = projectFK;
        }
        public Guid Uid { get; }
        public string Name { get; }
        public string Description { get; }
        public int ProjectFK { get; }
    }
}
