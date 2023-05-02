using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloContas;
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
    public class TelaPedido : TelaBase
    {
        private RepositorioMesa repositorioMesa;
        private RepositorioGarçom repositorioGarçom;
        private RepositorioProduto repositorioProduto;
        private RepositorioConta repositorioConta;

        private TelaMesa telaMesa;
        private TelaGarçom telaGarçom;
        private TelaProduto telaProduto;
        private TelaConta telaConta;

        public TelaPedido(RepositorioPedido repositorioPedido, RepositorioMesa repositorioMesa,
           RepositorioGarçom repositorioGarçom, RepositorioProduto repositorioProduto, RepositorioConta repositorioConta,
           TelaMesa telaMesa, TelaGarçom telaGarçom, TelaProduto telaProduto, TelaConta telaConta)
        {
            repositorioBase = repositorioPedido;
            this.repositorioMesa = repositorioMesa;
            this.repositorioGarçom = repositorioGarçom;
            this.repositorioProduto = repositorioProduto;
            this.repositorioConta = repositorioConta;
            this.telaMesa = telaMesa;
            this.telaGarçom = telaGarçom;
            this.telaProduto = telaProduto;
            this.telaConta = telaConta;

            nomeEntidade = "Pedido";
            sufixo = "s";
        }

        public override void Inserir()
        {
            bool temMesas = repositorioMesa.TemRegistros();

            if (temMesas == false)
            {
                MostrarMensagem("Cadastre ao menos uma mesa para cadastrar um pedido!", ConsoleColor.Yellow);
                return;
            }

            bool temGarçoms = repositorioGarçom.TemRegistros();

            if (temGarçoms == false)
            {
                MostrarMensagem("Cadastre ao menos um Garçom para cadastrar um pedido!", ConsoleColor.Yellow);
                return;
            }     
            
            bool temProdutos = repositorioProduto.TemRegistros();

            if (temProdutos == false)
            {
                MostrarMensagem("Cadastre ao menos um Produto para cadastrar um pedido!", ConsoleColor.Yellow);
                return;
            }

            base.Inserir();
        }

        public override void EditarRegistro()
        {
            bool temMesas = repositorioMesa.TemRegistros();

            if (temMesas == false)
            {
                MostrarMensagem("Cadastre ao menos uma mesa para cadastrar um pedido!", ConsoleColor.Yellow);
                return;
            }

            bool temGarçoms = repositorioGarçom.TemRegistros();

            if (temGarçoms == false)
            {
                MostrarMensagem("Cadastre ao menos um Garçom para cadastrar um pedido!", ConsoleColor.Yellow);
                return;
            }

            bool temProdutos = repositorioProduto.TemRegistros();

            if (temProdutos == false)
            {
                MostrarMensagem("Cadastre ao menos um Produto para cadastrar um pedido!", ConsoleColor.Yellow);
                return;
            }

            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}");

            VisualizarRegistros(false);

            Console.WriteLine();

            Pedido pedidos = (Pedido)EncontrarRegistro("Digite o id do pedido: ");

            EntidadeBase registroAtualizado = ObterRegistro();

            if (TemErrosDeValidacao(registroAtualizado))
            {
                EditarRegistro();

                return;
            }

            repositorioBase.Editar(pedidos.id, registroAtualizado);

            MostrarMensagem("Pedido editado com sucesso!", ConsoleColor.Green);
        }

        public override void Excluir()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}");

            VisualizarRegistros(false);

            Console.WriteLine();

            Pedido pedidos = (Pedido)EncontrarRegistro("Digite o id do pedido: ");

            repositorioBase.Excluir(pedidos);

            MostrarMensagem("Pedido excluído com sucesso!", ConsoleColor.Green);
        }
        protected override void MostrarTabela(ArrayList registros)
        {
            Console.WriteLine("{0, -4} | {1, -3} | {2, -20} | {3, -15} | {4, -15} | {5, -4}", "Id", "Mesa", "Garçom","Cliente", "Produto", "Quantidade");

            Console.WriteLine("--------------------------------------------------------------------------------------------------");

            foreach (Pedido pedidos in registros)
            {
                Console.WriteLine("{0, -4} | {1, -3} | {2, -20} | {3, -15} | {4, -15} | {5, -4}",
                    pedidos.id,
                    pedidos.conta.mesa.id,
                    pedidos.garçom.nome,
                    pedidos.conta.nomeCliente,
                    pedidos.produto.nome,
                    pedidos.quantidade);
            }
        }

        protected override EntidadeBase ObterRegistro()
        {
            Conta conta = ObterConta();

            Garçom garçom = ObterGarçom();

            Produto produto = ObterProduto();

            Console.Write("Digite a quantidade do produto: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            return new Pedido(garçom, produto, conta, quantidade);
        }
    
        
        private Garçom ObterGarçom()
        {
            telaGarçom.VisualizarRegistros(false);

            Garçom garçom = (Garçom)telaGarçom.EncontrarRegistro("Digite o id do garçom: ");

            Console.WriteLine();

            return garçom;
        }        
        
        private Produto ObterProduto()
        {
            telaProduto.VisualizarRegistros(false);

            Produto produto = (Produto)telaProduto.EncontrarRegistro("Digite o id do produto: ");

            Console.WriteLine();

            return produto;
        }        
        
        private Conta ObterConta()
        {
            telaConta.VisualizarRegistros(false);

            Conta conta = (Conta)telaConta.EncontrarRegistro("Digite o id da conta: ");

            Console.WriteLine();

            return conta;
        }

    }
}
