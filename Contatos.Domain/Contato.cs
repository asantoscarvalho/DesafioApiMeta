using System;
using System.Collections.Generic;

namespace Contatos.Domain
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Canal { get; set; }
        public string Valor { get; set; }
        public string Observacao { get; set; }

    }
}

