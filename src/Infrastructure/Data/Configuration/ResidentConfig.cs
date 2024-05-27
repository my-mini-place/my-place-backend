using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Identity;

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