using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _3TabeleSzpital.Entities.Configs;

public class DoctorEfConfig : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(x => x.IdDoctor).HasName("IdDoctor");
        builder.Property(x => x.IdDoctor).UseIdentityColumn();

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);

        builder.ToTable("Doctor");

        Doctor[] doctors =
        {
            new Doctor()
            {
                IdDoctor = 1, FirstName = "Adam", LastName = "Nowak", Email = "AdNo@wp.pl"
            },
            new Doctor()
            {
                IdDoctor = 2, FirstName = "Anna", LastName = "Malinowska", Email = "AnMa@wp.pl"
            }
        };

        builder.HasData(doctors);
    }
}