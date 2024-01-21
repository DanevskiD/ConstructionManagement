using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Persistance.Entities;

namespace Store.Persistance.Configurations
{
    public class DocumentConfiguration : BaseConfiguration<Document>
    {
        public DocumentConfiguration(string schema)
           : base(schema)
        { }
        public override void Configure(EntityTypeBuilder<Document> builder)
        {
            base.Configure(builder);

            builder.ToTable("Document", Schema);

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Uid).HasColumnName(@"UID").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName(@"DeletedOn").HasColumnType("smalldatetime").IsRequired(false);

            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.ProjectFK).HasColumnName(@"ProjectFK").HasColumnType("int").IsRequired();

        }
    }
}
