using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Do.Futuro.Domain.Entities
{
    public class Usuario : BaseEntities
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Cpf { get; set; }

        public string Endereco { get; set; }
    }
}
