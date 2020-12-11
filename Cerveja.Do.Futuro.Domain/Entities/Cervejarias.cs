using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Do.Futuro.Domain.Entities
{
    public class Cervejarias : BaseEntities
    {
        
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string CertificadoVigilância { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }
    }
}
