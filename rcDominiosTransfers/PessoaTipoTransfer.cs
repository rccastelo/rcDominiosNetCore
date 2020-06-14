using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class PessoaTipoTransfer : TransferDominios
    {
        public PessoaTipoEntity PessoaTipo { get; set; }

        public IList<PessoaTipoEntity> Lista { get; set; }

        public PessoaTipoTransfer() 
            : base()
        {
        }

        public PessoaTipoTransfer(PessoaTipoTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<PessoaTipoEntity>(transfer.Lista);
                }
                if (transfer.PessoaTipo != null) {
                    this.PessoaTipo = new PessoaTipoEntity(transfer.PessoaTipo);
                }
            }
        }

        public void IncluirPessoaTipo(PessoaTipoEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<PessoaTipoEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
