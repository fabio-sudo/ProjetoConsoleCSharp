using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoHotel.Model
{
    public class Reserva
    {
        public int Id { get; set; }
        public int Quarto { get; set; }
        public string NomeDoHospede { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataCheckin { get; set; }
        public DateTime DataCheckout { get; set; }
    }
}
