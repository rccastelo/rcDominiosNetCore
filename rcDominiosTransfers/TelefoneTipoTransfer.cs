using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class TelefoneTipoTransfer : TransferDominios
    {
        public TelefoneTipoEntity TelefoneTipo { get; set; }

        public IList<TelefoneTipoEntity> Lista { get; set; }

        public TelefoneTipoTransfer() 
            : base()
        {
        }

        public TelefoneTipoTransfer(TelefoneTipoTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<TelefoneTipoEntity>(transfer.Lista);
                }
                if (transfer.TelefoneTipo != null) {
                    this.TelefoneTipo = new TelefoneTipoEntity(transfer.TelefoneTipo);
                }
            }
        }

        public void IncluirTelefoneTipo(TelefoneTipoEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<TelefoneTipoEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
