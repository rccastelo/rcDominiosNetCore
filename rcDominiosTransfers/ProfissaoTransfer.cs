using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class ProfissaoTransfer : TransferDominios
    {
        public ProfissaoEntity Profissao { get; set; }

        public IList<ProfissaoEntity> Lista { get; set; }

        public ProfissaoTransfer() 
            : base()
        {
        }

        public ProfissaoTransfer(ProfissaoTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<ProfissaoEntity>(transfer.Lista);
                }
                if (transfer.Profissao != null) {
                    this.Profissao = new ProfissaoEntity(transfer.Profissao);
                }
            }
        }

        public void IncluirProfissao(ProfissaoEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<ProfissaoEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
