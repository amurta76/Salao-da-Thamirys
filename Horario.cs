using System;
using System.Collections.Generic;
using System.Text;

namespace Salao
{
    class Horario
    {
        public Pessoa Cliente { get; set; }
        public DateTime DataHora { get; set; }
        public Servico Servico { get; set; }
    }
}
