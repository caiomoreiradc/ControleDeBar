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
    public class RepositorioGarçom  :RepositorioBase
    {
        public RepositorioGarçom(ArrayList listaGarçons)
        {
            this.listaRegistros = listaGarçons;
        }

        public override Garçom SelecionarPorId(int id)
        {
            return (Garçom)base.SelecionarPorId(id);
        }
    }
}
