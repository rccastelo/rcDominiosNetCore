using System;
using System.ComponentModel.DataAnnotations;

namespace rcDominiosEntities
{
    public class ContaBancariaEntity : Entity
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

        public ContaBancariaEntity() : base()
        {
        }

        public ContaBancariaEntity(int id, string descricao, string codigo, bool ativo, DateTime criacao, DateTime alteracao)
            : base(id) 
        {
            this.Descricao = descricao;
            this.Codigo = codigo;
            this.Ativo = ativo;
            this.Criacao = criacao;
            this.Alteracao = alteracao;
        }

        public ContaBancariaEntity(ContaBancariaEntity contaBancaria)
            : base(contaBancaria) 
        {
            if (contaBancaria != null) {
                this.Descricao = contaBancaria.Descricao;
                this.Codigo = contaBancaria.Codigo;
                this.Ativo = contaBancaria.Ativo;
                this.Criacao = contaBancaria.Criacao;
                this.Alteracao = contaBancaria.Alteracao;
            }
        }
    }
}
