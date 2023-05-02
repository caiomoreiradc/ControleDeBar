using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloMesas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloProdutos
{
    public class TelaProduto : TelaBase
    {
        public TelaProduto(RepositorioProduto repositorioProduto)
        {
            repositorioBase = repositorioProduto;
            nomeEntidade = "Produto";
            sufixo = "s";
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -4} | {1, -15} | {2, -7}", "Id", "Nome", "Preço");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Produto produto in registros)
            {
                Console.WriteLine("{0, -4} | {1, -15} | {2, -7}", produto.id, produto.nome, produto.preço);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Insira o Nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Insira o Preço do produto: ");
            int preço = int.Parse(Console.ReadLine());

            return new Produto(nome, preço);
        }
    }
}
