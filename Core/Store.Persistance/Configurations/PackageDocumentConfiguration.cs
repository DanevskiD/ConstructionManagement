using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Persistance.Entities;

namespace Store.Persistance.Configurations
{
    public class PackageDocumentConfiguration : BaseConfiguration<PackageDocument>
    {
        public PackageDocumentConfiguration(string schema)
          : base(schema)
        { }
        public override void Configure(EntityTypeBuilder<PackageDocument> builder)
        {
            base.Configure(builder);

            builder.ToTable("PackageDocuments", Schema);

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Uid).HasColumnName(@"UID").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName(@"DeletedOn").HasColumnType("smalldatetime").IsRequired(false);

            builder.Property(x => x.PackageFK).HasColumnName(@"PackageFK").HasColumnType("int").IsRequired();
            builder.Property(x => x.DocumentFK).HasColumnName(@"DocumentFK").HasColumnType("int").IsRequired();

        }
    }
}
