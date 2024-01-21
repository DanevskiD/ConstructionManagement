using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Persistance.Entities;

namespace Store.Persistance.Configurations
{
    public class MovieConfiguration :BaseConfiguration<Movie>
    {
        public MovieConfiguration(string schema)
           : base(schema)
        {
        }
        public override void Configure(EntityTypeBuilder<Movie> builder)
        {
            base.Configure(builder);

            builder.ToTable("Movie", Schema);

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Uid).HasColumnName(@"UID").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName(@"DeletedOn").HasColumnType("smalldatetime").IsRequired(false);

            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(50)").IsRequired();

            builder.Property(x => x.Year).HasColumnName(@"Year").HasColumnType("int").IsRequired();
            builder.Property(x => x.ProducerName).HasColumnName(@"ProducerName").HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.CategoryFK).HasColumnName(@"CategoryFK").HasColumnType("int").IsRequired();

        }

    }
}
