using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class PessoaTipoDataTransfer : DataTransfer
    {
        public PessoaTipoEntity PessoaTipo { get; set; }

        public IList<PessoaTipoEntity> PessoaTipoLista { get; set; }

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

        public PessoaTipoDataTransfer() 
            : base()
        {
            this.PessoaTipo = new PessoaTipoEntity();
            this.PessoaTipoLista = new List<PessoaTipoEntity>();
        }

        public PessoaTipoDataTransfer(PessoaTipoDataTransfer pessoaTipoDataTransfer) 
            : base(pessoaTipoDataTransfer)
        {
            if (pessoaTipoDataTransfer != null) {
                this.PessoaTipo = new PessoaTipoEntity(pessoaTipoDataTransfer.PessoaTipo);
                this.PessoaTipoLista = new List<PessoaTipoEntity>(pessoaTipoDataTransfer.PessoaTipoLista);
                this.IdDe = pessoaTipoDataTransfer.IdDe;
                this.IdAte = pessoaTipoDataTransfer.IdAte;
                this.AtivoFiltro = pessoaTipoDataTransfer.AtivoFiltro;
                this.CriacaoDe = pessoaTipoDataTransfer.CriacaoDe;
                this.CriacaoAte = pessoaTipoDataTransfer.CriacaoAte;
                this.AlteracaoDe = pessoaTipoDataTransfer.AlteracaoDe;
                this.AlteracaoAte = pessoaTipoDataTransfer.AlteracaoAte;
            }
        }
    }
}
