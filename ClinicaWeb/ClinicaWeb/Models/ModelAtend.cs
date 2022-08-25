using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaWeb.Models
{
    public class ModelAtend
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public string IdPaciente { get; set; }
        public string IdMedico { get; set; }
        public string Diagnostico { get; set; }
    }
}