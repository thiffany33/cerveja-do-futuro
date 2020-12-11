using Cerveja.Do.Futuro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cerveja.Do.Futuro.Infra.Mapping
{
    public class PrudutosMapping : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.HasKey(q => q.Id);
            builder.HasOne(q => q.Cervejarias).WithMany().HasForeignKey(q => q.CervejariasId);
            builder.Property(q => q.Nome).IsRequired().HasMaxLength(500);
            builder.Property(q => q.Preco).IsRequired();
            builder.Property(q => q.Validade).IsRequired();
        }
    }
}
