using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance.Entities
{
    public class Project : BaseEntity
    {
        public Project(int id, Guid uid, DateTime? deletedOn, string name, string address, int? internalNumber, int userFK)
           : base(id, uid, deletedOn)
        {
            Name = name;
            Address = address;
            InternalNumber = internalNumber;
            UserFK = userFK;
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? InternalNumber { get; set; }
        public int UserFK { get; set; }
    }
}
