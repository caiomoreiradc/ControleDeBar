using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloFaturamento;
using ControleDeBar.ConsoleApp.ModuloGarçons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloContas
{
    public class RepositorioConta : RepositorioBase
    {
        public RepositorioConta(ArrayList listaContas)
        {
            this.listaRegistros = listaContas;
        }

        public int ObterFaturamento(ArrayList registros, int faturamento)
        {
            foreach (Conta c in registros) 
            {
                faturamento += c.valorTotal;
            }

            return faturamento;
        }

        public override Conta SelecionarPorId(int id)
        {
            return (Conta)base.SelecionarPorId(id);
        }
    }
}
