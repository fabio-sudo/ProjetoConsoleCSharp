using ProjetoGit.Model;

namespace ProjetoGit.Controller
{
    public class ControllerAgenda
    {
        //Lista de agendas
        private List<Agenda> agendas = new List<Agenda>();
        //Indice para cadastro
        private int proximoId = 0;
        //Opção do menu
        private int opcao;


        //Construtor recebe lista de agendas -> Fica na memória
        public ControllerAgenda(List<Agenda> agendasLista)
        {

            agendas = agendasLista;
        }

        //================================Menu de Opções
        public void MenuAgenda()
        {
            //Inicializar variavel opções
            opcao = 0;

            while (opcao != 3)
            {

                Console.WriteLine("===== Agenda =============");
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
                            CadastrarAgenda();
                            Console.Clear();
                            break;

                        case 2:
                            ListarAgendas();
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

        //=================================Adicionar Agendas
        public void CadastrarAgenda()
        {
            //Caso ja houver agendas na lista pega o ultimo ID
            if (agendas.Count > 0)
            {
                proximoId = agendas.Max(x => x.Id);
            }


            //Nome Pessoa
            Console.Write("Nome da Pessoa: ");
            string nomePessoa = Console.ReadLine();

            //Numero de Telefone
            Console.Write("Celular: ");
            string celular = Console.ReadLine();
            
                proximoId++;
                Agenda a = new Agenda(proximoId, nomePessoa, celular);

                Console.WriteLine(a.Id);
                agendas.Add(a);

                Console.WriteLine("Agenda cadastrada com sucesso!");
                Console.ReadKey();
    
   
        }

        //=================================Exibir as agendas
        public void ListarAgendas()
        {
            Console.WriteLine("\n=== Lista de Agendas ===");
            foreach (Agenda a in agendas)
            {
                Console.WriteLine($"ID: {a.Id}\n" +
                    $"Nome: {a.NomePessoa}\n" +
                    $"Celular: {a.Celular}\n");
            }

            Console.ReadKey();
        }


    }
}
