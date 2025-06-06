using ProjetoHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoHotel.Controller
{
    public class ReservaController
    {
        private List<Reserva> Reservas;

        public ReservaController()
        {
            Reservas = new List<Reserva>();
        }

        public int BuscarReserva()
        {
            return Reservas.Count + 1;
        }

        public void Checkin(int Id)
        {
            Reservas[Id].DataCheckin = DateTime.Now;
        }

        public void FazerReserva(Reserva reserva)
        {
            Reservas.Add(reserva);
        }
    }
}
