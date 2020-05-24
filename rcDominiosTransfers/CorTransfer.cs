using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class CorTransfer : Transfer
    {
        public CorEntity Cor { get; set; }

        public IList<CorEntity> CorLista { get; set; }

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

        public CorTransfer() 
            : base()
        {
        }

        public CorTransfer(CorTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.CorLista != null) {
                    this.CorLista = new List<CorEntity>(transfer.CorLista);
                }
                if (transfer.Cor != null) {
                    this.Cor = new CorEntity(transfer.Cor);
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

        public void IncluirCor(CorEntity entity) {
            if (entity != null) {
                if (this.CorLista == null) {
                    this.CorLista = new List<CorEntity>();
                }

                this.CorLista.Add(entity);
            }
        }
    }
}
