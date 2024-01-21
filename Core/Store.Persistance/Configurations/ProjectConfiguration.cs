using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Persistance.Entities;

namespace Store.Persistance.Configurations
{
    public class ProjectConfiguration : BaseConfiguration<Project>
    {
        public ProjectConfiguration(string schema) 
            : base(schema)
        { }
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);

            builder.ToTable("Project", Schema);

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Uid).HasColumnName(@"UID").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName(@"DeletedOn").HasColumnType("smalldatetime").IsRequired(false);

            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.InternalNumber).HasColumnName(@"InternalNumber").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.UserFK).HasColumnName(@"UserFK").HasColumnType("int").IsRequired();

        }
    }
}
