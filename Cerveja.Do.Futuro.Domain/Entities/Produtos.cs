using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Do.Futuro.Domain.Entities
{
    public class Produtos : BaseEntities
    {
        public virtual Cervejarias Cervejarias { get; set; }

        public string Nome { get; set; }

        public DateTime Validade { get; set; }

        public double Preco { get; set; }

        public Guid CervejariasId { get; set; }
        public string DescricaoProduto { get; set; }

        public Produtos()
        {
        }
    }
}
