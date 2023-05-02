using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloContas;
using ControleDeBar.ConsoleApp.ModuloGarçons;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloFaturamento
{
    public class TelaFaturamento 
    {
        RepositorioConta repositorioConta;

        int faturamento = repositorioConta.ObterFaturamento();
    }
}
