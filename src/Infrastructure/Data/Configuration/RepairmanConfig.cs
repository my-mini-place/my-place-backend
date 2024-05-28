using Domain.Entities;
using Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class RepairmanConfiguration : IEntityTypeConfiguration<Repairman>
    {
        public void Configure(EntityTypeBuilder<Repairman> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Repairman>(x => x.UserId).HasPrincipalKey<User>(x => x.UserId);
        }
    }
}