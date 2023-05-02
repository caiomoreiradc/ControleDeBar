using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarçons;
using ControleDeBar.ConsoleApp.ModuloMesas;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloPedidos
{
    public class Pedido : EntidadeBase
    {
        public Garçom garçom;
        public Produto produto;
        public Conta conta;
        public int quantidade;
        public Pedido(Garçom garçom, Produto produto, Conta conta, int quantidade)
        {
            this.garçom = garçom;
            this.produto = produto;
            this.conta = conta;
            this.quantidade = quantidade;
            conta.valorTotal += produto.preço * quantidade;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Pedido pedidoAtualizado = (Pedido)registroAtualizado;

            this.garçom = pedidoAtualizado.garçom;
            this.produto = pedidoAtualizado.produto;
            this.conta = pedidoAtualizado.conta;
            this.quantidade = pedidoAtualizado.quantidade;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (garçom == null)
                erros.Add("O campo \"produto\" é obrigatório");            
            
            if (produto == null)
                erros.Add("O campo \"produto\" é obrigatório");     
            
            if (conta == null)
                erros.Add("O campo \"conta\" é obrigatório");

            if (quantidade < 0)
                erros.Add("O campo \"quantidade\" deve ser maior que 0");

            return erros;
        }

    }
}
