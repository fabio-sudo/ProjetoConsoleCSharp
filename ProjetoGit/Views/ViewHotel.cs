using ProjetoGit.BancoLocal;
using ProjetoGit.Model;

namespace ProjetoGit.Views
{
    public class ViewHotel
    {
        public bool fl_cancelar = false;
        private const int linOpcao = 13;
        private const int colOpcao = 9;

        private record ElementoTela(int Coluna, int Linha, string Value);
        private record CorConsole(ConsoleColor Fundo, ConsoleColor Fonte);

        private static readonly List<ElementoTela> TelaPrincipal =
        [
            new (00, 00, "╔═════════════════════════════════════════╗"),
            new (00, 01, "║              SENAI'S HOTEL              ║"),
            new (00, 02, "╠═════════════════════════════════════════╣"),
            new (00, 03, "║                                         ║"),
            new (00, 04, "║                                         ║"),
            new (00, 05, "║                                         ║"),
            new (00, 06, "║                                         ║"),
            new (00, 07, "║                                         ║"),
            new (00, 08, "║                                         ║"),
            new (00, 09, "║                                         ║"),
            new (00, 10, "║                                         ║"),
            new (00, 11, "║                                         ║"),
            new (00, 12, "╠═════════════════════════════════════════╣"),
            new (00, 13, "║                                         ║"),
            new (00, 14, "╚═════════════════════════════════════════╝")
        ];

        private static readonly List<ElementoTela> MenuHotel =
        [
            new(02, 04, "1 - Reservas"),
            new(02, 05, "2 - Cancelamento"),
            new(02, 06, "3 - Checkin"),
            new(02, 07, "4 - Checkout"),
            new(02, 08, "5 - Listar"),
            new(02, 11, "0 - Retornar"),
                           
        ];

        private static readonly List<ElementoTela> TelaReserva = 
        [
            new(02, 04, "Nome"),
            new(02, 06, "Telefone"),
            new(02, 08, "eMail"),
            new(02, 10, "Quarto"),
            new(02, 13, "Confirma Reserva (S/N) ? [ ]"),
        ];

        private static readonly List<ElementoTela> TelaDadosReserva =
        [
            new(2, 4, "Reserva No: "),
            new(2, 6, "Quarto ...: "),
            new(2, 7, "Hospede ..: "),
            new(2, 8, "Telefone .: "),
            new(2, 9, "Email ....: ")
        ];

        private static readonly List<ElementoTela> TelaCheckin = 
        [
            new(2, 10, "Check-in .: ")
        ];

        private static readonly List<ElementoTela> TelaCheckout =
        [
            new(2, 10, "Check-out : ")
        ];

        private static readonly List<ElementoTela> TelaLista = 
        [
            new(0, 00, "╔═══════════════════════════════════════════════════════════════════════════════════════════════════╗"),
            new(0, 01, "║                                 RELAÇÃO DAS RESERVAS CADASTRADAS                                  ║"),
            new(0, 02, "╠═════════╦════════╦════════════════════════════════════╦═════════════════╦════════════╦════════════╣"),
            new(0, 03, "║ Reserva ║ Quarto ║ Hospede                            ║ Telefone        ║  Check-in  ║ Check-out  ║"),
            new(0, 04, "╠═════════╩════════╩════════════════════════════════════╩═════════════════╩════════════╩════════════╣"),
            new(0, 05, "║                                                                                                   ║"),
            new(0, 06, "║                                                                                                   ║"),
            new(0, 07, "║                                                                                                   ║"),
            new(0, 08, "║                                                                                                   ║"),
            new(0, 09, "║                                                                                                   ║"),
            new(0, 10, "║                                                                                                   ║"),
            new(0, 11, "║                                                                                                   ║"),
            new(0, 12, "║                                                                                                   ║"),
            new(0, 13, "║                                                                                                   ║"),
            new(0, 14, "║                                                                                                   ║"),
            new(0, 15, "║                                                                                                   ║"),
            new(0, 16, "║                                                                                                   ║"),
            new(0, 17, "║                                                                                                   ║"),
            new(0, 18, "║                                                                                                   ║"),
            new(0, 19, "║                                                                                                   ║"),
            new(0, 20, "╠═══════════════════════════════════════════════════════════════════════════════════════════════════╣"),
            new(0, 21, "║                                                                                                   ║"),
            new(0, 22, "╚═══════════════════════════════════════════════════════════════════════════════════════════════════╝")
        ];

        public void Iniciar()
        {
            Console.Clear();
            DesenhaTela(TelaPrincipal, false);
            if (ReservaDAO.ListaQuartos == null || ReservaDAO.ListaQuartos.Count == 0)
                CriarListaQuartos();
        }

