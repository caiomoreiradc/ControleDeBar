using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloMesas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloPedidos
{
    public class RepositorioPedido : RepositorioBase
    {
        public RepositorioPedido(ArrayList listaPedidos)
        {
            this.listaRegistros = listaPedidos;
        }

        public override Pedido SelecionarPorId(int id)
        {
            return (Pedido)base.SelecionarPorId(id);
        }
    }
}
