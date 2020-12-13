using System;

namespace Cerveja.Do.Futuro.Domain.Entities
{
    public class Cervejas : BaseEntities
    {
        public virtual Usuario Usuario { get; set; }

        public string Nome { get; set; }

        public double Preco { get; set; }

        public DateTime Validade { get; set; }

        public Guid UsuarioId { get; set; }
    }
}
