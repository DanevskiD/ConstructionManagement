using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance.Entities
{
    public class PackageDocument : BaseEntity
    {
        public PackageDocument(int id, Guid uid, DateTime? deletedOn, int packageFK, int documentFK)
           : base(id, uid, deletedOn) 
        {
            PackageFK = packageFK;
            DocumentFK = documentFK;
        }
        public int PackageFK { get; set; }
        public int DocumentFK { get; set; }
    }
}
