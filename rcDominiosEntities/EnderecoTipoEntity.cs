using System;
using System.ComponentModel.DataAnnotations;

namespace rcDominiosEntities
{
    public class EnderecoTipoEntity : Entity
    {
        [StringLength(200)]
        public string Descricao { get; set; }

        [StringLength(20)]
        public string Codigo { get; set; }

        public bool Ativo { get; set; }        

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Criacao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Alteracao { get; set; }

        public EnderecoTipoEntity() : base()
        {
        }

        public EnderecoTipoEntity(int id, string descricao, string codigo, bool ativo, DateTime criacao, DateTime alteracao)
            : base(id) 
        {
            this.Descricao = descricao;
            this.Codigo = codigo;
            this.Ativo = ativo;
            this.Criacao = criacao;
            this.Alteracao = alteracao;
        }

        public EnderecoTipoEntity(EnderecoTipoEntity enderecoTipo)
            : base(enderecoTipo) 
        {
            if (enderecoTipo != null) {
                this.Descricao = enderecoTipo.Descricao;
                this.Codigo = enderecoTipo.Codigo;
                this.Ativo = enderecoTipo.Ativo;
                this.Criacao = enderecoTipo.Criacao;
                this.Alteracao = enderecoTipo.Alteracao;
            }
        }
    }
}
