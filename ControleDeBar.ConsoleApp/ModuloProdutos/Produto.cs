using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloProdutos
{
    public class Produto : EntidadeBase
    {
        public string nome;
        public int preço;

        public Produto(string nome, int preço)
        {
            this.nome = nome;
            this.preço = preço;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produto produtoAtualizado = (Produto)registroAtualizado;
            this.nome = produtoAtualizado.nome;
            this.preço = produtoAtualizado.preço;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");
            return erros;
        }
    }
}
