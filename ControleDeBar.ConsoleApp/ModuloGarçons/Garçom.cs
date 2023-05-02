using ControleDeBar.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeBar.ConsoleApp.ModuloGarçons
{
    public class Garçom : EntidadeBase
    {
        public string nome;
        public string idade;
        public string cpf;
        public string endereço;

        public Garçom(string nome, string idade, string cpf, string endereço)
        {
            this.nome = nome;
            this.idade = idade;
            this.cpf = cpf;
            this.endereço = endereço;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Garçom garçonAtualizado = (Garçom)registroAtualizado;

            this.nome = garçonAtualizado.nome;
            this.idade = garçonAtualizado.idade;
            this.cpf = garçonAtualizado.cpf;
            this.endereço = garçonAtualizado.endereço;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");  
            
            if (string.IsNullOrEmpty(idade.Trim()))
                erros.Add("O campo \"idade\" é obrigatório");       
            
            if (string.IsNullOrEmpty(cpf.Trim()))
                erros.Add("O campo \"cpf\" é obrigatório");        
            
            if (string.IsNullOrEmpty(endereço.Trim()))
                erros.Add("O campo \"endereço\" é obrigatório");
            return erros;
        }
    }
}
