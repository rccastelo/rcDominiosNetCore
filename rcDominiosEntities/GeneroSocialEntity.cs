using System;
using System.ComponentModel.DataAnnotations;

namespace rcDominiosEntities
{
    public class GeneroSocialEntity : Entity
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

        public GeneroSocialEntity() : base()
        {
        }

        public GeneroSocialEntity(int id, string descricao, string codigo, bool ativo, DateTime criacao, DateTime alteracao)
            : base(id) 
        {
            this.Descricao = descricao;
            this.Codigo = codigo;
            this.Ativo = ativo;
            this.Criacao = criacao;
            this.Alteracao = alteracao;
        }

        public GeneroSocialEntity(GeneroSocialEntity generoSocial)
            : base(generoSocial) 
        {
            if (generoSocial != null) {
                this.Descricao = generoSocial.Descricao;
                this.Codigo = generoSocial.Codigo;
                this.Ativo = generoSocial.Ativo;
                this.Criacao = generoSocial.Criacao;
                this.Alteracao = generoSocial.Alteracao;
            }
        }
    }
}
