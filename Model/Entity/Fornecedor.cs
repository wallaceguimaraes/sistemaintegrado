using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegrado.Model.Entity
{
    public class Fornecedor
    {
        private int fornecedorId;
        private string nome;
        private string cpfCnpj;
        private string telefone;
        private string email;
        private string ativo;


        public Fornecedor()
        {


        }
        public Fornecedor(int fornecedorId, string nome, string cpfCnpj, string telefone,string email, string ativo)
        {
            this.fornecedorId = fornecedorId;
            this.nome = nome;
            this.cpfCnpj = cpfCnpj;
            this.telefone = telefone;
            this.email = email;
            this.ativo = ativo;
        }


        public void SetFornecedorId(int fornecedorId)
        {
            this.fornecedorId = fornecedorId;
        }

        public int GetFornecedorId()
        {
            return fornecedorId;
        }


        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public string GetNome()
        {
            return nome.ToUpper();
        }

        public void SetCpfCnpj(string cpfCnpj)
        {
            this.cpfCnpj = cpfCnpj;
        }

        public string GetCpfCnpj()
        {
            return cpfCnpj;
        }

        public void SetTelefone(string telefone)
        {
            this.telefone = telefone;
        }

        public string GetTelefone()
        {
            return telefone;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }

        public string GetEmail()
        {
            return email;
        }

        public void SetAtivo(string ativo)
        {
            this.ativo = ativo;
        }

        public string GetAtivo()
        {
            return ativo.ToUpper();
        }



    }
}
