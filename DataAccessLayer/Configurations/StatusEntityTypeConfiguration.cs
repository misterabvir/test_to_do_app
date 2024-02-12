using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace DataAccessLayer.Configurations
{
    internal class StatusEntityTypeConfiguration : IEntityTypeConfiguration<StatusEntity>
    {
        public void Configure(EntityTypeBuilder<StatusEntity> builder)
        {
            builder.ToTable("States");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Status_ID").ValueGeneratedOnAdd();
            builder.Ignore(s => s.Status);
            builder.Property(x => x.Status)
                .HasConversion(
                    x => x.ToString(),
                    value => Convert(value))
                .IsRequired()
                .HasColumnName("Name");
        }

        private Status Convert(string value)
        {

            return value switch
            {
                "Created" => Status.Created,
                "InProgress" => Status.InProgress,
                _ => Status.Resolved,
            };
        }
    }
}
