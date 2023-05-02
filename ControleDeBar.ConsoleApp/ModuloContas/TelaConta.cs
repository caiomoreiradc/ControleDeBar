using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarçons;
using ControleDeBar.ConsoleApp.ModuloMesas;
using ControleDeBar.ConsoleApp.ModuloPedidos;
using ControleDeBar.ConsoleApp.ModuloProdutos;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloContas
{
    public class TelaConta : TelaBase
    {
        bool contaAberta;
        private RepositorioMesa repositorioMesa;
        private TelaMesa telaMesa;
        public TelaConta(RepositorioConta repositorioConta, RepositorioMesa repositorioMesa, TelaMesa telaMesa)
        {
            this.repositorioBase = repositorioConta;
            this.repositorioMesa = repositorioMesa;
            this.telaMesa = telaMesa;

            nomeEntidade = "Conta";
            sufixo = "s";
            this.telaMesa = telaMesa;
        }
        public override void Inserir()
        {
            bool temMesas = repositorioMesa.TemRegistros();

            if (temMesas == false)
            {
                MostrarMensagem("Cadastre ao menos uma mesa para cadastrar uma conta!", ConsoleColor.Yellow);
                return;
            }

            base.Inserir();
        }

        public override void EditarRegistro()
        {
            bool temMesas = repositorioMesa.TemRegistros();

            if (temMesas == false)
            {
                MostrarMensagem("Cadastre ao menos uma mesa para cadastrar uma conta!", ConsoleColor.Yellow);
                return;
            }

            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}");

            VisualizarRegistros(false);

            Console.WriteLine();

            Pedido pedidos = (Pedido)EncontrarRegistro("Digite o id da conta: ");

            EntidadeBase registroAtualizado = ObterRegistro();

            if (TemErrosDeValidacao(registroAtualizado))
            {
                EditarRegistro();

                return;
            }

            repositorioBase.Editar(pedidos.id, registroAtualizado);

            MostrarMensagem("Conta editado com sucesso!", ConsoleColor.Green);
        }

        public override void Excluir()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}");

            VisualizarRegistros(false);

            Console.WriteLine();

            Conta conta = (Conta)EncontrarRegistro("Digite o id da conta: ");

            conta.contaAberta = false;
            conta.status = "Fechada";

            MostrarMensagem("Conta Fechada!", ConsoleColor.Green);
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -4} | {1, -3} | {2, -20} | {3, -8} | {4, -10}", "Id", "Mesa", "Cliente", "Valor Total", "Status");

            Console.WriteLine("-----------------------------------------------------------------------------------------");

            foreach (Conta conta in registros)
            {
                Console.WriteLine("{0, -4} | {1, -3} | {2, -20} | {3, -8} | {4, -10}",
                    conta.id,
                    conta.mesa.id,
                    conta.nomeCliente,
                    "R$" + conta.valorTotal,
                    conta.status
                    ) ;
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Mesa mesa = ObterMesa();

            Console.Write("Insira o nome do Cliente: ");
            string nomeCliente = Console.ReadLine();

            int valorTotal = 0;

            bool contaAberta = true;
            string status = "Aberta";

            return new Conta(mesa, nomeCliente, valorTotal, status, contaAberta);
        }

        private Mesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(false);

            Mesa mesa = (Mesa)telaMesa.EncontrarRegistro("Digite o id da mesa: ");

            Console.WriteLine();

            return mesa;
        }

        public virtual void VisualizarContasAbertas(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}");

            ArrayList registros = repositorioBase.SelecionarTodos();

            if (registros.Count == 0)
            {
                MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow);
            }

            TabelaAbertas(registros);
        }
        public void TabelaAbertas(ArrayList registros)
        {
            Console.WriteLine("{0, -4} | {1, -3} | {2, -20} | {3, -8} | {4, -10}", "Id", "Mesa", "Cliente", "Valor Total", "Status");

            Console.WriteLine("-----------------------------------------------------------------------------------------");

            foreach (Conta conta in registros)
            {
                if(conta.contaAberta == true)
                {
                    Console.WriteLine("{0, -4} | {1, -3} | {2, -20} | {3, -8} | {4, -10}",
                    conta.id,
                    conta.mesa.id,
                    conta.nomeCliente,
                    "R$" + conta.valorTotal,
                    conta.status
                    );
                }
                else
                {
                    return;
                }
            }
        }
        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");

            Console.WriteLine($"Digite 1 para Inserir {nomeEntidade}");
            Console.WriteLine($"Digite 2 para Visualizar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 3 para Editar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 4 para Fechar {nomeEntidade}{sufixo}\n");
            Console.WriteLine($"Digite 5 para Ver contas em aberto {nomeEntidade}{sufixo}\n");

            Console.WriteLine("Digite 9 para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
