using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class ContaBancariaTransfer : TransferDominios
    {
        public ContaBancariaEntity ContaBancaria { get; set; }

        public IList<ContaBancariaEntity> Lista { get; set; }

        public ContaBancariaTransfer() 
            : base()
        {
        }

        public ContaBancariaTransfer(ContaBancariaTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<ContaBancariaEntity>(transfer.Lista);
                }
                if (transfer.ContaBancaria != null) {
                    this.ContaBancaria = new ContaBancariaEntity(transfer.ContaBancaria);
                }
            }
        }

        public void IncluirContaBancaria(ContaBancariaEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<ContaBancariaEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
