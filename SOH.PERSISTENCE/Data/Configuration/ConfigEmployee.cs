using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SOH.MAIN.Models.Employee;

internal class ConfigEmployee : IEntityTypeConfiguration<SR_Employee>
{
    public void Configure(EntityTypeBuilder<SR_Employee> builder)
    {
        builder.HasKey(x => x.idEmployee);

        builder.HasOne(x => x.Person)
            .WithOne(x => x.Employee)
            .HasForeignKey<SR_Employee>(x => x.idPerson)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
