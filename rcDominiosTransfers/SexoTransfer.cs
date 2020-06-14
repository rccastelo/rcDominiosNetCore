using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class SexoTransfer : TransferDominios
    {
        public SexoEntity Sexo { get; set; }

        public IList<SexoEntity> Lista { get; set; }

        public SexoTransfer() 
            : base()
        {
        }

        public SexoTransfer(SexoTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<SexoEntity>(transfer.Lista);
                }
                if (transfer.Sexo != null) {
                    this.Sexo = new SexoEntity(transfer.Sexo);
                }
            }
        }

        public void IncluirSexo(SexoEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<SexoEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
