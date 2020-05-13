using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class TelefoneTipoDataTransfer : DataTransfer
    {
        public TelefoneTipoEntity TelefoneTipo { get; set; }

        public IList<TelefoneTipoEntity> TelefoneTipoLista { get; set; }

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

        public TelefoneTipoDataTransfer() 
            : base()
        {
            this.TelefoneTipo = new TelefoneTipoEntity();
            this.TelefoneTipoLista = new List<TelefoneTipoEntity>();
        }

        public TelefoneTipoDataTransfer(TelefoneTipoDataTransfer telefoneTipoDataTransfer) 
            : base(telefoneTipoDataTransfer)
        {
            if (telefoneTipoDataTransfer != null) {
                this.TelefoneTipo = new TelefoneTipoEntity(telefoneTipoDataTransfer.TelefoneTipo);
                this.TelefoneTipoLista = new List<TelefoneTipoEntity>(telefoneTipoDataTransfer.TelefoneTipoLista);
                this.IdDe = telefoneTipoDataTransfer.IdDe;
                this.IdAte = telefoneTipoDataTransfer.IdAte;
                this.AtivoFiltro = telefoneTipoDataTransfer.AtivoFiltro;
                this.CriacaoDe = telefoneTipoDataTransfer.CriacaoDe;
                this.CriacaoAte = telefoneTipoDataTransfer.CriacaoAte;
                this.AlteracaoDe = telefoneTipoDataTransfer.AlteracaoDe;
                this.AlteracaoAte = telefoneTipoDataTransfer.AlteracaoAte;
            }
        }
    }
}
