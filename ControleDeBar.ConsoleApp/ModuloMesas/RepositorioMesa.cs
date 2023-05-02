using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloMesas
{
    public class RepositorioMesa :RepositorioBase
    {
        public RepositorioMesa(ArrayList listaMesas)
        {
            this.listaRegistros = listaMesas;
        }

        public override Mesa SelecionarPorId(int id)
        {
            return (Mesa)base.SelecionarPorId(id);
        }
    }
}
