using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance.Entities
{
    public class Package : BaseEntity
    {
        public Package(int id, Guid uid, DateTime? deletedOn, string name, int projectFK)
            : base(id, uid, deletedOn)
        {
            Name = name;
            ProjectFK = projectFK;

        }
        public string Name { get; set; }
        public int ProjectFK { get; set; }
    }
}
