using System;
using System.ComponentModel.DataAnnotations;

namespace rcDominiosEntities
{
    public class CorEntity : Entity
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

        public CorEntity() : base()
        {
        }

        public CorEntity(int id, string descricao, string codigo, bool ativo, DateTime criacao, DateTime alteracao)
            : base(id) 
        {
            this.Descricao = descricao;
            this.Codigo = codigo;
            this.Ativo = ativo;
            this.Criacao = criacao;
            this.Alteracao = alteracao;
        }

        public CorEntity(CorEntity cor)
            : base(cor) 
        {
            if (cor != null) {
                this.Descricao = cor.Descricao;
                this.Codigo = cor.Codigo;
                this.Ativo = cor.Ativo;
                this.Criacao = cor.Criacao;
                this.Alteracao = cor.Alteracao;
            }
        }
    }
}
