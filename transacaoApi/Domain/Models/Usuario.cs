using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Usuario
    {
        public Usuario(string idUsuario, double saldo)
        {
            IdUsuario = idUsuario;
            Saldo = saldo;
        }

        public string IdUsuario { get; set; }
        public double Saldo { get; set; }
    }
}
