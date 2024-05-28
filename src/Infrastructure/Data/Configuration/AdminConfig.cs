using Domain.Entities;
using Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class AdminConfig : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.Property(x=>x.Guid)
            //    .IsRequired();

            builder.HasOne(x => x.User)
                 .WithOne()
                 .HasForeignKey<Administrator>(x => x.UserId).HasPrincipalKey<User>(x => x.UserId);
        }
    }
}