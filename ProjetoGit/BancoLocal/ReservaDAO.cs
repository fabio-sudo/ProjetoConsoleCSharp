using ProjetoGit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjetoGit.BancoLocal
{
    public static class ReservaDAO
    {
        public static int IdUltimaReserva { get; private set; }
        public static List<Quarto> ListaQuartos = [];

        public static void CriarListaQuartos(int qtdQuartos)
        {
            ListaQuartos = [];

            for (int i = 0; i < qtdQuartos; i++)
            {
                ListaQuartos.Add(new Quarto(i + 1, 0));
            }

        }

        public static int GetProximaReserva(List<Reserva>? ListaReservas)
        {
            if (ListaReservas == null || ListaReservas.Count == 0)
                IdUltimaReserva = 1;
            else
                IdUltimaReserva = ListaReservas.Max(r => r.Id + 1);
            return IdUltimaReserva;
        }

        public static List<Reserva>? CarregarReservas()
        {
            try
            {
                var nomeArquivo = GetNomeArquivo();
                var pathArquivo = Path.GetDirectoryName(nomeArquivo);
                if (!Directory.Exists(pathArquivo))
                    Directory.CreateDirectory(pathArquivo);

                if (!File.Exists(GetNomeArquivo()))
                    return null;

                string jsonLido = File.ReadAllText(GetNomeArquivo());
                List<Reserva>? listaReservas = JsonSerializer.Deserialize<List<Reserva>>(jsonLido);
                return listaReservas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool SalvarReservas(List<Reserva> ListaReservas)
        {
            try
            {
                string jsonReservas = JsonSerializer.Serialize(ListaReservas, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(GetNomeArquivo(), jsonReservas);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AlteraStatusQuarto(int id, short status)
        {
            ListaQuartos[id - 1].Status = status;
        }

        private static string GetNomeArquivo()
        {
            return $@"{AppDomain.CurrentDomain.BaseDirectory}\BancoLocal\reservas.json";
        }
    }
}
