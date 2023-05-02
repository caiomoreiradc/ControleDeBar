using ControleDeBar.ConsoleApp.ModuloContas;
using ControleDeBar.ConsoleApp.ModuloGarçons;
using ControleDeBar.ConsoleApp.ModuloMesas;
using ControleDeBar.ConsoleApp.ModuloPedidos;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System.Collections;

namespace ControleDeBar.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioMesa repositorioMesa = new RepositorioMesa(new ArrayList());
            TelaMesa telaMesa = new TelaMesa(repositorioMesa);

            RepositorioGarçom repositorioGarçom = new RepositorioGarçom(new ArrayList());
            TelaGarçom telaGarçom = new TelaGarçom(repositorioGarçom);

            RepositorioProduto repositorioProduto = new RepositorioProduto(new ArrayList());
            TelaProduto telaProdutos = new TelaProduto(repositorioProduto);

            RepositorioConta repositorioConta = new RepositorioConta(new ArrayList());
            TelaConta telaConta = new TelaConta(repositorioConta, repositorioMesa, telaMesa);

            RepositorioPedido repositorioPedido = new RepositorioPedido(new ArrayList());
            TelaPedido telaPedido = new TelaPedido(repositorioPedido, repositorioMesa, repositorioGarçom, repositorioProduto, repositorioConta, telaMesa, telaGarçom, telaProdutos, telaConta);


            TelaPrincipal principal = new TelaPrincipal();

            while (true)
            {
                string opcao = principal.ApresentarMenu();

                if (opcao == "9")
                    break;

                if (opcao == "1")
                {
                    string subMenu = telaMesa.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaMesa.Inserir();
                    }
                    else if (subMenu == "2")
                    {
                        telaMesa.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaMesa.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaMesa.Excluir();
                    }
                }
                else if (opcao == "2")
                {
                    string subMenu = telaGarçom.ApresentarMenu();
                    if (subMenu == "1")
                    {
                        telaGarçom.Inserir();
                    }
                    else if (subMenu == "2")
                    {
                        telaGarçom.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaGarçom.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaGarçom.Excluir();
                    }
                }
                else if (opcao == "3")
                {
                    string subMenu = telaProdutos.ApresentarMenu();
                    if (subMenu == "1")
                    {
                        telaProdutos.Inserir();
                    }
                    else if (subMenu == "2")
                    {
                        telaProdutos.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaProdutos.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaProdutos.Excluir();
                    }
                }                  
                else if (opcao == "4")
                {
                    string subMenu = telaConta.ApresentarMenu();
                    if (subMenu == "1")
                    {
                        telaConta.Inserir();
                    }
                    else if (subMenu == "2")
                    {
                        telaConta.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaConta.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaConta.Excluir();
                    }                    
                    else if (subMenu == "5")
                    {
                        telaConta.VisualizarContasAbertas(true);
                        Console.ReadLine();
                    }
                }                
                else if (opcao == "5")
                {
                    string subMenu = telaPedido.ApresentarMenu();
                    if (subMenu == "1")
                    {
                        telaPedido.Inserir();
                    }
                    else if (subMenu == "2")
                    {
                        telaPedido.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaPedido.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaPedido.Excluir();
                    }                    

                }
                
            }
        }
    }   
}