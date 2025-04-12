using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SOH.MAIN.Models.Users;

internal class ConfigAspNetUser : IEntityTypeConfiguration<SR_Users>
{
    public void Configure(EntityTypeBuilder<SR_Users> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(y => y.Person)
            .WithOne(y => y.Users)
            .HasForeignKey<SR_Users>(x => x.idPerson)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(x => x.PhoneNumberConfirmed);
        builder.Ignore(x => x.PhoneNumber);
    }
}
