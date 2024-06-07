using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _3TabeleSzpital.Entities.Configs;

public class PatientEfPatient : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(x => x.IdPatient).HasName("IdPatient");
        builder.Property(x => x.IdPatient).UseIdentityColumn();

        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.date).IsRequired();

        Patient[] patients =
        {
            new Patient()
            {
                IdPatient = 1, FirstName = "Monika", LastName = "Suchodolska", date = new DateTime(1990, 12, 12)
            },
            new Patient()
            {
                IdPatient = 2, FirstName = "Krzysztof", LastName = "Nowak", date = new DateTime(1960, 9, 11)
            }
        };

        builder.HasData(patients);
    }
}