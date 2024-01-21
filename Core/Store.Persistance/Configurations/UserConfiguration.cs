using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Persistance.Entities;

namespace Store.Persistance.Configurations
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public UserConfiguration(string schema)
          : base(schema)
        {
        }
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("User", Schema);

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Uid).HasColumnName(@"UID").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName(@"DeletedOn").HasColumnType("smalldatetime").IsRequired(false);

            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}