        public short GetOpcao()
        {
            DesenhaTela(MenuHotel);

            short opcao = 0;

            while (true) 
            {
                try
                {
                    ShowOpcao();
                    Console.SetCursorPosition(colOpcao, linOpcao);
                    opcao = Convert.ToInt16(Console.ReadLine());
                    if (opcao < 0 || opcao > 5)
                    {
                        ExibirMensagem("Opção inválida! Tente novamente!");
                        ShowOpcao();
                        continue;
                    }
                    break;
                }
                catch 
                {
                    ExibirMensagem("Opção inválida! Tente novamente!");
                    Console.SetCursorPosition(colOpcao, linOpcao);
                    ShowOpcao();
                }
            }

            switch (opcao)
            {
                case 1:
                    DesenhaTela(TelaReserva);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }

            return opcao;
        }

        public string GetNomeHospede()
        {
            string? nome;

            while (true)
            {
                ExibirOrientacao("Digite o nome ou SAIR para encerrar");
                Console.SetCursorPosition(2, 5);
                nome = Console.ReadLine();
                if (string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nome))
                {
                    ExibirMensagem("Nome não pode ficar em branco!");
                    continue;
                }
                if (nome.ToLower().Equals("sair"))
                    fl_cancelar = true;
                break;
            }

            return nome;
        }

        public string GetTelefone()
        {
            string? telefone;
            while (true)
            {
                ExibirOrientacao("Digite o telefone ou SAIR para encerrar");
                Console.SetCursorPosition(2, 7);
                telefone = Console.ReadLine();
                if (string.IsNullOrEmpty(telefone) || string.IsNullOrWhiteSpace(telefone))
                {
                    ExibirMensagem("Telefone não pode ficar em branco!");
                    continue;
                }

                if (telefone.ToLower().Equals("sair"))
                    fl_cancelar = true;
                break;
            }

            return telefone;
        }

