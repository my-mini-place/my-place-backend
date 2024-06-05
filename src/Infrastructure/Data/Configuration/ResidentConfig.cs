using Domain.Entities;
using Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ResidentConfiguration : IEntityTypeConfiguration<Resident>
    {
        public void Configure(EntityTypeBuilder<Resident> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                  .WithOne()
                  .HasForeignKey<Resident>(x => x.UserId).HasPrincipalKey<User>(x => x.UserId);

            builder.HasOne(x => x.Residence)
                  .WithOne()
                  .HasForeignKey<Resident>(x => x.ResidenceId).HasPrincipalKey<Residence>(x => x.ResidenceId);
        }
    }
}