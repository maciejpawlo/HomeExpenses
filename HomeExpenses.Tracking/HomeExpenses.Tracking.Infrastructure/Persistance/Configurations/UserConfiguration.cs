using HomeExpenses.Tracking.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Infrastructure.Persistance.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.LastName)
                  .IsRequired()
                  .HasMaxLength(255);

            builder.HasMany(x => x.Expenses)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.Property(x => x.CreatedOn)
                .IsRequired();

            builder.Property(x => x.UpdatedOn)
                .IsRequired(false);
        }
    }
}
