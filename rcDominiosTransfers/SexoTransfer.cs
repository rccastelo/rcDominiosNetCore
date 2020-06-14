using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class SexoTransfer : TransferDominios
    {
        public SexoEntity Sexo { get; set; }

        public IList<SexoEntity> Lista { get; set; }

        public object Links { get; set; }

        public void TratarLinks() {
            string id = ((this.Sexo != null) ? this.Sexo.Id.ToString() : "0");

            var obj = new object[] {
                new {
                    info = "Listar", 
                    uri = "/rcDominiosNet/Sexo", 
                    method = "GET"
                },
                new {
                    info = "Consultar por id", 
                    uri = "/rcDominiosNet/Sexo/" + id, 
                    method = "GET"
                },
                new {
                    info = "Filtrar", 
                    uri = "/rcDominiosNet/Sexo/lista", 
                    method = "POST"
                },
                new {
                    info = "Incluir", 
                    uri = "/rcDominiosNet/Sexo", 
                    method = "POST"
                },
                new {
                    info = "Alterar", 
                    uri = "/rcDominiosNet/Sexo", 
                    method = "PUT"
                },
                new {
                    info = "Excluir por id", 
                    uri = "/rcDominiosNet/Sexo/" + id,
                    method = "DELETE"
                }
            };
            
            this.Links = obj;
        }

        public SexoTransfer() 
            : base()
        {
        }

        public SexoTransfer(SexoTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<SexoEntity>(transfer.Lista);
                }
                if (transfer.Sexo != null) {
                    this.Sexo = new SexoEntity(transfer.Sexo);
                }
            }
        }

        public void IncluirSexo(SexoEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<SexoEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
