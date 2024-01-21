using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Persistance.Entities;

namespace Store.Persistance.Configurations
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        protected BaseConfiguration(string schema)
        {
            Schema = schema;
        }

        protected string Schema { get; }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasQueryFilter(c => c.DeletedOn == null);
        }
    }
}
