using ProjetoGit.Model;

namespace ProjetoGit.Controller
{
    public class ControllerProduto
    {
        //Lista de produtos
        private List<Produto> produtos = new List<Produto>();
        //Indice para cadastro
        private int proximoId = 0;
        //Opção do menu
        private int opcao;


        //Construtor recebe lista de produtos -> Fica na memória
        public ControllerProduto(List<Produto> produtosLista) {
        
            produtos = produtosLista;
        }

        //================================Menu de Opções
        public void MenuProduto()
        {
            //Inicializar variavel opções
            opcao = 0;

            while (opcao != 3)
            {

                Console.WriteLine("===== Produto =============");
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
                            CadastrarProduto();
                            Console.Clear();
                            break;

                        case 2:
                            ListarProdutos();
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
        public void CadastrarProduto()
        {
            //Caso ja houver produtos na lista pega o ultimo ID
            if (produtos.Count > 0)
            {
                proximoId = produtos.Max(x => x.Id);
            }


            //Nome
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();

            //Preço
            Console.Write("Preço do produto: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                proximoId++;
                Produto p = new Produto(proximoId, nome, preco);

                Console.WriteLine(p.Id);
                produtos.Add(p);

                Console.WriteLine("Produto cadastrado com sucesso!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Preço inválido.");
            }

        }

        //=================================Exibir os produtos
        public void ListarProdutos()
        {
            Console.WriteLine("\n=== Lista de Produtos ===");
            foreach (Produto p in produtos)
            {
                Console.WriteLine($"ID: {p.Id}\n"+
                    $"Descrição: {p.Descricao}\n" +
                    $"Preço: {p.Valor:C}\n");
            }

            Console.ReadKey();
        }


    }
}
