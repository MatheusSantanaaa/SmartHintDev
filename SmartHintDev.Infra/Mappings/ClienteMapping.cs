using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHintDev.Domain.Models;

namespace SmartHintDev.Infra.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.CpfCnpj)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(c => c.Email)
               .IsRequired()
               .HasColumnType("varchar(150)");

            builder.Property(c => c.Telefone)
               .IsRequired()
               .HasColumnType("varchar(11)");

            builder.Property(c => c.Nome)
               .IsRequired()
               .HasColumnType("varchar(150)");

            builder.Property(c => c.Senha)
               .IsRequired();

        }
    }
}
