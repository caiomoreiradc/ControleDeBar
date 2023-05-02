using System.Collections;

namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public abstract class TelaBase
    {
        public string nomeEntidade;
        public string sufixo;

        protected RepositorioBase repositorioBase = null;

        public void MostrarCabecalho(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo + "\n");

        }

        public void MostrarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();

            Console.ForegroundColor = cor;

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }

        public virtual string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");

            Console.WriteLine($"Digite 1 para Inserir {nomeEntidade}");
            Console.WriteLine($"Digite 2 para Visualizar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 3 para Editar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 4 para Excluir {nomeEntidade}{sufixo}\n");

            Console.WriteLine("Digite 9 para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public virtual void Inserir()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}");

            EntidadeBase registro = ObterRegistro();

            if (TemErrosDeValidacao(registro))
            {
                Inserir(); 

                return;
            }

            repositorioBase.Inserir(registro);

            MostrarMensagem("Registro inserido!", ConsoleColor.Green);
        }
        
        public virtual void VisualizarRegistros(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}");

            ArrayList registros = repositorioBase.SelecionarTodos();

            if (registros.Count == 0)
            {
                MostrarMensagem("Nenhum registro cadastrado", ConsoleColor.DarkYellow);
            }

            MostrarTabela(registros);
        }        

        public virtual void EditarRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}");

            VisualizarRegistros(false);

            Console.WriteLine();

            EntidadeBase registro = EncontrarRegistro("Digite o id do registro: ");

            EntidadeBase registroAtualizado = ObterRegistro();

            if (TemErrosDeValidacao(registroAtualizado))
            {
                EditarRegistro();

                return;
            }

            repositorioBase.Editar(registro, registroAtualizado);

            MostrarMensagem("Registro editado!", ConsoleColor.Yellow);
        }

        public virtual void Excluir()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}");

            VisualizarRegistros(false);

            Console.WriteLine();

            EntidadeBase registro = EncontrarRegistro("Digite o id do registro: ");

            repositorioBase.Excluir(registro);

            MostrarMensagem("Registro excluído!", ConsoleColor.Red);
        }      

        public virtual EntidadeBase EncontrarRegistro(string textoCampo)
        {            
            bool idInvalido;
            EntidadeBase registroSelecionado = null;

            do
            {
                idInvalido = false;
                Console.Write("\n" + textoCampo);
                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());

                    registroSelecionado = repositorioBase.SelecionarPorId(id);

                    if (registroSelecionado == null)
                        idInvalido = true;
                }
                catch (FormatException)
                {
                    idInvalido = true;
                }

                if (idInvalido)
                    MostrarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return registroSelecionado;
        }

        protected bool TemErrosDeValidacao(EntidadeBase registro)
        {
            bool temErros = false;

            ArrayList erros = registro.Validar();

            if (erros.Count > 0)
            {
                temErros = true;
                Console.ForegroundColor = ConsoleColor.Red;

                foreach (string erro in erros)
                {
                    Console.WriteLine(erro);
                }

                Console.ResetColor();

                Console.ReadLine();
            }

            return temErros;
        }

        protected abstract EntidadeBase ObterRegistro();

        protected abstract void MostrarTabela(ArrayList registros);

    }
}
