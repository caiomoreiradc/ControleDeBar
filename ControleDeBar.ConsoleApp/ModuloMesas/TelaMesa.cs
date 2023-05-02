using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloMesas
{
    public class TelaMesa : TelaBase
    {
        public TelaMesa(RepositorioMesa repositorioMesa)
        {
            repositorioBase = repositorioMesa;
            nomeEntidade = "Mesa";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -4} | {1, -4}", "Id", "Lugares");

            Console.WriteLine("--------------------------------------------------------------------");

            foreach (Mesa mesa in registros)
            {
                Console.WriteLine("{0, -4} | {1, -4}", mesa.id, mesa.lugares);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite a quantidade de cadeiras: ");
            string lugares = Console.ReadLine();
            return new Mesa(lugares);
        }
    }
}
