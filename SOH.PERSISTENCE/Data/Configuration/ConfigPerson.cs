using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SOH.MAIN.Models.Customer;
using SOH.MAIN.Models.Employee;
using SOH.MAIN.Models.Users;

internal class ConfigPerson : IEntityTypeConfiguration<SR_Person>
{
    public void Configure(EntityTypeBuilder<SR_Person> builder)
    {
        builder.HasKey(x => x.idPerson);

        builder.HasOne(y => y.Employee)
            .WithOne(x => x.Person)
            .HasForeignKey<SR_Employee>(x => x.idPerson)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(y => y.Users)
            .WithOne(x => x.Person)
            .HasForeignKey<SR_Users>(x => x.idPerson)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Gender)
        .WithMany()
        .HasForeignKey(p => p.idGender)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.TypeDocument)
        .WithMany()
        .HasForeignKey(p => p.idTypeDocument)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
