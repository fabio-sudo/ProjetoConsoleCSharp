

using ProjetoGit.Model;

namespace ProjetoGit.Controller
{
    //Lista de Nomes
    private List<Agenda> Nomes = new List<Agenda>();
    //Indice para cadastro
    private int proximoId = 0;
    //Opção do menu
    private int opcao;


    //Construtor recebe lista de agenda -> Fica na memória
    public Agenda(List<Agenda> Nomes)
    {

        Nomes = NomesLista;
    }

    //================================Menu de Opções
    public void Agenda()
    {
        //Inicializar variavel opções
        opcao = 0;
    public class Agenda
    {
        while (opcao != 4)
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
                            ListarAgenda();
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

        //=================================Adicionar Nomes
        public void CadastrarAgenda()
{
    //Caso ja houver produtos na lista pega o ultimo ID
    if (produtos.Count > 0)
    {
        proximoId = Nomes.Max(x => x.Id);
    }


    //Nome
    Console.Write("Nome: ");
    string Nome = Console.ReadLine();

    //Celular
    Console.Write("Número do celular: ");
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
        Console.WriteLine($"ID: {p.Id}\n" +
            $"Descrição: {p.Descricao}\n" +
            $"Preço: {p.Valor:C}\n");
    }

    Console.ReadKey();
}


    }
}
    }
}
