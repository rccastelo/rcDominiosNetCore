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

        public object Links { get; set; }

        public void TratarLinks() {
            string id = ((this.Cor != null) ? this.Cor.Id.ToString() : "0");

            var obj = new object[] {
                new {
                    info = "Listar", 
                    uri = "/rcDominiosNet/Cor", 
                    method = "GET"
                },
                new {
                    info = "Consultar por id", 
                    uri = "/rcDominiosNet/Cor/" + id, 
                    method = "GET"
                },
                new {
                    info = "Filtrar", 
                    uri = "/rcDominiosNet/Cor/lista", 
                    method = "POST"
                },
                new {
                    info = "Incluir", 
                    uri = "/rcDominiosNet/Cor", 
                    method = "POST"
                },
                new {
                    info = "Alterar", 
                    uri = "/rcDominiosNet/Cor", 
                    method = "PUT"
                },
                new {
                    info = "Excluir por id", 
                    uri = "/rcDominiosNet/Cor/" + id,
                    method = "DELETE"
                }
            };
            
            this.Links = obj;
        }

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
                this.Links = transfer.Links;
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
