using ProjetoGit.Model;

namespace ProjetoGit.Controller
{
    public class ControllerHardware
    {
        //Lista de hardwares
        private List<Hardware> hardware = new List<Hardware>();
        //Indice para cadastro
        private int proximoId = 0;
        //Opção do menu
        private int opcao;


        public ControllerHardware(List<Hardware> hardwareLista)
        {
            hardware = hardwareLista;
        }
        //================================Menu de Opções
        public void MenuHardware()
        {
            //Inicializar variavel opções
            opcao = 0;

            while (opcao != 3)
            {

                Console.WriteLine("===== Hardware =============");
                Console.WriteLine("| 1 - Cadastrar           |");
                Console.WriteLine("| 2 - Listar              |");
                Console.WriteLine("| 3 - Sair                |");
                Console.WriteLine("===========================");
                Console.Write("Escolha uma opção: ");
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            CadastrarHardware();
                            Console.Clear();
                            break;

                        case 2:
                            ListarHardware();
                            Console.Clear();
                            break;

                        case 3:
                            Console.WriteLine("Voltando ao menu principal...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                }
                else { Console.WriteLine("Informe uma opção válida"); }

            }
        }
        //=================================Adicionar Produtos
        public void CadastrarHardware()
        {

        }
    }
}
