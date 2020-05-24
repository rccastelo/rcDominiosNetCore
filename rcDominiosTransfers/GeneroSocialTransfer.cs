using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class GeneroSocialTransfer : Transfer
    {
        public GeneroSocialEntity GeneroSocial { get; set; }

        public IList<GeneroSocialEntity> GeneroSocialLista { get; set; }

        public int PaginaAtual { get; set; }

        public int PaginaInicial { get; set; }

        public int PaginaFinal { get; set; }

        public int RegistrosPorPagina { get; set; }

        public int TotalRegistros { get; set; }

        public int TotalPaginas { get; set; }

        public int IdDe { get; set; }

        public int IdAte { get; set; }

        public string Descricao { get; set; }

        public string Codigo { get; set; }

        public string Ativo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CriacaoDe { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CriacaoAte { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AlteracaoDe { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AlteracaoAte { get; set; }

        public GeneroSocialTransfer() 
            : base()
        {
        }

        public GeneroSocialTransfer(GeneroSocialTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.GeneroSocialLista != null) {
                    this.GeneroSocialLista = new List<GeneroSocialEntity>(transfer.GeneroSocialLista);
                }
                if (transfer.GeneroSocial != null) {
                    this.GeneroSocial = new GeneroSocialEntity(transfer.GeneroSocial);
                }
                this.PaginaAtual = transfer.PaginaAtual;
                this.PaginaInicial = transfer.PaginaInicial;
                this.PaginaFinal = transfer.PaginaFinal;
                this.RegistrosPorPagina = transfer.RegistrosPorPagina;
                this.TotalRegistros = transfer.TotalRegistros;
                this.TotalPaginas = transfer.TotalPaginas;
                this.IdDe = transfer.IdDe;
                this.IdAte = transfer.IdAte;
                this.Descricao = transfer.Descricao;
                this.Codigo = transfer.Codigo;
                this.Ativo = transfer.Ativo;
                this.CriacaoDe = transfer.CriacaoDe;
                this.CriacaoAte = transfer.CriacaoAte;
                this.AlteracaoDe = transfer.AlteracaoDe;
                this.AlteracaoAte = transfer.AlteracaoAte;
            }
        }

        public void IncluirGeneroSocial(GeneroSocialEntity entity) {
            if (entity != null) {
                if (this.GeneroSocialLista == null) {
                    this.GeneroSocialLista = new List<GeneroSocialEntity>();
                }

                this.GeneroSocialLista.Add(entity);
            }
        }
    }
}
