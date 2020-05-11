using System;
using System.ComponentModel.DataAnnotations;

namespace rcDominiosEntities
{
    public class ProfissaoEntity : Entity
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

        public ProfissaoEntity() : base()
        {
        }

        public ProfissaoEntity(int id, string descricao, string codigo, bool ativo, DateTime criacao, DateTime alteracao)
            : base(id) 
        {
            this.Descricao = descricao;
            this.Codigo = codigo;
            this.Ativo = ativo;
            this.Criacao = criacao;
            this.Alteracao = alteracao;
        }

        public ProfissaoEntity(ProfissaoEntity profissao)
            : base(profissao) 
        {
            if (profissao != null) {
                this.Descricao = profissao.Descricao;
                this.Codigo = profissao.Codigo;
                this.Ativo = profissao.Ativo;
                this.Criacao = profissao.Criacao;
                this.Alteracao = profissao.Alteracao;
            }
        }
    }
}
