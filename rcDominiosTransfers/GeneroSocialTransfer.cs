using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class GeneroSocialTransfer : TransferDominios
    {
        public GeneroSocialEntity GeneroSocial { get; set; }

        public IList<GeneroSocialEntity> Lista { get; set; }

        public GeneroSocialTransfer() 
            : base()
        {
        }

        public GeneroSocialTransfer(GeneroSocialTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<GeneroSocialEntity>(transfer.Lista);
                }
                if (transfer.GeneroSocial != null) {
                    this.GeneroSocial = new GeneroSocialEntity(transfer.GeneroSocial);
                }
            }
        }

        public void IncluirGeneroSocial(GeneroSocialEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<GeneroSocialEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
