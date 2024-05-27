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