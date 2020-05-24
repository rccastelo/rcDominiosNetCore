using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class EnderecoTipoTransfer : Transfer
    {
        public EnderecoTipoEntity EnderecoTipo { get; set; }

        public IList<EnderecoTipoEntity> EnderecoTipoLista { get; set; }

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

        public EnderecoTipoTransfer() 
            : base()
        {
        }

        public EnderecoTipoTransfer(EnderecoTipoTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.EnderecoTipoLista != null) {
                    this.EnderecoTipoLista = new List<EnderecoTipoEntity>(transfer.EnderecoTipoLista);
                }
                if (transfer.EnderecoTipo != null) {
                    this.EnderecoTipo = new EnderecoTipoEntity(transfer.EnderecoTipo);
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

        public void IncluirEnderecoTipo(EnderecoTipoEntity entity) {
            if (entity != null) {
                if (this.EnderecoTipoLista == null) {
                    this.EnderecoTipoLista = new List<EnderecoTipoEntity>();
                }

                this.EnderecoTipoLista.Add(entity);
            }
        }
    }
}
