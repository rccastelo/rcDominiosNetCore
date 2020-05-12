using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class SexoDataTransfer : DataTransfer
    {
        public SexoEntity Sexo { get; set; }

        public IList<SexoEntity> SexoLista { get; set; }

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

        public SexoDataTransfer() 
            : base()
        {
            this.Sexo = new SexoEntity();
            this.SexoLista = new List<SexoEntity>();
        }

        public SexoDataTransfer(SexoDataTransfer sexoDataTransfer) 
            : base(sexoDataTransfer)
        {
            if (sexoDataTransfer != null) {
                this.Sexo = new SexoEntity(sexoDataTransfer.Sexo);
                this.SexoLista = new List<SexoEntity>(sexoDataTransfer.SexoLista);
                this.IdDe = sexoDataTransfer.IdDe;
                this.IdAte = sexoDataTransfer.IdAte;
                this.AtivoFiltro = sexoDataTransfer.AtivoFiltro;
                this.CriacaoDe = sexoDataTransfer.CriacaoDe;
                this.CriacaoAte = sexoDataTransfer.CriacaoAte;
                this.AlteracaoDe = sexoDataTransfer.AlteracaoDe;
                this.AlteracaoAte = sexoDataTransfer.AlteracaoAte;
            }
        }
    }
}
