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

        public object Links { get; set; }

        public void TratarLinks() {
            string id = ((this.PessoaTipo != null) ? this.PessoaTipo.Id.ToString() : "0");

            var obj = new object[] {
                new {
                    info = "Listar", 
                    uri = "/rcDominiosNet/PessoaTipo", 
                    method = "GET"
                },
                new {
                    info = "Consultar por id", 
                    uri = "/rcDominiosNet/PessoaTipo/" + id, 
                    method = "GET"
                },
                new {
                    info = "Filtrar", 
                    uri = "/rcDominiosNet/PessoaTipo/lista", 
                    method = "POST"
                },
                new {
                    info = "Incluir", 
                    uri = "/rcDominiosNet/PessoaTipo", 
                    method = "POST"
                },
                new {
                    info = "Alterar", 
                    uri = "/rcDominiosNet/PessoaTipo", 
                    method = "PUT"
                },
                new {
                    info = "Excluir por id", 
                    uri = "/rcDominiosNet/PessoaTipo/" + id,
                    method = "DELETE"
                }
            };
            
            this.Links = obj;
        }

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
