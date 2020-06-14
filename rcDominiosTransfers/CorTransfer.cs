using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class CorTransfer : TransferDominios
    {
        public CorEntity Cor { get; set; }

        public IList<CorEntity> Lista { get; set; }

        public CorTransfer() 
            : base()
        {
        }

        public CorTransfer(CorTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<CorEntity>(transfer.Lista);
                }
                if (transfer.Cor != null) {
                    this.Cor = new CorEntity(transfer.Cor);
                }
            }
        }

        public void IncluirCor(CorEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<CorEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
