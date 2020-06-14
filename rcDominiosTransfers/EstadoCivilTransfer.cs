using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class EstadoCivilTransfer : TransferDominios
    {
        public EstadoCivilEntity EstadoCivil { get; set; }

        public IList<EstadoCivilEntity> Lista { get; set; }

        public EstadoCivilTransfer() 
            : base()
        {
        }

        public EstadoCivilTransfer(EstadoCivilTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<EstadoCivilEntity>(transfer.Lista);
                }
                if (transfer.EstadoCivil != null) {
                    this.EstadoCivil = new EstadoCivilEntity(transfer.EstadoCivil);
                }
            }
        }

        public void IncluirEstadoCivil(EstadoCivilEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<EstadoCivilEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
