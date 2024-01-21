using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance.Entities
{
    public class Document : BaseEntity
    {
        public Document(int id, Guid uid, DateTime? deletedOn, string name, string description, int projectFK)
           : base(id, uid, deletedOn)
        {
            Name = name;
            Description = description;
            ProjectFK = projectFK;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectFK { get; set; }
    }
}
