using ProjetoGit.BancoLocal;
using ProjetoGit.Model;
using ProjetoGit.Views;

namespace ProjetoGit.Controller
{
    public class ControllerHotel
    {
        private readonly ViewHotel viewHotel;
        public List<Reserva>?ListaReservas { get; private set; }
        
        public ControllerHotel()
        {
            viewHotel = new ViewHotel();
        }

        public void MenuHotel()
        {
            short opcao = 0;
            viewHotel.Iniciar();

            CarregarReservas();

            while (true)
            {
                opcao = viewHotel.GetOpcao();
                if (opcao == 0)
                    break;

                switch (opcao)
                {
                    case 1:
                        EfetuarReserva();
                        break;
                    case 2:
                        CancelarReserva();
                        break;
                    case 3:
                        EfetuarCheckin();
                        break;
                    case 4:
                        EfetuarCheckout();
                        break;
                    case 5:
                        viewHotel.ExibirListaReserva(ListaReservas);
                        break;
                    default:
                        break;
                }
            }
        }

        private void CarregarReservas()
        {
            try
            {
                ListaReservas = ReservaDAO.CarregarReservas();
                if (ListaReservas == null || ListaReservas.Count == 0)
                    return;

                ReservaDAO.ListaQuartos.ForEach(quarto =>
                {
                    var reserva = ListaReservas
                    .Where(r => r.Quarto == quarto.Id && r.DataCheckin == null)
                    .OrderBy(r => r.DataCheckin ?? DateTime.MaxValue)
                    .FirstOrDefault();

                    if (reserva == null)
                        quarto.Status = 0;
                    else if (reserva.DataCheckin == null)
                        quarto.Status = 1;
                    else
                        quarto.Status = 2;
                });
            }
            catch (Exception ex)
            {
                if (ex.Message.Length > 39)
                    viewHotel.ExibirMensagem(ex.Message[..39]);
                else
                    viewHotel.ExibirMensagem(ex.Message);
            }
        }

        public void EfetuarReserva()
        {
            if (ReservaDAO.ListaQuartos == null || ReservaDAO.ListaQuartos.Count == 0)
            {
                viewHotel.ExibirMensagem("Não temos quartos disponíveis!");
                return;
            }
            
            Reserva reserva = new();

            reserva.NomeDoHospede = viewHotel.GetNomeHospede();
            if (viewHotel.fl_cancelar)
                return;

            reserva.Telefone = viewHotel.GetTelefone();
            if (viewHotel.fl_cancelar)
                return;
            
            reserva.Email = viewHotel.GetEmail();
            if (viewHotel.fl_cancelar)
                return;

            while (true)
            {
                reserva.Quarto = viewHotel.GetQuarto();
                if (viewHotel.fl_cancelar)
                    return;
                if (reserva.Quarto == 0)
                    return;
                var quartoSelecionado = ReservaDAO.ListaQuartos.Find(q => q.Id == reserva.Quarto);
                if (quartoSelecionado?.Status != 0)
                {
                    viewHotel.ExibirMensagem($"Quarto já está {(quartoSelecionado?.Status == 1 ? "Reservado" : "Ocupado")}");
                    continue;
                }
                break;
            }

            var confirmar = viewHotel.ConfirmaDados("Confirma a reserva (S/N) ?");
            if (!confirmar)
                return;

            reserva.Id = ReservaDAO.GetProximaReserva(ListaReservas);

            if (ListaReservas == null)
                ListaReservas = [];

            ListaReservas.Add(reserva);

            try
            {
                ReservaDAO.SalvarReservas(ListaReservas);
                ReservaDAO.AlteraStatusQuarto(reserva.Quarto, 1);
                viewHotel.ExibirMensagem($"Reserva Nº {reserva.Id} efetuada!");
            }
            catch (Exception ex)
            {
                viewHotel.ExibirMensagem(ex.Message);
            }
        }

        public void CancelarReserva()
        {
            int IdReserva = viewHotel.GetReserva();
            if (IdReserva == 0)
            {
                return;
            }
            Reserva? reserva = ListaReservas.FirstOrDefault(r=> r.Id == IdReserva);
            if (reserva == null)
            {
                viewHotel.ExibirMensagem($"Reserva Nº {reserva.Id} NÃO encontrada!");
                return;
            }
            viewHotel.ExibirDadosReserva( reserva );
            bool Confirma = viewHotel.ConfirmaDados("Confirmar concelamento (s/n)");
            if (!Confirma)
            {
                return;
            }
            ListaReservas.Remove( reserva );
            ReservaDAO.SalvarReservas(ListaReservas);
            ReservaDAO.AlteraStatusQuarto(reserva.Quarto,(short)0);
            viewHotel.ExibirMensagem($"Reserva Nº {reserva.Id} CANCELADA!");
        }

        public void EfetuarCheckin()
        {
            int IdReserva = viewHotel.GetReserva();
            if (IdReserva == 0)
            {
                return;
            }
            Reserva? reserva = ListaReservas.FirstOrDefault(r => r.Id == IdReserva);
            if (reserva == null)
            {
                viewHotel.ExibirMensagem($"Reserva Nº {reserva.Id} NÃO encontrada!");
                return;
            }
            reserva.DataCheckin = DateTime.Now;
            viewHotel.ExibirDadosReserva(reserva);
            bool Confirma = viewHotel.ConfirmaDados("Confirmar checkin (s/n)");
            if (!Confirma)
            {
                return;
            }
            
            ListaReservas.Remove(reserva);
            ListaReservas.Add(reserva);

            ReservaDAO.SalvarReservas(ListaReservas);
            ReservaDAO.AlteraStatusQuarto(reserva.Quarto, (short)2);
            viewHotel.ExibirMensagem($"Checkin realizado!");
        }

        public void EfetuarCheckout()
        {
            int IdReserva = viewHotel.GetReserva();
            if (IdReserva == 0)
            {
                return;
            }
            Reserva? reserva = ListaReservas.FirstOrDefault(r => r.Id == IdReserva);
            if (reserva == null)
            {
                viewHotel.ExibirMensagem($"Reserva Nº {reserva.Id} NÃO encontrada!");
                return;
            }
            reserva.DataCheckout = DateTime.Now;
            viewHotel.ExibirDadosReserva(reserva);
            bool Confirma = viewHotel.ConfirmaDados("Confirmar checkout (s/n)");
            if (!Confirma)
            {
                return;
            }

            ListaReservas.Remove(reserva);
            ListaReservas.Add(reserva);

            ReservaDAO.SalvarReservas(ListaReservas);
            ReservaDAO.AlteraStatusQuarto(reserva.Quarto, (short)0);
            viewHotel.ExibirMensagem($"Checkout realizado!");
        }
    }
}
