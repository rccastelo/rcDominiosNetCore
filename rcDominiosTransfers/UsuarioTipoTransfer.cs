using System.Collections.Generic;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
  public class UsuarioTipoTransfer : TransferDominios
    {
        public UsuarioTipoEntity UsuarioTipo { get; set; }

        public IList<UsuarioTipoEntity> Lista { get; set; }

        public UsuarioTipoTransfer() 
            : base()
        {
        }

        public UsuarioTipoTransfer(UsuarioTipoTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<UsuarioTipoEntity>(transfer.Lista);
                }
                if (transfer.UsuarioTipo != null) {
                    this.UsuarioTipo = new UsuarioTipoEntity(transfer.UsuarioTipo);
                }
            }
        }

        public void IncluirUsuarioTipo(UsuarioTipoEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<UsuarioTipoEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
