using System;
using System.ComponentModel.DataAnnotations;

namespace rcDominiosEntities
{
    public class SexoEntity : Entity
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

        public SexoEntity() : base()
        {
        }

        public SexoEntity(int id, string descricao, string codigo, bool ativo, DateTime criacao, DateTime alteracao)
            : base(id) 
        {
            this.Descricao = descricao;
            this.Codigo = codigo;
            this.Ativo = ativo;
            this.Criacao = criacao;
            this.Alteracao = alteracao;
        }

        public SexoEntity(SexoEntity sexo)
            : base(sexo) 
        {
            if (sexo != null) {
                this.Descricao = sexo.Descricao;
                this.Codigo = sexo.Codigo;
                this.Ativo = sexo.Ativo;
                this.Criacao = sexo.Criacao;
                this.Alteracao = sexo.Alteracao;
            }
        }
    }
}
