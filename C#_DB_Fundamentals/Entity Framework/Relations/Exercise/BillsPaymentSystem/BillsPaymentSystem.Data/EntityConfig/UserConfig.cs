namespace BillsPaymentSystem.Data.EntityConfig
{
    using BillsPaymentSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.UserId);

            builder
                .Property(p => p.FirstName)
                .HasMaxLength(50);

            builder
                .Property(p => p.LastName)
                .HasMaxLength(50);

            builder
                .Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder
                .Property(p => p.Password)
                .HasMaxLength(25)
                .IsUnicode(false);
        }
    }
}
