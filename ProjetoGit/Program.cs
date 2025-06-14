﻿using ProjetoGit.Controller;
using ProjetoGit.Model;

//Cria tipo lista
List<Produto> produtos = new List<Produto>();
List<Agenda> agendas = new List<Agenda>();
List<Hardware> hardwares = new List<Hardware>();




//Instacia calsse responsável pela camada de negócios
ControllerProduto controllerProduto = new ControllerProduto(produtos);
ControllerHotel controllerHotel = new ControllerHotel();
ControllerHardware controllerHardware = new ControllerHardware(hardwares);
ControllerAgenda controllerAgenda = new ControllerAgenda(agendas);

//Menu Principal
int opcao;

do
{
    Console.Clear();
    Console.WriteLine("===== MENU PRINCIPAL =====");
    Console.WriteLine("| 1 - Produtos           |");
    Console.WriteLine("| 2 - Hotel              |");
    Console.WriteLine("| 3 - Hardware           |");
    Console.WriteLine("| 4 - Agenda             |");
    Console.WriteLine("| 5 - Softwares          |");
    Console.WriteLine("| 0 - Sair               |");
    Console.WriteLine("==========================");
    Console.Write("Escolha uma opção: ");

    // Tenta converter a entrada para inteiro
    if (int.TryParse(Console.ReadLine(), out opcao))
    {
        switch (opcao)
        {
            case 1:
                //Limpa console
                Console.Clear();
                //Chama a o método pricipal da classe ProdutoController
                controllerProduto.MenuProduto();
                break;
            case 2:
                controllerHotel.MenuHotel();
                break;
            case 3:
                Console.WriteLine("Hardwares.");//Cadastrar Hardwares 
                //Limpa console
                Console.Clear();
                //Chama a o método pricipal da classe ProdutoController
                controllerHardware.MenuHardware();
                break;
            case 4:
                Console.WriteLine("Agenda.");//Agenda Data
                                             //Limpa console
                Console.Clear();
                //Chama a o método pricipal da classe ProdutoController
                controllerAgenda.MenuAgenda();
                break;
            case 5:
                Console.WriteLine("Softwares");//Cadastrar Softwares
                //Limpa console
                Console.Clear();
                //Chama a o método pricipal da classe ProdutoController
                //controllerSoftware.MenuSoftware();
                break;
            case 0:
                Console.WriteLine("Sair");
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }
    else
    {
        Console.WriteLine("Você digitou um texto ou um valor inválido.");
        opcao = 10;//Não cair no if
        Console.Clear() ;
    }
    

} while (opcao != 0);



//Cria sua branch
//git checkout -b "Nome da Branch"


//Lista as branch e mostra a que você está
//git branch

//Adiciona Atualizações a sua branch
//git add .
//git commit -m "Minha contribuição"
//git push origin nome-da-sua-branch