using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class ProfissaoTransfer : DataTransfer
    {
        public ProfissaoEntity Profissao { get; set; }

        public ProfissaoTransfer() 
            : base()
        {
        }

        public ProfissaoTransfer(ProfissaoTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                this.Profissao = new ProfissaoEntity(transfer.Profissao);
            }
        }
    }
}
