using Newtonsoft.Json;
using ProjetoGit.Model;

namespace ProjetoGit.Controller
{
    public class ControllerHardware
    {
        //Lista de hardwares
        private List<Hardware> hardwares = new List<Hardware>();
        //Indice para cadastro
        private int proximoId = 0;
        //Opção do menu
        private int opcao;


        public ControllerHardware(List<Hardware> hardwareLista)
        {
            hardwares = hardwareLista;
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
                            CadastrarHarware();
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
        public void CadastrarHarware()
        {
            //Caso ja houver produtos na lista pega o ultimo ID
            if (hardwares.Count > 0)
            {
                proximoId = hardwares.Max(x => x.Id);
            }


            //Nome
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();

            //marca
            Console.WriteLine("Marca: ");
            string marca = Console.ReadLine();

            //tipo
            Console.WriteLine("Tipo: ");
            string tipo = Console.ReadLine();

            //descrição
            Console.WriteLine("Descrição: ");
            string descricao = Console.ReadLine();

            //Preço
            Console.Write("Preço do produto: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                proximoId++;
                Hardware h = new Hardware(proximoId, nome, tipo, marca, descricao, preco);

                hardwares.Add(h);


                //Passar a lista para JsonConvert
                string json = JsonConvert.SerializeObject(hardwares, Formatting.Indented);


                //Buscando Local do arquivo
                string folderPath = @"C:\Users\Aluno\Desktop\ProjetoConsoleCSharp\ProjetoGit\BancoLocal\";
                
                // Cria o diretório, se não existir
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Nome do arquivo
                string filePath = Path.Combine(folderPath, "hardwares.json");

                // Salva o JSON no arquivo
                File.WriteAllText(filePath, json);

                Console.WriteLine("Arquivo salvo com sucesso em: " + filePath);


                Console.WriteLine("Produto cadastrado com sucesso!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Preço inválido.");
            }

        }

        public void ListarHardware()
        {
            {


                string folderPath = @"C:\Users\Aluno\Desktop\ProjetoConsoleCSharp\ProjetoGit\BancoLocal\hardwares.json";

                var json = File.ReadAllText(folderPath);
                
                hardwares = JsonConvert.DeserializeObject<List<Hardware>>(json);

                Console.WriteLine("\n=== Lista de Hardware ===");
                foreach (Hardware h in hardwares)
                {
                    Console.WriteLine($"ID: {h.Id}\n" +
                        $"Descrição: {h.Descricao}\n" +
                        $"Preço: {h.Preco:C}\n");
                }

                Console.ReadKey();
            }
        }

    }
}
