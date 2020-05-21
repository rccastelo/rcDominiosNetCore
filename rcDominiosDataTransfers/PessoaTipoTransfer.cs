using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class PessoaTipoTransfer : DataTransfer
    {
        public PessoaTipoEntity PessoaTipo { get; set; }

        public PessoaTipoTransfer() 
            : base()
        {
        }

        public PessoaTipoTransfer(PessoaTipoTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                this.PessoaTipo = new PessoaTipoEntity(transfer.PessoaTipo);
            }
        }
    }
}
