using System;
using System.Collections.Generic;
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

        public DateTime CriacaoDe { get; set; }
        
        public DateTime CriacaoAte { get; set; }

        public DateTime AlteracaoDe { get; set; }
        
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
