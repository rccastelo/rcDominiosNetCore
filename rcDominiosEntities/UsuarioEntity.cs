using System;
using System.ComponentModel.DataAnnotations;

namespace rcDominiosEntities
{
    public class UsuarioEntity : Entity
    {
        [StringLength(40)]
        public string Apelido { get; set; }

        [StringLength(40)]
        public string Senha { get; set; }

        [StringLength(40)]
        public string NomeApresentacao { get; set; }

        [StringLength(200)]
        public string NomeCompleto { get; set; }

        public bool Ativo { get; set; }        

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Criacao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Alteracao { get; set; }

        public UsuarioEntity() : base()
        {
        }

        public UsuarioEntity(int id, string apelido, string senha, string nomeApresentacao, 
            string nomeCompleto, bool ativo, DateTime criacao, DateTime alteracao)
            : base(id) 
        {
            this.Apelido = apelido;
            this.Senha = senha;
            this.NomeApresentacao = nomeApresentacao;
            this.NomeCompleto = nomeCompleto;
            this.Ativo = ativo;
            this.Criacao = criacao;
            this.Alteracao = alteracao;
        }

        public UsuarioEntity(UsuarioEntity cor)
            : base(cor) 
        {
            if (cor != null) {
                this.Apelido = cor.Apelido;
                this.Senha = cor.Senha;
                this.NomeApresentacao = cor.NomeApresentacao;
                this.NomeCompleto = cor.NomeCompleto;
                this.Ativo = cor.Ativo;
                this.Criacao = cor.Criacao;
                this.Alteracao = cor.Alteracao;
            }
        }
    }
}
