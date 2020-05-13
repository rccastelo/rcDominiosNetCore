using System;
using System.ComponentModel.DataAnnotations;

namespace rcDominiosEntities
{
    public class TelefoneTipoEntity : Entity
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

        public TelefoneTipoEntity() : base()
        {
        }

        public TelefoneTipoEntity(int id, string descricao, string codigo, bool ativo, DateTime criacao, DateTime alteracao)
            : base(id) 
        {
            this.Descricao = descricao;
            this.Codigo = codigo;
            this.Ativo = ativo;
            this.Criacao = criacao;
            this.Alteracao = alteracao;
        }

        public TelefoneTipoEntity(TelefoneTipoEntity telefoneTipo)
            : base(telefoneTipo) 
        {
            if (telefoneTipo != null) {
                this.Descricao = telefoneTipo.Descricao;
                this.Codigo = telefoneTipo.Codigo;
                this.Ativo = telefoneTipo.Ativo;
                this.Criacao = telefoneTipo.Criacao;
                this.Alteracao = telefoneTipo.Alteracao;
            }
        }
    }
}
