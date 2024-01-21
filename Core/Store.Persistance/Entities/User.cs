using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance.Entities
{
    public class User : BaseEntity
    {
        public User(int id, Guid uid, DateTime? deletedOn, string name)
            : base(id, uid, deletedOn)
        {
            Name = name;
        }
        public string Name { get; set; }
     
    }
}
