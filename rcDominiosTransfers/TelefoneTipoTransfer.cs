using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class TelefoneTipoTransfer : TransferDominios
    {
        public TelefoneTipoEntity TelefoneTipo { get; set; }

        public IList<TelefoneTipoEntity> Lista { get; set; }

        public object Links { get; set; }

        public void TratarLinks() {
            string id = ((this.TelefoneTipo != null) ? this.TelefoneTipo.Id.ToString() : "0");

            var obj = new object[] {
                new {
                    info = "Listar", 
                    uri = "/rcDominiosNet/TelefoneTipo", 
                    method = "GET"
                },
                new {
                    info = "Consultar por id", 
                    uri = "/rcDominiosNet/TelefoneTipo/" + id, 
                    method = "GET"
                },
                new {
                    info = "Filtrar", 
                    uri = "/rcDominiosNet/TelefoneTipo/lista", 
                    method = "POST"
                },
                new {
                    info = "Incluir", 
                    uri = "/rcDominiosNet/TelefoneTipo", 
                    method = "POST"
                },
                new {
                    info = "Alterar", 
                    uri = "/rcDominiosNet/TelefoneTipo", 
                    method = "PUT"
                },
                new {
                    info = "Excluir por id", 
                    uri = "/rcDominiosNet/TelefoneTipo/" + id,
                    method = "DELETE"
                }
            };
            
            this.Links = obj;
        }

        public TelefoneTipoTransfer() 
            : base()
        {
        }

        public TelefoneTipoTransfer(TelefoneTipoTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<TelefoneTipoEntity>(transfer.Lista);
                }
                if (transfer.TelefoneTipo != null) {
                    this.TelefoneTipo = new TelefoneTipoEntity(transfer.TelefoneTipo);
                }
            }
        }

        public void IncluirTelefoneTipo(TelefoneTipoEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<TelefoneTipoEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
