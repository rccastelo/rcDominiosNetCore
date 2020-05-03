using System.Collections.Generic;
using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class PessoaTipoDataTransfer : DataTransfer
    {
        public PessoaTipoEntity PessoaTipo { get; set; }

        public IList<PessoaTipoEntity> PessoaTipoLista { get; set; }

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
            }
        }
    }
}
