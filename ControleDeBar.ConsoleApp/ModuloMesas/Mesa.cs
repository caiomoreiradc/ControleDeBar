using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloMesas
{
    public class Mesa : EntidadeBase
    {
        public string lugares;

        public Mesa(string numero)
        {
            this.lugares = numero;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;
            this.lugares = mesaAtualizada.lugares;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(lugares.Trim()))
                erros.Add("O campo \"lugares\" é obrigatório");
            return erros;
        }
    }
}
