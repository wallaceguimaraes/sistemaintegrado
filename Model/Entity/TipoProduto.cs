using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIntegrado.Model.Entity
{
    public class TipoProduto
    {
        private int tipoProdutoId;
        private string descricao;    
        private string ativo;


        public TipoProduto()
        {


        }
        public TipoProduto(int tipoProdutoId, string descricao, string ativo)
        {
            this.tipoProdutoId = tipoProdutoId;
            this.descricao = descricao;
            this.ativo = ativo;           
        }


        public void SetTipoProdutoId(int tipoProdutoId)
        {
            this.tipoProdutoId = tipoProdutoId;
        }

        public int GetTipoProdutoId()
        {
            return tipoProdutoId;
        }


        public void SetDescricao(string descricao)
        {
            this.descricao = descricao;
        }

        public string GetDescricao()
        {
            return descricao.ToUpper();
        }
 
        public void SetAtivo(string ativo)
        {
            this.ativo = ativo;
        }

        public string GetAtivo()
        {
            return ativo;
        }
      


    }
}
