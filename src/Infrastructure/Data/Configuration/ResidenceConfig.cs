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
    public class ResidenceConfiguration : IEntityTypeConfiguration<Residence>
    {
        public void Configure(EntityTypeBuilder<Residence> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasOne(x => x.Block)
               .WithMany()
               .HasForeignKey(x => x.BlockId).HasPrincipalKey(x => x.BlockId);

        }
    }
}