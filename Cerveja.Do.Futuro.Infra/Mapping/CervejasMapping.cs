using Cerveja.Do.Futuro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cerveja.Do.Futuro.Infra.Mapping
{
    public class CervejasMapping : IEntityTypeConfiguration<Cervejas>
    {
        public void Configure(EntityTypeBuilder<Cervejas> builder)
        {
            builder.HasKey(q => q.Id);
            builder.HasOne(q => q.Usuario).WithMany().HasForeignKey(q => q.UsuarioId);
            builder.Property(q => q.Nome).IsRequired().HasMaxLength(500);
            builder.Property(q => q.Preco).IsRequired();
            builder.Property(q => q.Validade).IsRequired();
        }
    }
}
