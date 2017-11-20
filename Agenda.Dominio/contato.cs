using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agenda.dominio
{
    public class contato
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public TipoContato TipoContato { get; set; }
    }
}