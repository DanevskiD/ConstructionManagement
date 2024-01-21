using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Requests.Project
{
    public class CreateProjectRequest
    {
        public CreateProjectRequest(string name, string address, int? internalNumber)
        {
            Name = name;
            Address= address;
            InternalNumber = internalNumber;
        }

        public string Name { get; }
        public string Address { get; }
        public int? InternalNumber { get; }
    }
}
