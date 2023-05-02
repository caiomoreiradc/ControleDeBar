using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloMesas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloGarçons
{
    public class TelaGarçom : TelaBase
    {
        public TelaGarçom(RepositorioGarçom repositorioGarçom)
        {
            repositorioBase = repositorioGarçom;
            nomeEntidade = "Garçon";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -4} | {1, -20} | {2, -2} | {3, -14} | {4, -25}", "Id", "Nome", "Idade", "CPF", "Endereço");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------");

            foreach (Garçom garçon in registros)
            {
                Console.WriteLine("{0, -4} | {1, -20} | {2, -2} | {3, -14} | {4, -25}", garçon.id, garçon.nome, garçon.idade, garçon.cpf, garçon.endereço);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome do garçon: ");
            string nome = Console.ReadLine();      
            
            Console.Write("Digite a idade do garçon: ");
            string idade = Console.ReadLine();        
            
            Console.Write("Digite o cpf do garçon: ");
            string cpf = Console.ReadLine();    
            
            Console.Write("Digite o endereço do garçon: ");
            string endereço = Console.ReadLine();
            return new Garçom(nome, idade, cpf , endereço);
        }
    }
}
