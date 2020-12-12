using Cerveja.Do.Futuro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cerveja.Do.Futuro.Infra.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Email).IsRequired().HasMaxLength(50);
            builder.Property(q => q.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(q => q.Endereco).IsRequired().HasMaxLength(250);
            builder.Property(q => q.Nome).IsRequired().HasMaxLength(150);
            builder.Property(q => q.Telefone).IsRequired().HasMaxLength(15);
        }
    }
}
