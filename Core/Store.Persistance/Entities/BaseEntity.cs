
using Store.Persistance.Interfaces;

namespace Store.Persistance.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public BaseEntity(int id, Guid uid, DateTime? deletedOn)
        {
            Id = id;
            Uid = uid;
            DeletedOn = deletedOn;
        }

        public int Id { get; set; }

        public Guid Uid { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