        public string GetEmail()
        {
            string? email;

            while (true)
            {
                ExibirOrientacao("Digite o email ou SAIR para encerrar");
                Console.SetCursorPosition(2, 9);
                email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email))
                {
                    if (email.ToLower().Equals("sair"))
                        fl_cancelar = true;
                }
                else
                    email = "";
                break;
            }

            return email;
        }

        public int GetQuarto()
        {
            int quarto = 0;

            while (true)
            {
                try
                {
                    ExibirOrientacao("informe o Nº do quarto ou 0 p/ encerrar");
                    Console.SetCursorPosition(2, 11);
                    quarto = Convert.ToInt32(Console.ReadLine());
                    if (quarto == 0)
                        fl_cancelar = true;
                    break;
                }
                catch 
                {
                    ExibirMensagem("Número do quarto inválido!");
                }
            }

            return quarto;
        }
        
        public bool ConfirmaDados(string mensagem)
        {
            bool confirmar;

            while (true)
            {
                ExibirOrientacao(mensagem);
                Console.SetCursorPosition(2 + mensagem.Length + 1, linOpcao);
                var sim = Console.ReadLine();
                if (string.IsNullOrEmpty(sim) || 
                   (!sim.Equals("S", StringComparison.CurrentCultureIgnoreCase) && 
                   !sim.Equals("N", StringComparison.CurrentCultureIgnoreCase)))
                {
                    ExibirMensagem("Opção inválida!");
                    continue;
                }
                confirmar = sim.ToUpper() == "S";
                break;
            }

            return confirmar;
        }

        public int GetReserva()
        {
            int idReserva = 0;
            while (true)
            {
                try
                {
                    ExibirOrientacao("No da Reserva ou 0 p/ encerrar");
                    idReserva = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    ExibirMensagem("Reserva inválida!");
                }
            }
            return idReserva;
        }

        public void ExibirDadosReserva(Reserva reserva)
        {
            Console.SetCursorPosition(14, 6);
            Console.Write(reserva.Quarto);
            Console.SetCursorPosition(15, 7);
            if (reserva.NomeDoHospede.Length > 27)
                Console.Write(reserva.NomeDoHospede[..27]);
            else
                Console.Write(reserva.NomeDoHospede);

            if (reserva.Telefone.Length > 27)
                Console.Write(reserva.Telefone[..27]);
            else
                Console.Write(reserva.Telefone);
            if (reserva.Email.Length > 27)
                Console.Write(reserva.Email[..27]);
            else
                Console.Write(reserva.Email);

        }

        public void ExibirListaReserva(List<Reserva> reservas)
        {
            Console.Clear();
            DesenhaTela(TelaLista);
            var linha = 4;
            var contador = 0;
            CorConsole corSim = new CorConsole(ConsoleColor.Gray, ConsoleColor.Black);
            CorConsole corNao = new CorConsole(ConsoleColor.Cyan, ConsoleColor.Black);

            string linhaImpressao = string.Empty;

            foreach (Reserva reserva in reservas)
            {
                linha++;
                if ((linha % 2) == 0)
                {
                    Console.BackgroundColor = corSim.Fundo;
                    Console.ForegroundColor = corSim.Fonte;
                }
                else
                {
                    Console.BackgroundColor = corNao.Fundo;
                    Console.ForegroundColor = corNao.Fonte;
                }
                Console.SetCursorPosition(1, linha);
                linhaImpressao = " " + reserva.Id.ToString().PadLeft(7, ' ') + "   " + reserva.Quarto.ToString().PadLeft(6, ' ') + "   ";
                if (reserva.NomeDoHospede.Length > 34)
                    linhaImpressao += reserva.NomeDoHospede[..34] + "   ";
                else
                    linhaImpressao += reserva.NomeDoHospede.PadRight(37, ' ');
                if (reserva.Telefone.Length > 15)
                    linhaImpressao += reserva.Telefone[..15] + "   ";
                else
                    linhaImpressao += reserva.Telefone.PadRight(18, ' ');
                if (reserva.DataCheckin.HasValue)
                    linhaImpressao += reserva.DataCheckin.Value.ToShortDateString() + "   ";
                else
                    linhaImpressao += "             ";
                if (reserva.DataCheckout.HasValue)
                    linhaImpressao += reserva.DataCheckout.Value.ToShortDateString() + "   ";
                else
                    linhaImpressao += "           ";
                Console.Write(linhaImpressao);

                //Console.SetCursorPosition(2, linha);
                //Console.Write(reserva.Id.ToString().PadLeft(7, ' '));
                //Console.SetCursorPosition(12, linha);
                //Console.Write(reserva.Quarto.ToString().PadLeft(6, ' '));
                //Console.SetCursorPosition(21, linha);
                //if (reserva.NomeDoHospede.Length > 34)
                //    Console.Write(reserva.NomeDoHospede[..34]);
                //else
                //    Console.Write(reserva.NomeDoHospede);
                //Console.SetCursorPosition(58, linha);
                //if (reserva.Telefone.Length > 15)
                //    Console.Write(reserva.Telefone[..15]);
                //else
                //    Console.Write(reserva.Telefone);
                //Console.SetCursorPosition(76, linha);
                //if (reserva.DataCheckin.HasValue)
                //    Console.Write(reserva.DataCheckin.Value.ToShortDateString());
                //Console.SetCursorPosition(89, linha);
                //if (reserva.DataCheckout.HasValue)
                //    Console.Write(reserva.DataCheckout.Value.ToShortDateString());

                contador++;
                if (linha == 19)
                {
                    Console.ResetColor();
                    Console.SetCursorPosition(2, 21);
                    if (contador == reservas.Count)
                    {
                        Console.Write("Pressione qualquer tecla para retornar");
                        Console.ReadKey();
                    }
                    else
                    {
                        while (true)
                        {
                            Console.Write("Pressione C para continuar ou R para retornar: ");
                            var continuar = Console.ReadLine();
                            if (continuar == null || (continuar.Equals("C", StringComparison.CurrentCultureIgnoreCase)) &&
                                continuar.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                            {
                                LimparLinha(99, 21);
                                Console.SetCursorPosition(2, 21);
                                Console.Write("Opção inválida!");
                                Console.ReadKey();
                                continue;
                            }
                            break;
                        }
                    }
                }
            }
            Console.ResetColor();
            Console.SetCursorPosition(2, 21);
            Console.Write("Pressione qualquer tecla para retornar");
            Console.ReadKey();
            Console.Clear();
            DesenhaTela(TelaPrincipal);
        }

        private void DesenhaTela(List<ElementoTela> Tela, bool LimparCentro=true)
        {
            if (LimparCentro)
                LimparCentroTela();

            foreach (ElementoTela item in Tela)
            {
                Console.SetCursorPosition(item.Coluna, item.Linha);
                Console.Write(item.Value);
            }
        }

        private void LimparCentroTela()
        {
            for (int i = 3; i < 12; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(new string(' ', 41));
            }
        }

        private void LimparLinha(int size=41, int lin=linOpcao)
        {
            Console.SetCursorPosition(01, lin);
            Console.Write(new string(' ', size));

        }

        private void ShowOpcao()
        {
            LimparLinha();
            Console.SetCursorPosition(2, linOpcao);
            Console.Write("Opção: ");
        }
        
        private void CriarListaQuartos()
        {
            while (true)
            {
                try
                {
                    LimparLinha();
                    Console.SetCursorPosition(2, linOpcao);
                    Console.Write("No. de Quartos Disponíveis: ");
                    var qtdQuartos = Convert.ToInt32(Console.ReadLine());
                    if (qtdQuartos <= 0)
                    {
                        ExibirMensagem("Número inválido!");
                        continue;
                    }
                    ReservaDAO.CriarListaQuartos(qtdQuartos);
                    break;
                }
                catch (Exception)
                {
                    ExibirMensagem("Número inválido!");
                }
            }
        }
        
        public void ExibirMensagem(string mensagem)
        {
            LimparLinha();
            Console.SetCursorPosition(2, linOpcao);
            Console.Write(mensagem);
            Console.ReadKey();
            LimparLinha();
        }

        private void ExibirOrientacao(string orientacao)
        {
            LimparLinha();
            Console.SetCursorPosition(2, linOpcao);
            Console.Write(orientacao);
        }
 
    }
}
