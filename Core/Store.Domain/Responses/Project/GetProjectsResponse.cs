using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Responses.Project
{
    public class GetProjectsResponse
    {
        public GetProjectsResponse(Guid uid, string name, string address, int? internalNumber, int userFK)
        {
            Uid = uid;
            Name = name;
            Address = address;
            InternalNumber = internalNumber;
            UserFK = userFK;
        }

        public Guid Uid { get; }

        public string Name { get; }
        public string Address { get; }
        public int? InternalNumber { get; }
        public int UserFK { get; }
    }
}
