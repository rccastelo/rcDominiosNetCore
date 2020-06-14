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

        public object Links { get; set; }

        public void TratarLinks() {
            string id = ((this.EstadoCivil != null) ? this.EstadoCivil.Id.ToString() : "0");

            var obj = new object[] {
                new {
                    info = "Listar", 
                    uri = "/rcDominiosNet/EstadoCivil", 
                    method = "GET"
                },
                new {
                    info = "Consultar por id", 
                    uri = "/rcDominiosNet/EstadoCivil/" + id, 
                    method = "GET"
                },
                new {
                    info = "Filtrar", 
                    uri = "/rcDominiosNet/EstadoCivil/lista", 
                    method = "POST"
                },
                new {
                    info = "Incluir", 
                    uri = "/rcDominiosNet/EstadoCivil", 
                    method = "POST"
                },
                new {
                    info = "Alterar", 
                    uri = "/rcDominiosNet/EstadoCivil", 
                    method = "PUT"
                },
                new {
                    info = "Excluir por id", 
                    uri = "/rcDominiosNet/EstadoCivil/" + id,
                    method = "DELETE"
                }
            };
            
            this.Links = obj;
        }

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
