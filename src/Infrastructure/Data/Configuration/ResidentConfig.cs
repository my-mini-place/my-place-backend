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
            // komentarze od chata principal -> do 'zmiany' klucza targetu 
            builder.HasOne(x => x.User)          // Resident ma jeden User
          .WithOne()                    // User ma jeden Resident
          .HasForeignKey<Resident>(x => x.UserId)  // ForeignKey w Resident
          .HasPrincipalKey<User>(x => x.UserId);   // Klucz główny w User

            //// Konfiguracja dla Residence - Resident
            //builder.HasOne(x => x.Residence)     // Resident ma jedno Residence
            //       .WithOne().HasForeignKey<Resident>(x => x.ResidenceId).HasPrincipalKey<Residence>(x => x.ResidenceId);


            builder.HasOne(x => x.Residence)
       .WithMany() 
       .HasForeignKey(x => x.ResidenceId).HasPrincipalKey(x => x.ResidenceId); 
        }
    }
}