using System;
using System.ComponentModel.DataAnnotations;

namespace rcDominiosEntities
{
    public class UsuarioTipoEntity : Entity
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

        public UsuarioTipoEntity() : base()
        {
        }

        public UsuarioTipoEntity(int id, string descricao, string codigo, bool ativo, DateTime criacao, DateTime alteracao)
            : base(id) 
        {
            this.Descricao = descricao;
            this.Codigo = codigo;
            this.Ativo = ativo;
            this.Criacao = criacao;
            this.Alteracao = alteracao;
        }

        public UsuarioTipoEntity(UsuarioTipoEntity usuarioTipo)
            : base(usuarioTipo) 
        {
            if (usuarioTipo != null) {
                this.Descricao = usuarioTipo.Descricao;
                this.Codigo = usuarioTipo.Codigo;
                this.Ativo = usuarioTipo.Ativo;
                this.Criacao = usuarioTipo.Criacao;
                this.Alteracao = usuarioTipo.Alteracao;
            }
        }
    }
}
