using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarçons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloFaturamento
{
    public class Faturamento : EntidadeBase
    {

        public DateTime data;
        public int lucroDoDia;
        public int qtdClientes;
        public Conta conta;

        public Faturamento(DateTime data, int lucroDoDia, int qtdClientes, Conta conta)
        {
            this.data = data;
            this.lucroDoDia = lucroDoDia;
            this.qtdClientes = qtdClientes;
            this.conta = conta;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Faturamento faturamentoAtualizado = (Faturamento)registroAtualizado;

            this.data = faturamentoAtualizado.data;
            this.lucroDoDia = faturamentoAtualizado.lucroDoDia;
            this.qtdClientes = faturamentoAtualizado.qtdClientes;
            this.conta = faturamentoAtualizado.conta;
        }

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }
    }
}
