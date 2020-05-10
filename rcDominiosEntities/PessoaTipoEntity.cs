using System;
using System.ComponentModel.DataAnnotations;

namespace rcDominiosEntities
{
    public class PessoaTipoEntity : Entity
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

        public PessoaTipoEntity() : base()
        {
        }

        public PessoaTipoEntity(int id, string descricao, string codigo, bool ativo, DateTime criacao, DateTime alteracao)
            : base(id) 
        {
            this.Descricao = descricao;
            this.Codigo = codigo;
            this.Ativo = ativo;
            this.Criacao = criacao;
            this.Alteracao = alteracao;
        }

        public PessoaTipoEntity(PessoaTipoEntity pessoaTipo)
            : base(pessoaTipo) 
        {
            if (pessoaTipo != null) {
                this.Descricao = pessoaTipo.Descricao;
                this.Codigo = pessoaTipo.Codigo;
                this.Ativo = pessoaTipo.Ativo;
                this.Criacao = pessoaTipo.Criacao;
                this.Alteracao = pessoaTipo.Alteracao;
            }
        }
    }
}
