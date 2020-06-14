using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class EnderecoTipoTransfer : TransferDominios
    {
        public EnderecoTipoEntity EnderecoTipo { get; set; }

        public IList<EnderecoTipoEntity> Lista { get; set; }

        public EnderecoTipoTransfer() 
            : base()
        {
        }

        public EnderecoTipoTransfer(EnderecoTipoTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<EnderecoTipoEntity>(transfer.Lista);
                }
                if (transfer.EnderecoTipo != null) {
                    this.EnderecoTipo = new EnderecoTipoEntity(transfer.EnderecoTipo);
                }
            }
        }

        public void IncluirEnderecoTipo(EnderecoTipoEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<EnderecoTipoEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
