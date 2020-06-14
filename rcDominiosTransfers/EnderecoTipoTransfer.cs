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

        public object Links { get; set; }

        public void TratarLinks() {
            string id = ((this.EnderecoTipo != null) ? this.EnderecoTipo.Id.ToString() : "0");

            var obj = new object[] {
                new {
                    info = "Listar", 
                    uri = "/rcDominiosNet/EnderecoTipo", 
                    method = "GET"
                },
                new {
                    info = "Consultar por id", 
                    uri = "/rcDominiosNet/EnderecoTipo/" + id, 
                    method = "GET"
                },
                new {
                    info = "Filtrar", 
                    uri = "/rcDominiosNet/EnderecoTipo/lista", 
                    method = "POST"
                },
                new {
                    info = "Incluir", 
                    uri = "/rcDominiosNet/EnderecoTipo", 
                    method = "POST"
                },
                new {
                    info = "Alterar", 
                    uri = "/rcDominiosNet/EnderecoTipo", 
                    method = "PUT"
                },
                new {
                    info = "Excluir por id", 
                    uri = "/rcDominiosNet/EnderecoTipo/" + id,
                    method = "DELETE"
                }
            };
            
            this.Links = obj;
        }

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
