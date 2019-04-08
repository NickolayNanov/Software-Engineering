namespace BillsPaymentSystem.Data.EntityConfig
{
    using BillsPaymentSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class BancAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder
                .HasKey(ba => ba.BankAccountId);

            builder
                .Property(p => p.BankName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder
                .Property(p => p.SWIFT)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
