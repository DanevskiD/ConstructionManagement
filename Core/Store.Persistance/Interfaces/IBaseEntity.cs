using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance.Interfaces
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        Guid Uid { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
