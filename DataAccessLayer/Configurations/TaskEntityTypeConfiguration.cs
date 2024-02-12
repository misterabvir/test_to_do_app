using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    internal class TaskEntityTypeConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasColumnName("Name");
            builder.Property(x => x.Description).IsRequired().HasColumnName("Description");
            builder.Property(x => x.StatusId).IsRequired().HasColumnName("Status_ID");

            builder.HasOne(x=>x.StatusEntity).WithMany().HasForeignKey(x=>x.StatusId).HasConstraintName("CK_ProblemStateKey");
        }
    }
}
