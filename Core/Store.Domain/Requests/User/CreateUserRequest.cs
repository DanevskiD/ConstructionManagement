using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Requests.User
{
    public class CreateUserRequest
    {
        public CreateUserRequest(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
