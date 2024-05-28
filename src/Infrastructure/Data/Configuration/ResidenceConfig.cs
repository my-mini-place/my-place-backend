using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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