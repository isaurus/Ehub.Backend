using eHub.Backend.Domain.Entities;
using eHub.Backend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace eHub.Backend.Infrastructure.Context.Mappings
{
    public class UserMapper : IEntityTypeConfiguration<User>, IEntityMapping<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Conversor de DateOnly <-> DateTime
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d)
            );

            // Modificación de queries para borrado lógico
            builder.HasQueryFilter(a => a.IsEnabled);

            // Conversor para el enum Country
            var countryConverter = new ValueConverter<Country, string>(
                c => c.ToString(),
                s => Enum.Parse<Country>(s)
            );

            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(u => u.ProfilePicUrl)
                .HasMaxLength(500);

            builder.Property(u => u.FirstName)
               .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .HasMaxLength(50);

            builder.Property(u => u.BirthDate)
                .HasConversion(dateOnlyConverter);

            builder.Property(u => u.Country)
                .HasConversion(countryConverter)
                .HasMaxLength(100);

            // Configuración de propiedades heredadas
            builder.Property(u => u.IsEnabled)
                .HasDefaultValue(true);

            builder.Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

        }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
