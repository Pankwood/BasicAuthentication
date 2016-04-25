using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAuth.Models
{
    public class Filial
    {
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
    }

    public class ListaFilial
    {
        public List<Filial> Filial { get; set; }
    }
}