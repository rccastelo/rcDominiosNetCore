using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class EnderecoTipoDataTransfer : DataTransfer
    {
        public EnderecoTipoEntity EnderecoTipo { get; set; }

        public IList<EnderecoTipoEntity> EnderecoTipoLista { get; set; }

        public int IdDe { get; set; }

        public int IdAte { get; set; }

        public string AtivoFiltro { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CriacaoDe { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CriacaoAte { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AlteracaoDe { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AlteracaoAte { get; set; }

        public EnderecoTipoDataTransfer() 
            : base()
        {
            this.EnderecoTipo = new EnderecoTipoEntity();
            this.EnderecoTipoLista = new List<EnderecoTipoEntity>();
        }

        public EnderecoTipoDataTransfer(EnderecoTipoDataTransfer enderecoTipoDataTransfer) 
            : base(enderecoTipoDataTransfer)
        {
            if (enderecoTipoDataTransfer != null) {
                this.EnderecoTipo = new EnderecoTipoEntity(enderecoTipoDataTransfer.EnderecoTipo);
                this.EnderecoTipoLista = new List<EnderecoTipoEntity>(enderecoTipoDataTransfer.EnderecoTipoLista);
                this.IdDe = enderecoTipoDataTransfer.IdDe;
                this.IdAte = enderecoTipoDataTransfer.IdAte;
                this.AtivoFiltro = enderecoTipoDataTransfer.AtivoFiltro;
                this.CriacaoDe = enderecoTipoDataTransfer.CriacaoDe;
                this.CriacaoAte = enderecoTipoDataTransfer.CriacaoAte;
                this.AlteracaoDe = enderecoTipoDataTransfer.AlteracaoDe;
                this.AlteracaoAte = enderecoTipoDataTransfer.AlteracaoAte;
            }
        }
    }
}
