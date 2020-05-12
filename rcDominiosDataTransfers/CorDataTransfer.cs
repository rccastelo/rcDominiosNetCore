using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class CorDataTransfer : DataTransfer
    {
        public CorEntity Cor { get; set; }

        public IList<CorEntity> CorLista { get; set; }

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

        public CorDataTransfer() 
            : base()
        {
            this.Cor = new CorEntity();
            this.CorLista = new List<CorEntity>();
        }

        public CorDataTransfer(CorDataTransfer corDataTransfer) 
            : base(corDataTransfer)
        {
            if (corDataTransfer != null) {
                this.Cor = new CorEntity(corDataTransfer.Cor);
                this.CorLista = new List<CorEntity>(corDataTransfer.CorLista);
                this.IdDe = corDataTransfer.IdDe;
                this.IdAte = corDataTransfer.IdAte;
                this.AtivoFiltro = corDataTransfer.AtivoFiltro;
                this.CriacaoDe = corDataTransfer.CriacaoDe;
                this.CriacaoAte = corDataTransfer.CriacaoAte;
                this.AlteracaoDe = corDataTransfer.AlteracaoDe;
                this.AlteracaoAte = corDataTransfer.AlteracaoAte;
            }
        }
    }
}
