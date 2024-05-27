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
