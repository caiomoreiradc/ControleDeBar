using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloGarçons;
using ControleDeBar.ConsoleApp.ModuloMesas;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public Mesa mesa;
        public string nomeCliente;
        public int valorTotal;
        public bool contaAberta;
        public string status;

        public Conta(Mesa mesa, string nomeCliente, int valorTotal, string status, bool contaAberta)
        {
            this.mesa = mesa;
            this.nomeCliente = nomeCliente;
            this.valorTotal = valorTotal;
            this.status = status;
            this.contaAberta = contaAberta;

        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta contaAtualizada = (Conta)registroAtualizado;

            this.mesa = contaAtualizada.mesa;
            this.nomeCliente = contaAtualizada.nomeCliente;
            this.valorTotal = contaAtualizada.valorTotal;
            this.contaAberta = contaAtualizada.contaAberta;
            this.status = contaAtualizada.status;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nomeCliente.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            return erros;
        }
    }
}
