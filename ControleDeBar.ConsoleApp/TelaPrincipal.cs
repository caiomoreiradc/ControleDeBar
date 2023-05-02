using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp
{
    internal class TelaPrincipal
    {
        public string ApresentarMenu()
        {
            Console.Title = "Bar da Academia";
            Console.Clear();

            Console.WriteLine("===========================================");
            Console.WriteLine("            Controle de Bar");
            Console.WriteLine("===========================================");
            Console.WriteLine("Digite 1 para o menu de Mesas");
            Console.WriteLine("Digite 2 para o menu de Garçons");
            Console.WriteLine("Digite 3 para o menu de Produtos");
            Console.WriteLine("Digite 4 para o menu de Contas");
            Console.WriteLine("Digite 5 para o menu de Pedidos");
            Console.WriteLine("Digite 6 para Gerar Relatório do dia");
            Console.WriteLine("===========================================");

            Console.WriteLine("Digite 9 para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
