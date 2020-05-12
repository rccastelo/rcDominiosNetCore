using System;
using System.ComponentModel.DataAnnotations;

namespace rcDominiosEntities
{
    public class EstadoCivilEntity : Entity
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

        public EstadoCivilEntity() : base()
        {
        }

        public EstadoCivilEntity(int id, string descricao, string codigo, bool ativo, DateTime criacao, DateTime alteracao)
            : base(id) 
        {
            this.Descricao = descricao;
            this.Codigo = codigo;
            this.Ativo = ativo;
            this.Criacao = criacao;
            this.Alteracao = alteracao;
        }

        public EstadoCivilEntity(EstadoCivilEntity estadoCivil)
            : base(estadoCivil) 
        {
            if (estadoCivil != null) {
                this.Descricao = estadoCivil.Descricao;
                this.Codigo = estadoCivil.Codigo;
                this.Ativo = estadoCivil.Ativo;
                this.Criacao = estadoCivil.Criacao;
                this.Alteracao = estadoCivil.Alteracao;
            }
        }
    }
}
