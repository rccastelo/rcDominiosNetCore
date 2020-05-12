using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class EstadoCivilDataTransfer : DataTransfer
    {
        public EstadoCivilEntity EstadoCivil { get; set; }

        public IList<EstadoCivilEntity> EstadoCivilLista { get; set; }

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

        public EstadoCivilDataTransfer() 
            : base()
        {
            this.EstadoCivil = new EstadoCivilEntity();
            this.EstadoCivilLista = new List<EstadoCivilEntity>();
        }

        public EstadoCivilDataTransfer(EstadoCivilDataTransfer estadoCivilDataTransfer) 
            : base(estadoCivilDataTransfer)
        {
            if (estadoCivilDataTransfer != null) {
                this.EstadoCivil = new EstadoCivilEntity(estadoCivilDataTransfer.EstadoCivil);
                this.EstadoCivilLista = new List<EstadoCivilEntity>(estadoCivilDataTransfer.EstadoCivilLista);
                this.IdDe = estadoCivilDataTransfer.IdDe;
                this.IdAte = estadoCivilDataTransfer.IdAte;
                this.AtivoFiltro = estadoCivilDataTransfer.AtivoFiltro;
                this.CriacaoDe = estadoCivilDataTransfer.CriacaoDe;
                this.CriacaoAte = estadoCivilDataTransfer.CriacaoAte;
                this.AlteracaoDe = estadoCivilDataTransfer.AlteracaoDe;
                this.AlteracaoAte = estadoCivilDataTransfer.AlteracaoAte;
            }
        }
    }
}
