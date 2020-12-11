using Cerveja.Do.Futuro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cerveja.Do.Futuro.Infra.Mapping
{
    public class CervejariasMapping : IEntityTypeConfiguration<Cervejarias>
    {
        public void Configure(EntityTypeBuilder<Cervejarias> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Cnpj).IsRequired().HasMaxLength(14);
            builder.Property(q => q.NomeFantasia).IsRequired().HasMaxLength(500);
            builder.Property(q => q.CertificadoVigilância).IsRequired().HasMaxLength(30);
            builder.Property(q => q.Email).IsRequired().HasMaxLength(100);
            builder.Property(q => q.Endereco).IsRequired().HasMaxLength(200);
            builder.Property(q => q.Telefone).IsRequired().HasMaxLength(15);
            builder.Property(q => q.RazaoSocial).IsRequired().HasMaxLength(200);
        }
    }
}
