using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaWeb.Models
{
    public class ModelPaciente
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
    }
}